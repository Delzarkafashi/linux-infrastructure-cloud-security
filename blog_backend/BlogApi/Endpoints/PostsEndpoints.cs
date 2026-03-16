using Dapper;
using Npgsql;
using System.Security.Claims;

namespace BlogApi.Endpoints;

public static class PostsEndpoints
{
    private static bool IsAdminUser(ClaimsPrincipal user)
    {
        var role =
            user.FindFirst(ClaimTypes.Role)?.Value ??
            user.FindFirst("role")?.Value ??
            user.FindFirst("http://schemas.microsoft.com/ws/2008/06/identity/claims/role")?.Value;

        return role == "admin";
    }

    private static int? GetUserId(ClaimsPrincipal user)
    {
        var userIdValue =
            user.FindFirst(ClaimTypes.NameIdentifier)?.Value ??
            user.FindFirst("nameid")?.Value ??
            user.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;

        if (int.TryParse(userIdValue, out var userId))
            return userId;

        return null;
    }

    public static void MapPostsEndpoints(this WebApplication app, string connectionString)
    {
        app.MapGet("/posts", async () =>
        {
            await using var connection = new NpgsqlConnection(connectionString);

            var sql = @"
SELECT id, title, content, user_id, created_at, updated_at
FROM posts
ORDER BY id;
";

            var posts = await connection.QueryAsync(sql);

            return Results.Ok(posts);
        });

        app.MapGet("/posts/{id}", async (int id) =>
        {
            await using var connection = new NpgsqlConnection(connectionString);

            var sql = @"
SELECT id, title, content, user_id, created_at, updated_at
FROM posts
WHERE id = @id;
";

            var post = await connection.QueryFirstOrDefaultAsync(sql, new { id });

            if (post is null)
                return Results.NotFound();

            return Results.Ok(post);
        });

        app.MapPost("/posts", async (HttpContext httpContext, string title, string content) =>
        {
            if (!IsAdminUser(httpContext.User))
                return Results.Unauthorized();

            var userId = GetUserId(httpContext.User);

            if (userId is null)
                return Results.Unauthorized();

            await using var connection = new NpgsqlConnection(connectionString);

            var sql = @"
INSERT INTO posts (title, content, user_id)
VALUES (@title, @content, @user_id)
RETURNING id;
";

            var id = await connection.ExecuteScalarAsync<int>(sql, new
            {
                title,
                content,
                user_id = userId.Value
            });

            return Results.Ok(new { id });
        });

        app.MapPut("/posts/{id}", async (HttpContext httpContext, int id, string title, string content) =>
        {
            if (!IsAdminUser(httpContext.User))
                return Results.Unauthorized();

            await using var connection = new NpgsqlConnection(connectionString);

            var sql = @"
UPDATE posts
SET title = @title,
    content = @content,
    updated_at = CURRENT_TIMESTAMP
WHERE id = @id;
";

            var rowsAffected = await connection.ExecuteAsync(sql, new { id, title, content });

            if (rowsAffected == 0)
                return Results.NotFound();

            return Results.Ok(new { message = "Post updated" });
        });

        app.MapDelete("/posts/{id}", async (HttpContext httpContext, int id) =>
        {
            if (!IsAdminUser(httpContext.User))
                return Results.Unauthorized();

            await using var connection = new NpgsqlConnection(connectionString);

            var sql = @"
DELETE FROM posts
WHERE id = @id;
";

            var rowsAffected = await connection.ExecuteAsync(sql, new { id });

            if (rowsAffected == 0)
                return Results.NotFound();

            return Results.Ok(new { message = "Post deleted" });
        });
    }
}

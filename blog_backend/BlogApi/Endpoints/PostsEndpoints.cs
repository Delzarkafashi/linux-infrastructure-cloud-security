using Dapper;
using Npgsql;

namespace BlogApi.Endpoints;

public static class PostsEndpoints
{
    public static void MapPostsEndpoints(this WebApplication app, string connectionString)
    {
        app.MapGet("/posts", async () =>
        {
            await using var connection = new NpgsqlConnection(connectionString);

            var sql = """
                SELECT id, title, content, user_id, created_at, updated_at
                FROM posts
                ORDER BY id;
                """;

            var posts = await connection.QueryAsync(sql);

            return Results.Ok(posts);
        });

        app.MapGet("/posts/{id}", async (int id) =>
        {
            await using var connection = new NpgsqlConnection(connectionString);

            var sql = """
                SELECT id, title, content, user_id, created_at, updated_at
                FROM posts
                WHERE id = @id;
                """;

            var post = await connection.QueryFirstOrDefaultAsync(sql, new { id });

            if (post is null)
                return Results.NotFound();

            return Results.Ok(post);
        });

        app.MapPost("/posts", async (HttpContext httpContext, string title, string content, int user_id) =>
        {
            if (!httpContext.User.IsInRole("admin"))
                return Results.Unauthorized();

            await using var connection = new NpgsqlConnection(connectionString);

            var sql = """
                INSERT INTO posts (title, content, user_id)
                VALUES (@title, @content, @user_id)
                RETURNING id;
                """;

            var id = await connection.ExecuteScalarAsync<int>(sql, new { title, content, user_id });

            return Results.Ok(new { id });
        });

        app.MapPut("/posts/{id}", async (HttpContext httpContext, int id, string title, string content) =>
        {
            if (!httpContext.User.IsInRole("admin"))
                return Results.Unauthorized();

            await using var connection = new NpgsqlConnection(connectionString);

            var sql = """
                UPDATE posts
                SET title = @title,
                    content = @content,
                    updated_at = CURRENT_TIMESTAMP
                WHERE id = @id;
                """;

            var rowsAffected = await connection.ExecuteAsync(sql, new { id, title, content });

            if (rowsAffected == 0)
                return Results.NotFound();

            return Results.Ok(new { message = "Post updated" });
        });

        app.MapDelete("/posts/{id}", async (HttpContext httpContext, int id) =>
        {
            if (!httpContext.User.IsInRole("admin"))
                return Results.Unauthorized();

            await using var connection = new NpgsqlConnection(connectionString);

            var sql = """
                DELETE FROM posts
                WHERE id = @id;
                """;

            var rowsAffected = await connection.ExecuteAsync(sql, new { id });

            if (rowsAffected == 0)
                return Results.NotFound();

            return Results.Ok(new { message = "Post deleted" });
        });
    }
}

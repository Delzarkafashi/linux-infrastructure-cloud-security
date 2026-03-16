using Dapper;
using Npgsql;
using BlogApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BlogApi.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this WebApplication app, string connectionString, string jwtKey, string jwtIssuer, string jwtAudience)
    {
        app.MapPost("/login", async (LoginRequest request) =>
        {
            await using var connection = new NpgsqlConnection(connectionString);

            var sql = """
                SELECT id, username, password_hash, role
                FROM users
                WHERE username = @Username;
                """;

            var user = await connection.QueryFirstOrDefaultAsync(sql, new { request.Username });

            if (user is null)
                return Results.Unauthorized();

            if (user.password_hash != request.Password)
                return Results.Unauthorized();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.id.ToString()),
                new Claim(ClaimTypes.Name, user.username.ToString()),
                new Claim(ClaimTypes.Role, user.role.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtIssuer,
                audience: jwtAudience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return Results.Ok(new
            {
                token = jwt,
                userId = user.id,
                username = user.username,
                role = user.role
            });
        });
    }
}

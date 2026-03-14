using AvvikelseApi.Models;
using AvvikelseApi.Repositories;

namespace AvvikelseApi.Endpoints;

public static class LoginEndpoints
{
    public static void MapLoginEndpoints(this WebApplication app)
    {
        app.MapPost("/login", async (LoginRequest request, UsersRepository repo) =>
        {
            var user = await repo.GetUserByUsername(request.Username);

            if (user == null || !repo.VerifyPassword(request.Password, user.Password))
                return Results.Unauthorized();

            return Results.Ok(new { message = "Login successful" });
        });
    }
}

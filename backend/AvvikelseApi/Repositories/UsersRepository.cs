using Dapper;
using AvvikelseApi.Data;
using AvvikelseApi.Models;

namespace AvvikelseApi.Repositories;

public class UsersRepository
{
    private readonly DbConnectionFactory _dbFactory;

    public UsersRepository(DbConnectionFactory dbFactory)
    {
        _dbFactory = dbFactory;
    }

    public async Task<User?> GetUserByUsername(string username)
    {
        using var connection = _dbFactory.CreateConnection();

        var sql = "SELECT id, username, password, role FROM users WHERE username = @Username";

        var user = await connection.QuerySingleOrDefaultAsync<User>(
            sql,
            new { Username = username }
        );

        return user;
    }

    public bool VerifyPassword(string password, string userPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, userPassword);
    }
}

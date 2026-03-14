using Dapper;
using AvvikelseApi.Data;
using AvvikelseApi.Models;

namespace AvvikelseApi.Repositories;

public class AvvikelseRepository
{
    private readonly DbConnectionFactory _dbFactory;

    public AvvikelseRepository(DbConnectionFactory dbFactory)
    {
        _dbFactory = dbFactory;
    }

    public async Task<IEnumerable<Avvikelse>> GetAll()
    {
        using var connection = _dbFactory.CreateConnection();

        var sql = "SELECT id, title, description, created_by, created_at FROM avvikelser";

        var result = await connection.QueryAsync<Avvikelse>(sql);

        return result;
    }
}

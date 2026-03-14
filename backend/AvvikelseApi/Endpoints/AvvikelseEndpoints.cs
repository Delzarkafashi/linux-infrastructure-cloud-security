using AvvikelseApi.Repositories;

namespace AvvikelseApi.Endpoints;

public static class AvvikelseEndpoints
{
    public static void MapAvvikelseEndpoints(this WebApplication app)
    {
        app.MapGet("/avvikelser", async (AvvikelseRepository repository) =>
        {
            var avvikelser = await repository.GetAll();
            return Results.Ok(avvikelser);
        });
    }
}

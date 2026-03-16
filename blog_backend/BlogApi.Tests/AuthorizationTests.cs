using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace BlogApi.Tests;

public class AuthorizationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public AuthorizationTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Viewer_Should_Not_Be_Able_To_Create_Post()
    {
        var client = _factory.CreateClient();

        var response = await client.PostAsync(
            "/posts?title=Viewer%20Test&content=Viewer%20ska%20inte%20kunna%20posta",
            null
        );

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task Viewer_Should_Not_Be_Able_To_Update_Post()
    {
        var client = _factory.CreateClient();

        var response = await client.PutAsync(
            "/posts/1?title=Viewer%20Update&content=Viewer%20ska%20inte%20kunna%20uppdatera",
            null
        );

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task Viewer_Should_Not_Be_Able_To_Delete_Post()
    {
        var client = _factory.CreateClient();

        var response = await client.DeleteAsync("/posts/1");

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }
}

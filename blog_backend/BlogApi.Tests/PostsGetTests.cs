using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace BlogApi.Tests;

public class PostsGetTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public PostsGetTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Get_Posts_Should_Return_Response()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/posts");

        Assert.True(
            response.StatusCode == HttpStatusCode.OK ||
            response.StatusCode == HttpStatusCode.Unauthorized
        );
    }
[Fact]
public async Task Get_Post_By_Id_Should_Return_Response()
{
    var client = _factory.CreateClient();

    var response = await client.GetAsync("/posts/1");

    Assert.True(
        response.StatusCode == HttpStatusCode.OK ||
        response.StatusCode == HttpStatusCode.NotFound ||
        response.StatusCode == HttpStatusCode.Unauthorized
    );
}	
}

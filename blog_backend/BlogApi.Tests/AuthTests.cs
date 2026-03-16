using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace BlogApi.Tests;

public class AuthTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public AuthTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Login_With_Wrong_Password_Should_Return_Unauthorized()
    {
        var client = _factory.CreateClient();

        var loginData = new
        {
            username = "admin",
            password = "fel-losen"
        };

        var response = await client.PostAsJsonAsync("/login", loginData);

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task Login_With_Admin_Should_Return_Ok()
    {
        var client = _factory.CreateClient();

        var loginData = new
        {
            username = "admin",
            password = "admin123"
        };

        var response = await client.PostAsJsonAsync("/login", loginData);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}

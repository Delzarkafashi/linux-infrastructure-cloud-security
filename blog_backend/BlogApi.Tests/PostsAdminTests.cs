using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace BlogApi.Tests;

public class PostsAdminTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public PostsAdminTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Admin_Should_Be_Able_To_Create_Post()
    {
        var client = _factory.CreateClient();

        var loginData = new
        {
            username = "admin",
            password = "admin123"
        };

        var loginResponse = await client.PostAsJsonAsync("/login", loginData);
        Assert.Equal(HttpStatusCode.OK, loginResponse.StatusCode);

        var json = await loginResponse.Content.ReadFromJsonAsync<JsonElement>();
        var token = json.GetProperty("token").GetString();

        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);

        var response = await client.PostAsync(
            "/posts?title=Test%20Post&content=Detta%20%C3%A4r%20ett%20testinl%C3%A4gg",
            null
        );

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Admin_Should_Be_Able_To_Update_Post()
    {
        var client = _factory.CreateClient();

        var loginData = new
        {
            username = "admin",
            password = "admin123"
        };

        var loginResponse = await client.PostAsJsonAsync("/login", loginData);
        Assert.Equal(HttpStatusCode.OK, loginResponse.StatusCode);

        var json = await loginResponse.Content.ReadFromJsonAsync<JsonElement>();
        var token = json.GetProperty("token").GetString();

        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);

        var response = await client.PutAsync(
            "/posts/1?title=Updated%20Title&content=Updated%20Content",
            null
        );

        Assert.True(
            response.StatusCode == HttpStatusCode.OK ||
            response.StatusCode == HttpStatusCode.NotFound
        );
    }

    [Fact]
    public async Task Admin_Should_Be_Able_To_Delete_Post()
    {
        var client = _factory.CreateClient();

        var loginData = new
        {
            username = "admin",
            password = "admin123"
        };

        var loginResponse = await client.PostAsJsonAsync("/login", loginData);
        Assert.Equal(HttpStatusCode.OK, loginResponse.StatusCode);

        var json = await loginResponse.Content.ReadFromJsonAsync<JsonElement>();
        var token = json.GetProperty("token").GetString();

        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);

        var response = await client.DeleteAsync("/posts/1");

        Assert.True(
            response.StatusCode == HttpStatusCode.OK ||
            response.StatusCode == HttpStatusCode.NotFound
        );
    }
}

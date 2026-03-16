using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace BlogApi.Tests;

public class ApiStartupTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public ApiStartupTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Api_Should_Start_And_Return_Response()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/posts");

        Assert.True(response.StatusCode == HttpStatusCode.OK 
                 || response.StatusCode == HttpStatusCode.Unauthorized 
                 || response.StatusCode == HttpStatusCode.NotFound);
    }
}

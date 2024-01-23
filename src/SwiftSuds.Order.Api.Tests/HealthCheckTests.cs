using Microsoft.AspNetCore.Mvc.Testing;
using SwiftSuds.Order.Api.Modules.HealthCheck.V1.Endpoints;
using System.Net.Http.Json;

namespace SwiftSuds.Order.Api.Tests;

public class HealthCheckTests
{
    [Fact]
    public async Task HealthCheck_GetHeathCheck_ReturnsOk()
    {
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();

        var response = await client.GetFromJsonAsync<GetHealthCheckResponse>("/api/v1/healthcheck");

        Assert.Equal("Ok", response.Status);
    }
}
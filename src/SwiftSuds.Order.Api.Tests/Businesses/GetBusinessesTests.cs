using System.Net;

namespace SwiftSuds.Order.Api.Tests.Businesses;

public class GetBusinessesTests
{
    private const string BaseUrl = "/api/v1/businesses";

    [Fact]
    public async Task GetCustomer_Should_ReturnListOfCustomers()
    {
        // arrange
        var application = new OrderApiTestApplication();

        // act
        using var client = application.CreateClient();
        var response = await client.GetAsync(BaseUrl);

        // assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

    }
}

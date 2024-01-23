using System.Net;


namespace SwiftSuds.Order.Api.Tests;

public class GetCustomersTests()
{
    private const string BaseUrl = "/api/v1/customers";

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
        // assert
    }
}

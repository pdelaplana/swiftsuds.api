using System.Net;

namespace SwiftSuds.Order.Api.Tests.Businesses;
public class GetBusinessByIdTests
{
    private const string BaseUrl = "/api/v1/businesses";

    [Fact]
    public async Task GetBusinessById_ShouldReturnBusiness_WhenInvoked()
    {
        // arrange
        var application = new OrderApiTestApplication();

        // act
        using var client = application.CreateClient();
        var response = await client.GetAsync(BaseUrl + "/" + Guid.NewGuid());

        // assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

    }
}

using SwiftSuds.Domain.ValueObjects;
using System.Net.Http.Json;
using System.Net;
using System.Text.Json;
using SwiftSuds.Order.Api.Modules.Orders.V1.Endpoints;

namespace SwiftSuds.Order.Api.Tests.Orders;
public class CreateOrderTests
{
    private const string BaseUrl = "/api/v1/orders";
    private readonly JsonSerializerOptions _serializerOptions = new()
    {
        IncludeFields = true
    };

    [Fact]
    public async Task CreateOrder_ShouldReturn201_WhenAllRequiredInformationIsProvided()
    {
        // arrange
        var application = new OrderApiTestApplication();

        // act
        using var client = application.CreateClient();

        var response = await client.PostAsJsonAsync(BaseUrl,
            new CreateOrderRequest(
                Guid.NewGuid(),
                Guid.NewGuid(),
                new Address { StreetAddress1 = "1 Main Street", City = "Manila" },
                DateTime.Now,
                DateTime.Now.AddHours(2),
                new Address { StreetAddress1 = "1 Main Street", City = "Manila" },
                DateTime.Now.AddDays(5),
                DateTime.Now.AddDays(5).AddHours(2),
                false,
                "PHP",
                new List<CreateOrderRequestItem>() { new("Shirts", 5) },
                new List<CreateOrderRequestService>() { new(Guid.NewGuid(), 1, (decimal)240.00) }
                ), 
            _serializerOptions);

        // assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);

    }

}

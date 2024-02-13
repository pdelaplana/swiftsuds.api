using SwiftSuds.Domain.ValueObjects;
using SwiftSuds.Order.Api.Modules.Customers.V1.Endpoints;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace SwiftSuds.Order.Api.Tests.Customers;

public class CreateCustomerTests()
{
    private const string BaseUrl = "/api/v1/customers";

    private readonly JsonSerializerOptions _serializerOptions = new()
    {
        IncludeFields = true
    };

    [Fact]
    public async Task CreateCustomer_Should_Return201_WhenAllRequiredInformationIsProvided()
    {
        // arrange
        /*
        var mockCustomerRepository = new Mock<ICustomerRepository>();
        await using var application = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder => builder
                .ConfigureServices(services =>
                {
                    services.AddScoped<ICustomerRepository>(sp => mockCustomerRepository.Object);
                })
            );

        */
        var application = new OrderApiTestApplication();

        // act
        using var client = application.CreateClient();

        var response = await client.PostAsJsonAsync(BaseUrl,
            new CreateCustomerRequest(
                Name: "Test Customer",
                Email: "customer@email.com",
                Phone: "02 9090 9090",
                Address: new Address() { StreetAddress1 = "101 Main Avenue" }
                ), 
            _serializerOptions);

        // assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task CreateCustomer_Should_ReturnBadRequest_WhenEmailIsAnEmptyString()
    {
        // arrange
        var application = new OrderApiTestApplication();

        // act
        using var client = application.CreateClient();

        var response = await client.PostAsJsonAsync(BaseUrl,
            new CreateCustomerRequest(
                Name: "Test Customer",
                Email: "",
                Phone: "02 9090 9090",
                Address: new Address() { StreetAddress1 = "101 Main Avenue" }
            ), _serializerOptions);

        // assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}

using Carter;
using SwiftSuds.Order.Api.Modules.Common;
using SwiftSuds.Order.Api.Modules.Customers.V1.Endpoints;

namespace SwiftSuds.Order.Api.Modules.Customers.V1;

public class CustomersModule : ICarterModule
{
    private const string BaseUrl = "api/v1/customers";

    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet($"{BaseUrl}", EndpointHandlerFactory.CreateHandler<GetCustomers>())
            .WithName("GetCustomers")
            .WithOpenApi();

        app.MapGet($"{BaseUrl}/{{id}}", EndpointHandlerFactory.CreateHandler<GetCustomerById>())
            .WithName("GetCustomersById")
            .WithOpenApi();


        app.MapPost($"{BaseUrl}", EndpointHandlerFactory.CreateHandler<CreateCustomer>())
            .WithName("CreateCustomer")
            .WithOpenApi();
    }
}

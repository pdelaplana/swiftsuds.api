using Carter;
using SwiftSuds.Order.Api.Modules.Common;
using SwiftSuds.Order.Api.Modules.Customers.V1.Endpoints;

namespace SwiftSuds.Order.Api.Modules.Customers.V1;

public class CustomersModule : ICarterModule
{

    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v1/customers");

        group.MapGet("/", EndpointHandlerFactory.CreateHandler<GetCustomers>())
            .WithName("GetCustomers");

        group.MapGet("/{id}", EndpointHandlerFactory.CreateHandler<GetCustomerById>())
            .WithName("GetCustomersById");

        group.MapPost("/", EndpointHandlerFactory.CreateHandler<CreateCustomer>())
            .WithName("CreateCustomer");

        group.WithTags("Customers (v1)").WithOpenApi();

    }
}

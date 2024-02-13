using Carter;
using SwiftSuds.Order.Api.Modules.Common;
using SwiftSuds.Order.Api.Modules.Orders.V1.Endpoints;

namespace SwiftSuds.Order.Api.Modules.Orders.V1;

public class OrdersModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v1/orders");

        group.MapPost("/", EndpointHandlerFactory.CreateHandler<CreateOrder>())
            .WithName("CreateOrder");


        group.WithTags("Orders (v1)").WithOpenApi();
    }
}

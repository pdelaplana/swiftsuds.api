using Carter;
using SwiftSuds.Order.Api.Modules.Businesses.V1.Endpoints;
using SwiftSuds.Order.Api.Modules.Common;

namespace SwiftSuds.Order.Api.Modules.Businesses.V1;

public class BusinessesModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v1/businesses");

        group.MapGet("/", EndpointHandlerFactory.CreateHandler<GetBusinesses>())
            .WithName("GetBusiness");

        group.MapGet("/{id:guid}", EndpointHandlerFactory.CreateHandler<GetBusinessById>())
            .WithName("GetBusinessById");

        group.WithTags("Businesses (v1)").WithOpenApi();
    }
}

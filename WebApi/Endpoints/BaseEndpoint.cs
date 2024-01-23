using Carter;

namespace WebApi.Endpoints;

public abstract class BaseEndpoint : CarterModule
{
    public abstract void MapEndpoint(IEndpointRouteBuilder endpointRouteBuilder);
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        MapEndpoint(app);
    }
}

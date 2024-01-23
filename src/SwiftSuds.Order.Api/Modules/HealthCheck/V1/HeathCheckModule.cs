using Carter;
using SwiftSuds.Order.Api.Modules.HealthCheck.V1.Endpoints;

namespace SwiftSuds.Order.Api.Modules.HealthCheck.V1;

public class HeathCheckModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/v1/healthcheck", GetHealthCheck.AsyncHandler);
    }
}

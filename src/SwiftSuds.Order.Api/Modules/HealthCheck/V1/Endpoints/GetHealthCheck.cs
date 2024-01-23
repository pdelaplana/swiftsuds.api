using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace SwiftSuds.Order.Api.Modules.HealthCheck.V1.Endpoints;


public static class GetHealthCheck
{
    public static Ok<GetHealthCheckResponse> AsyncHandler(IMediator mediator)
    {
        var response = new GetHealthCheckResponse("Ok");
        return TypedResults.Ok(response);
    }

}

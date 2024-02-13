using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using SwiftSuds.Application.UseCases.Businesses.GetBusinesses;
using SwiftSuds.Domain.Errors;
using SwiftSuds.Order.Api.Modules.Businesses.V1.Models;
using SwiftSuds.Order.Api.Modules.Common;


namespace SwiftSuds.Order.Api.Modules.Businesses.V1.Endpoints;

public class GetBusinesses : ApiEndpoint<GetBusinessesRequest, Results<Ok<GetBusinessesResponse>, ValidationProblem>>
{
    public override async Task<Results<Ok<GetBusinessesResponse>, ValidationProblem>> AsyncHandler(GetBusinessesRequest request, IMediator mediator, ILogger<GetBusinessesRequest> logger)
    {
        logger.LogInformation("Invoking endpoint '{endpoint}' with '{req}'",
            nameof(GetBusinessesRequest),
            request);
        var query = new GetBusinessesQuery()
        {
            Offset = (request.Page - 1) * request.Size,
            Limit = request.Size
        };
        var result = await mediator.Send(query);

        return result.Match<Results<Ok<GetBusinessesResponse>, ValidationProblem>>(
           data => TypedResults.Ok(
               new GetBusinessesResponse(
                   data.Select(b =>
                       new BusinessInfo(
                           b.BusinessId.Value,
                           b.Name,
                           b.Address)).ToList(),
                   request.Page,
                   request.Size)),
           error => TypedResults.ValidationProblem(((ValidationError)error).ValidationErrors)
       );
    }

    public override Delegate AsyncHandlerDelegate()
    {
        return AsyncHandler;
    }
}

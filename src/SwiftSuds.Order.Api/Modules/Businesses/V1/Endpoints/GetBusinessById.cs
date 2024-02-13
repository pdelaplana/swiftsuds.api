using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using SwiftSuds.Application.UseCases.Businesses.GetBusinessById;
using SwiftSuds.Domain.Errors;
using SwiftSuds.Order.Api.Modules.Common;

namespace SwiftSuds.Order.Api.Modules.Businesses.V1.Endpoints;

public class GetBusinessById : ApiEndpoint<GetBusinessByIdRequest, Results<Ok<GetBusinessByIdResponse>, ValidationProblem>>
{
    public override async Task<Results<Ok<GetBusinessByIdResponse>, ValidationProblem>> AsyncHandler(
        GetBusinessByIdRequest request, IMediator mediator, ILogger<GetBusinessByIdRequest> logger)
    {
        logger.LogInformation("Invoking endpoint '{endpoint}' with '{req}'",
           nameof(GetBusinessById),
           request);


        var query = new GetBusinessByIdQuery()
        {
            BusinessId = Guid.Parse(request.Id)
        };
        var result = await mediator.Send(query);

        return result.Match<Results<Ok<GetBusinessByIdResponse>, ValidationProblem>>(
            data =>
                TypedResults.Ok(
                    new GetBusinessByIdResponse(
                        data.BusinessId.Value,
                        data.Name,
                        data.Address,
                        data.BusinessServices.Select(bs => new BusinessServiceItem( 
                            bs.BusinessServiceId.Value,
                            bs.Name,
                            bs.Description ?? "",
                            bs.MaxQuantityPerOrder,
                            bs.Sequence,
                            bs.Price
                        )).ToList() 
                        
                    )
                ),
            error => TypedResults.ValidationProblem(((ValidationError)error).ValidationErrors)
        );
    }

    public override Delegate AsyncHandlerDelegate()
    {
        return AsyncHandler;
    }
}

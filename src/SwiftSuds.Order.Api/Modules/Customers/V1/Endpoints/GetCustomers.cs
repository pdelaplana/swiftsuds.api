using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using SwiftSuds.Application.UseCases.Customers.GetCustomers;
using SwiftSuds.Order.Api.Modules.Common;
using SwiftSuds.Order.Api.Modules.Customers.V1.Models;

namespace SwiftSuds.Order.Api.Modules.Customers.V1.Endpoints;

public class GetCustomers : ApiEndpoint<GetCustomersRequest, Results<Ok<GetCustomersResponse>, ProblemHttpResult>>
{
    public override async Task<Results<Ok<GetCustomersResponse>, ProblemHttpResult>> AsyncHandler(
        GetCustomersRequest request, IMediator mediator)
    {

        var query = new GetCustomersQuery()
        {
           Offset = request.Page,
           Limit = request.Size
        };
        var result = await mediator.Send(query);

        return result.Match<Results<Ok<GetCustomersResponse>, ProblemHttpResult>>(
            data => TypedResults.Ok(
                new GetCustomersResponse(
                    data.Select(c => 
                        new CustomerInfo(
                            c.CustomerId.Value,
                            c.Name, 
                            c.Email,
                            c.Phone,
                            c.Address)).ToList(), 
                    request.Page*request.Size, 
                    request.Size)),
            error => TypedResults.Problem(error.Description)
        );
    }

    public override Delegate AsyncHandlerDelegate()
    {
        return this.AsyncHandler;
    }
}
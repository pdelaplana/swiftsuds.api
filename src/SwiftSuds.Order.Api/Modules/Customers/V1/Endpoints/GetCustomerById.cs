using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using SwiftSuds.Application.UseCases.Customers.GetCustomerById;
using SwiftSuds.Domain.Errors;
using SwiftSuds.Order.Api.Modules.Common;
using SwiftSuds.Order.Api.Modules.Customers.V1.Models;
using System.Reflection;

namespace SwiftSuds.Order.Api.Modules.Customers.V1.Endpoints;

public class GetCustomerById : ApiEndpoint<GetCustomerByIdRequest, Results<Ok<GetCustomerByIdResponse>, ValidationProblem>>
{
    public override async Task<Results<Ok<GetCustomerByIdResponse>, ValidationProblem>> AsyncHandler(GetCustomerByIdRequest request, IMediator mediator)
    {
        var query = new GetCustomerByIdQuery()
        {
            Id = new Guid(request.Id)
        };
        var result = await mediator.Send(query);

        return result.Match<Results<Ok<GetCustomerByIdResponse>, ValidationProblem>>(
            data =>
                TypedResults.Ok(
                    new GetCustomerByIdResponse(
                        new CustomerInfo(
                            data.CustomerId.Value,
                            data.Name,
                            data.Email,
                            data.Phone,
                            data.Address)
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

public record GetCustomerByIdRequest(string Id)
{
    public static ValueTask<GetCustomerByIdRequest?> BindAsync(HttpContext httpContext, ParameterInfo parameter)
    {
        var id = httpContext.Request.RouteValues["id"];

        if (id == null)
        {
            return ValueTask.FromResult<GetCustomerByIdRequest?>(null);
        }
        return ValueTask.FromResult<GetCustomerByIdRequest?>(
            new GetCustomerByIdRequest(id.ToString()!)
        );
    }
}

public record GetCustomerByIdResponse(CustomerInfo CustomerInfo);
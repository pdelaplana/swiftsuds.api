
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using SwiftSuds.Application.UseCases.Customers.GetCustomerByEmail;
using SwiftSuds.Domain.Errors;
using SwiftSuds.Order.Api.Modules.Common;
using SwiftSuds.Order.Api.Modules.Customers.V1.Models;

namespace SwiftSuds.Order.Api.Modules.Customers.V1.Endpoints;

public class GetCustomerByEmail(ILogger<GetCustomerByEmail> logger) : ApiEndpoint<GetCustomerByEmailRequest, Results<Ok<GetCustomerByEmailResponse>, ValidationProblem>>
{
    public override async Task<Results<Ok<GetCustomerByEmailResponse>, ValidationProblem>> AsyncHandler(
        GetCustomerByEmailRequest request, 
        IMediator mediator, ILogger<GetCustomerByEmailRequest> logger)
    {
        logger.LogInformation("Invoking endpoint '{endpoint}' with '{req}'", 
            nameof(GetCustomerByEmail), 
            request);
        
        var query = new GetCustomerByEmailQuery()
        {
            Email = request.Email
        };
        var result = await mediator.Send(query);

        return result.Match<Results<Ok<GetCustomerByEmailResponse>, ValidationProblem>>(
            data =>
                TypedResults.Ok(
                    new GetCustomerByEmailResponse(
                        new CustomerInfo(
                            data.CustomerId.Value,
                            data.Name,
                            data.Email,
                            data.Phone,
                            data.Address)
                        )
                ),
            error => TypedResults.ValidationProblem((error as ValidationError)?.ValidationErrors)
        );
    }


    public override Delegate AsyncHandlerDelegate()
    {
        return AsyncHandler;
    }
}

public record GetCustomerByEmailRequest(string Email);

public record GetCustomerByEmailResponse(CustomerInfo Customer);

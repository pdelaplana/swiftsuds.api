using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using SwiftSuds.Application.UseCases.Customers.CreateCustomer;
using SwiftSuds.Domain.Errors;
using SwiftSuds.Order.Api.Modules.Common;

namespace SwiftSuds.Order.Api.Modules.Customers.V1.Endpoints;

public class CreateCustomer: ApiEndpoint<CreateCustomerRequest, Results<Created<CreateCustomerResponse>, ValidationProblem>>
{
    public override async Task<Results<Created<CreateCustomerResponse>,ValidationProblem>> AsyncHandler(
        CreateCustomerRequest request, IMediator mediator, ILogger<CreateCustomerRequest> logger)
    {
        logger.LogInformation("Invoking endpoint '{endpoint}' with '{req}'", 
            nameof(CreateCustomer), 
            request);

        var command = new CreateCustomerCommand()
        {
            Name = request.Name,
            Email = request.Email,
            Phone = request.Phone,
            Address = request.Address
        };
        var result = await mediator.Send(command);

        return result.Match<Results<Created<CreateCustomerResponse>, ValidationProblem>>(
            customer =>
            {
                var response = new CreateCustomerResponse(
                    customer.CustomerId.Value,
                    customer.Name,
                    customer.Email,
                    customer.Phone,
                    customer.Address);

                return TypedResults.Created($"{response.CustomerId}", response);

            },
            error => TypedResults.ValidationProblem(((ValidationError)error).ValidationErrors)
            
        );
    }

    public override Delegate AsyncHandlerDelegate()
    {
        return AsyncHandler;
    }
}


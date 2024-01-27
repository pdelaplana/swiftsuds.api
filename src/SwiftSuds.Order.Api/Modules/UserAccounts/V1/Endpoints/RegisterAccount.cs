using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using SwiftSuds.Application.UseCases.Registration.RegisterAccount;
using SwiftSuds.Application.UseCases.UserAccounts.GetUserAccountByEmail;
using SwiftSuds.Domain.Errors;
using SwiftSuds.Order.Api.Modules.Common;

namespace SwiftSuds.Order.Api.Modules.UserAccounts.V1.Endpoints;

public class RegisterAccount : ApiEndpoint<RegisterAccountRequest, Results<Created<RegisterAccountResponse>, Conflict<string>, ValidationProblem>>
{
    public override async Task<Results<Created<RegisterAccountResponse>, Conflict<string>, ValidationProblem>> AsyncHandler(
        RegisterAccountRequest request, IMediator mediator, ILogger<RegisterAccountRequest> logger)
    {
        logger.LogInformation("Invoking endpoint '{endpoint}' with '{req}'",
            nameof(RegisterAccount),
            request);

        var query = new GetUserAccountByEmailQuery { Email = request.Email };
        var userAccount = await mediator.Send(query);
        if (userAccount.IsOk)
        { 
            if (userAccount.Value.AccountType == request.AccountType)
                return TypedResults.Conflict("Account exists");
        }

        var registerAccountCommand = new RegisterAccountCommand()
        {
            Name = request.Name,
            Email = request.Email,
            Phone = request.Phone,
            Address = request.Address,
            AccountType = request.AccountType, 
            
        };
        var result = await mediator.Send(registerAccountCommand);

        return result.Match<Results<Created<RegisterAccountResponse>, Conflict<string>, ValidationProblem>>(
            customer =>
            {
                var response = new RegisterAccountResponse(result.Value.Email);

                return TypedResults.Created($"{response.Email}", response);

            },
            error => TypedResults.ValidationProblem(((ValidationError)error).ValidationErrors)

        );
    }

    public override Delegate AsyncHandlerDelegate()
    {
        return AsyncHandler;
    }
}

using Carter;
using SwiftSuds.Order.Api.Modules.Common;
using SwiftSuds.Order.Api.Modules.UserAccounts.V1.Endpoints;

namespace SwiftSuds.Order.Api.Modules.UserAccounts.V1;

public class UserAccountsModule: ICarterModule
{

    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v1/accounts");

        group.MapPost("/register", EndpointHandlerFactory.CreateHandler<RegisterAccount>())
            .WithName("RegisterAccount");

        group
            .WithTags("Accounts (v1)")
            .WithOpenApi();
    }
}

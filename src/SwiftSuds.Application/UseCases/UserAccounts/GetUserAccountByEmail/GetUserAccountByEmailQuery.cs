using MediatR;
using SwiftSuds.Domain.Entities.UserAccounts;
using SwiftSuds.Domain.Errors;

namespace SwiftSuds.Application.UseCases.UserAccounts.GetUserAccountByEmail;
public class GetUserAccountByEmailQuery: IRequest<Result<UserAccount, DomainError>>
{
    public string Email { get; set; } = null!;
}

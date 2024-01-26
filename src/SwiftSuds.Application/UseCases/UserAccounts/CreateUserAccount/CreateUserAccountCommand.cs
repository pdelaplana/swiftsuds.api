using MediatR;
using SwiftSuds.Domain.Entities.UserAccounts;
using SwiftSuds.Domain.Errors;

namespace SwiftSuds.Application.UseCases.UserAccounts.CreateUserAccount;
public class CreateUserAccountCommand : IRequest<Result<UserAccount,DomainError>>
{
    public string Email { get; set; } = null!;
    public AccountType AccountType { get; set; }

}

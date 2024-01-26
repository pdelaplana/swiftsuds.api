using MediatR;
using SwiftSuds.Domain.Entities.UserAccounts;
using SwiftSuds.Domain.Errors;
using SwiftSuds.Domain.ValueObjects;

namespace SwiftSuds.Application.UseCases.Registration.RegisterAccount;
public class RegisterAccountCommand : IRequest<Result<UserAccount, DomainError>>
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public Address Address { get; set; } = null!;
    public AccountType AccountType { get; set; }
}

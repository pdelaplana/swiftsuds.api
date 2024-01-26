using FluentValidation;
using MediatR;
using SwiftSuds.Application.Abstractions.Repositories.ReadOnly;
using SwiftSuds.Domain.Entities.UserAccounts;
using SwiftSuds.Domain.Errors;

namespace SwiftSuds.Application.UseCases.UserAccounts.GetUserAccountByEmail;
internal class GetUserAccountByEmailQueryHandler(
        IUserAccountReadOnlyRepository userAccountRepository,
        IValidator<GetUserAccountByEmailQuery> validator)
    : IRequestHandler<GetUserAccountByEmailQuery, Result<UserAccount, DomainError>>
{
    public async Task<Result<UserAccount, DomainError>> Handle(GetUserAccountByEmailQuery request, CancellationToken cancellationToken)
    {
        var (isValid, errors) = await validator.ValidateAndReturnErrorsAsync(request, cancellationToken);
        if (!isValid) return errors!;

        var userAccount = await userAccountRepository.GetUserAccountByEmailAsync(request.Email);
        return userAccount== null ? new UserAccountNotFound() : userAccount;
    }
}

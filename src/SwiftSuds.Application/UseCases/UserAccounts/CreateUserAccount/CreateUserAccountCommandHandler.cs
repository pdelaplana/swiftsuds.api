using FluentValidation;
using MediatR;
using SwiftSuds.Application.Abstractions;
using SwiftSuds.Application.Abstractions.Repositories.Write;
using SwiftSuds.Domain.Entities.UserAccounts;
using SwiftSuds.Domain.Errors;

namespace SwiftSuds.Application.UseCases.UserAccounts.CreateUserAccount;
public class CreateUserAccountCommandHandler(
        IUserAccountWriteRepository userAccountRepository, 
        IUnitOfWork unitOfWork, 
        IValidator<CreateUserAccountCommand> validator)
    : IRequestHandler<CreateUserAccountCommand, Result<UserAccount, DomainError>>
{
    public async Task<Result<UserAccount, DomainError>> Handle(CreateUserAccountCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return new ValidationError(validationResult.ToDictionary());
        }

        var userAccount = new UserAccount
        {
            UserAccountId = new UserAccountId(Guid.NewGuid()),
            Email = request.Email,
            AccountType = request.AccountType
        };
           
        userAccount = userAccountRepository.Add(userAccount);
        await unitOfWork.CommitAsync();

        return userAccount;
    }
}

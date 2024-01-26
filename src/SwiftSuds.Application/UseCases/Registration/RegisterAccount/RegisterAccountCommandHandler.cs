using FluentValidation;
using MediatR;
using SwiftSuds.Application.Abstractions.Repositories;
using SwiftSuds.Application.Abstractions;
using SwiftSuds.Application.Abstractions.Repositories.Write;
using SwiftSuds.Domain.Entities.Customers;
using SwiftSuds.Domain.Entities.UserAccounts;
using SwiftSuds.Domain.Errors;

namespace SwiftSuds.Application.UseCases.Registration.RegisterAccount;
public class RegisterAccountCommandHandler(
    ICustomerRepository customerRepository, 
    IUserAccountWriteRepository userAccountRepository,
    IUnitOfWork unitOfWork, 
    IValidator<RegisterAccountCommand> validator)
    : IRequestHandler<RegisterAccountCommand, Result<UserAccount, DomainError>>
{
    public async Task<Result<UserAccount, DomainError>> Handle(RegisterAccountCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return new ValidationError(validationResult.ToDictionary());
        }

        switch (request.AccountType)
        {
            case AccountType.Customer:
                customerRepository.Add(new Customer(
                    new CustomerId(Guid.NewGuid()),
                    request.Name,
                    request.Email,
                    request.Phone,
                    request.Address
                ));
                break;
            case AccountType.Driver:
                break;
            case AccountType.BusinessOwner:
                break;
            case AccountType.BusinessEmployee:
                break;
        }

        var userAccount = userAccountRepository.Add(new UserAccount()
        {
            UserAccountId = new UserAccountId(Guid.NewGuid()),
            AccountType = request.AccountType,
            Email = request.Email
        });

        await unitOfWork.CommitAsync();

        return userAccount;

    }
}

using FluentValidation;
using MediatR;
using SwiftSuds.Application.Abstractions.Repositories;
using SwiftSuds.Domain.Entities.Customers;
using SwiftSuds.Domain.Errors;


namespace SwiftSuds.Application.UseCases.Customers.GetCustomerByEmail;
public class GetCustomerByEmailQueryHandler(
        ICustomerRepository customerRepository,
        IValidator<GetCustomerByEmailQuery> validator) 
    : IRequestHandler<GetCustomerByEmailQuery, Result<Customer, DomainError>>
{
    public async Task<Result<Customer, DomainError>> Handle(GetCustomerByEmailQuery request, CancellationToken cancellationToken)
    {
        var (isValid, errors) = await validator.ValidateAndReturnErrorsAsync(request, cancellationToken);
        if (!isValid) return errors!;

        var customer = await customerRepository.GetCustomerByEmailAsync(request.Email);
        return customer == null ? new CustomerNotFound(): customer;

    }
}

using FluentValidation;
using MediatR;
using SwiftSuds.Application.Abstractions.Repositories;
using SwiftSuds.Domain.Entities.Customers;
using SwiftSuds.Domain.Errors;


namespace SwiftSuds.Application.UseCases.Customers.GetCustomerById;
public class GetCustomerByIdQueryHandler(
        ICustomerRepository customerRepository,
        IValidator<GetCustomerByIdQuery> validator) 
    : IRequestHandler<GetCustomerByIdQuery, Result<Customer, DomainError>>
{
    public async Task<Result<Customer, DomainError>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var (isValid, errors) = await validator.ValidateAndReturnErrorsAsync(request, cancellationToken);
        if (!isValid) return errors!;

        var customer = await customerRepository.GetByIdAsync(new CustomerId(request.Id));
        return customer == null ? new CustomerNotFound() : customer;

    }
}

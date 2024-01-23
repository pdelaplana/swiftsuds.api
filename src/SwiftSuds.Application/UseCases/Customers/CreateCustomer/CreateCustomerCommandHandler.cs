using FluentValidation;
using MediatR;
using SwiftSuds.Application.Abstractions;
using SwiftSuds.Application.Abstractions.Repositories;
using SwiftSuds.Domain.Entities.Customers;
using SwiftSuds.Domain.Errors;

namespace SwiftSuds.Application.UseCases.Customers.CreateCustomer;
public class CreateCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork, IValidator<CreateCustomerCommand> validator) 
    : IRequestHandler<CreateCustomerCommand, Result<Customer,DomainError>>
{
    public async Task<Result<Customer,DomainError>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {

        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return new ValidationError(validationResult.ToDictionary() );
        }
        var customer = new Customer(
            new CustomerId(Guid.NewGuid()), 
            request.Name, 
            request.Email, 
            request.Phone, 
            request.Address);
        customerRepository.Add(customer);
        await unitOfWork.CommitAsync();

        return customer;

    }
}

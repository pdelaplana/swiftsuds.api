using FluentValidation;
using MediatR;
using SwiftSuds.Application.Abstractions.Repositories;
using SwiftSuds.Domain.Entities.Customers;
using SwiftSuds.Domain.Errors;

namespace SwiftSuds.Application.UseCases.Customers.GetCustomers;
public class GetCustomersQueryHandler(ICustomerRepository customerRepository, IValidator<GetCustomersQuery> validator) 
    : IRequestHandler<GetCustomersQuery, Result<ICollection<Customer>, DomainError>>
{
    public async Task<Result<ICollection<Customer>, DomainError>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return new ValidationError(validationResult.ToDictionary());
        }
        return (await customerRepository.GetCustomersAsync(request.Offset, request.Limit)).ToList();
    }
}

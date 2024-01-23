using FluentValidation;
using FluentValidation.Results;
using Moq;
using SwiftSuds.Application.Abstractions.Repositories;
using SwiftSuds.Application.UseCases.Customers.GetCustomerById;
using SwiftSuds.Domain.Entities.Customers;
using SwiftSuds.Domain.ValueObjects;

namespace SwiftSuds.Application.Tests.CustomerTests;
public class GetCustomersByIdTests
{
    private readonly Mock<ICustomerRepository> _mockCustomerRepository = new();
    private readonly Mock<IValidator<GetCustomerByIdQuery>> _mockValidator = new();

    [Fact]
    public async Task GetCustomersByIdQueryHandler_Should_ReturnCustomer_WhenIdIsValidAndIsForCustomer()
    {
        // arrange 
        _mockCustomerRepository.Setup(r =>
                r.GetByIdAsync(It.IsAny<EntityId>()))
            .ReturnsAsync(
                new Customer(
                    new CustomerId(Guid.NewGuid()),
                    "John Doe",
                    "john@mail.com",
                    "909090",
                    new Address() { StreetAddress1 = "1 Main Street" }
                ));

        var validationResults = new Mock<ValidationResult>();
        validationResults.Setup(v => v.IsValid).Returns(true);

        _mockValidator.Setup(x =>
                x.ValidateAsync(
                    It.IsAny<GetCustomerByIdQuery>(),
                    It.IsAny<CancellationToken>())
            )
            .ReturnsAsync(validationResults.Object);
        var query = new GetCustomerByIdQuery() { Id = Guid.NewGuid() };
        var handler = new GetCustomerByIdQueryHandler(_mockCustomerRepository.Object, _mockValidator.Object);

        // act
        var result = await handler.Handle(query, default);

        // assert
        Assert.NotNull(result.Value);

    }
}

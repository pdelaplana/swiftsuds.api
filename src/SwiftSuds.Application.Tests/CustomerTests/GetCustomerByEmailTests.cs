using FluentValidation;
using Moq;
using SwiftSuds.Application.Abstractions.Repositories;
using SwiftSuds.Application.UseCases.Customers.GetCustomerByEmail;
using SwiftSuds.Domain.Entities.Customers;
using SwiftSuds.Domain.ValueObjects;
using FluentValidation.Results;

namespace SwiftSuds.Application.Tests.CustomerTests;
public class GetCustomerByEmailTests
{
    private readonly Mock<ICustomerRepository> _mockCustomerRepository = new();
    private readonly Mock<IValidator<GetCustomerByEmailQuery>> _mockValidator = new();

    [Fact]
    public async Task GetCustomersByEmailQueryHandler_Should_ReturnCustomer_WhenEmailIsValidAndIsForCustomer()
    {
        // arrange 
        _mockCustomerRepository.Setup(r =>
            r.GetCustomerByEmailAsync(It.IsAny<string>()))
            .ReturnsAsync(new Customer(
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
                    It.IsAny<GetCustomerByEmailQuery>(),
                    It.IsAny<CancellationToken>())
            )
            .ReturnsAsync(validationResults.Object);
        var query = new GetCustomerByEmailQuery() { Email = "john@mail.com" };
        var handler = new GetCustomerByEmailQueryHandler(_mockCustomerRepository.Object, _mockValidator.Object);

        // act
        var result = await handler.Handle(query, default);

        // assert
        Assert.NotNull(result.Value);

    }
}

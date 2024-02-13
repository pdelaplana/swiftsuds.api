using FluentValidation;
using FluentValidation.Results;
using Moq;
using SwiftSuds.Application.Abstractions.Repositories;
using SwiftSuds.Application.UseCases.Customers.GetCustomers;
using SwiftSuds.Domain.Entities.Customers;
using SwiftSuds.Domain.Errors;
using SwiftSuds.Domain.ValueObjects;

namespace SwiftSuds.Application.Tests.CustomerTests;

public class GetCustomersTests
{
    private readonly Mock<ICustomerRepository> _mockCustomerRepository = new();
    private readonly Mock<IValidator<GetCustomersQuery>> _mockValidator = new();

    private void SetupValidator(bool isValid)
    {
        var validationResults = new Mock<ValidationResult>();
        validationResults.Setup(v => v.IsValid).Returns(isValid);
        _mockValidator.Setup(x =>
           x.ValidateAsync(
               It.IsAny<GetCustomersQuery>(),
               It.IsAny<CancellationToken>())
           )
           .ReturnsAsync(validationResults.Object);
    }

    [Fact]
    public async Task GetCustomersQueryHandler_Should_ReturnListOfCustomers_WhenInvoked()
    {
        // arrange 
        SetupValidator(true);
        _mockCustomerRepository.Setup(r => 
            r.GetCustomersAsync(It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(new List<Customer>()
            {
                new (
                    new CustomerId(Guid.NewGuid()), 
                    "John Doe", 
                    "john@mail.com", 
                    "909090", 
                    new Address(){ StreetAddress1 = "1 Main Street" }
                    ),
            });
        var query = new GetCustomersQuery { Offset = 0, Limit = 100 };
        var handler = new GetCustomersQueryHandler(_mockCustomerRepository.Object,_mockValidator.Object);

        // act
        var result = await handler.Handle(query, default);

        // assert
        Assert.NotEmpty(result.Value);

    }

    [Fact]
    public async Task GetCustomersQueryHandler_Should_ReturnValidationError_WhenOffsetIsLessThanZero()
    {
        // arrange 
        SetupValidator(false);

        var query = new GetCustomersQuery { Offset = 0, Limit = 100 };
        var handler = new GetCustomersQueryHandler(_mockCustomerRepository.Object, _mockValidator.Object);

        // act
        var result = await handler.Handle(query, default);

        // assert
        Assert.IsType<ValidationError>(result.Error);

    }

    

}

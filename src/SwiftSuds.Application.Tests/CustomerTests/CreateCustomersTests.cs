using FluentValidation;
using FluentValidation.Results;
using Moq;
using SwiftSuds.Application.Abstractions;
using SwiftSuds.Application.Abstractions.Repositories;
using SwiftSuds.Application.UseCases.Customers.CreateCustomer;
using SwiftSuds.Domain.Errors;
using SwiftSuds.Domain.ValueObjects;

namespace SwiftSuds.Application.Tests.CustomerTests;

public class CreateCustomersTests
{
    private readonly Mock<ICustomerRepository> _mockCustomerRepository = new();
    private readonly Mock<IUnitOfWork> _mockUnitOfWork = new();
    private readonly Mock<IValidator<CreateCustomerCommand>> _mockValidator = new();

    private void SetupValidation(bool validation)
    {
        var validationResults = new Mock<ValidationResult>();
        validationResults.Setup(v => v.IsValid).Returns(validation);
        _mockValidator.Setup(x =>
            x.ValidateAsync(
                It.IsAny<CreateCustomerCommand>(),
                It.IsAny<CancellationToken>())
            )
            .ReturnsAsync(validationResults.Object);
    }

    [Fact]
    public async Task CreateCustomerCommandHandler_Should_ReturnNewCustomer_WhenAllRequiredValuesAreProvided()
    {
        // arrange
        SetupValidation(true);
        var command = new CreateCustomerCommand()
        {
            Name = "John Doe",
            Email = "test@mail.com",
            Phone = "0000",
            Address = new Address() { StreetAddress1 = "1 Main Street" }
        };

        var handler = new CreateCustomerCommandHandler(
            _mockCustomerRepository.Object, _mockUnitOfWork.Object, _mockValidator.Object);

        // act
        var result = await handler.Handle(command, default);

        // assert
        Assert.NotNull(result.Value);
    }

    [Fact]
    public async Task CreateCustomerCommandHandler_Should_ReturnValidationError_WhenEmailIsMissing()
    {
        // arrange
        SetupValidation(false);        
        var command = new CreateCustomerCommand()
        {
            Name = "John Doe",
            Email = "",
            Phone = "0000",
            Address = new Address() { StreetAddress1 = "1 Main Street" }
        };

        var handler = new CreateCustomerCommandHandler(
            _mockCustomerRepository.Object, _mockUnitOfWork.Object, _mockValidator.Object);

        // act
        var result = await handler.Handle(command, default);
        
        // assert
        Assert.IsType<ValidationError>(result.Error);
        
    }
}
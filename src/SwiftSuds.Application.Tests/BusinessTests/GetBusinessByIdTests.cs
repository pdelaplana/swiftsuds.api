using FluentValidation;
using FluentValidation.Results;
using Moq;
using SwiftSuds.Application.Abstractions.Repositories.ReadOnly;
using SwiftSuds.Application.UseCases.Businesses.GetBusinessById;
using SwiftSuds.Domain.Entities.Businesses;
using SwiftSuds.Domain.ValueObjects;
using System.Linq.Expressions;

namespace SwiftSuds.Application.Tests.BusinessTests;
public class GetBusinessByIdTests
{
    private readonly Mock<IBusinessReadOnlyRepository> _mockBusinessReadOnlyRepository = new();
    private readonly Mock<IValidator<GetBusinessByIdQuery>> _mockValidator = new();

    private void SetupValidator(bool isValid)
    {
        var validationResults = new Mock<ValidationResult>();
        validationResults.Setup(v => v.IsValid).Returns(isValid);
        _mockValidator.Setup(x =>
           x.ValidateAsync(
               It.IsAny<GetBusinessByIdQuery>(),
               It.IsAny<CancellationToken>())
           )
           .ReturnsAsync(validationResults.Object);
    }

    [Fact]
    public async Task GetBusinessByIdQueryHandler_ShouldReturnBusiness_WhenInvoked()
    {
        // arrange
        SetupValidator(true);
        _mockBusinessReadOnlyRepository
            .Setup(r => r.GetBusinessByIdAsync(It.IsAny<BusinessId>(), It.IsAny<Expression<Func<Business, object?>>[]?>()))
            .ReturnsAsync(
                new Business(
                    new BusinessId(Guid.NewGuid()),
                    "Test Business",
                    new Address() { StreetAddress1 = "1 Main Street" },
                    0.0
                ));
        var query = new GetBusinessByIdQuery { BusinessId = Guid.NewGuid() };
        var handler = new GetBusinessByIdQueryHandler(_mockBusinessReadOnlyRepository.Object, _mockValidator.Object);

        // act
        var result = await handler.Handle(query, default);

        // assert
        Assert.NotNull(result.Value);
    }
}

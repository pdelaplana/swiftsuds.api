using FluentValidation;
using FluentValidation.Results;
using Moq;
using SwiftSuds.Application.Abstractions.Repositories.ReadOnly;
using SwiftSuds.Application.UseCases.Businesses.GetBusinesses;
using SwiftSuds.Domain.Entities.Businesses;
using SwiftSuds.Domain.ValueObjects;

namespace SwiftSuds.Application.Tests.BusinessTests;
public class GetBusinessesTests
{
    private readonly Mock<IBusinessReadOnlyRepository> _mockBusinessReadOnlyRepository = new();
    private readonly Mock<IValidator<GetBusinessesQuery>> _mockValidator = new();

    private void SetupValidator(bool isValid)
    {
        var validationResults = new Mock<ValidationResult>();
        validationResults.Setup(v => v.IsValid).Returns(isValid);
        _mockValidator.Setup(x =>
           x.ValidateAsync(
               It.IsAny<GetBusinessesQuery>(),
               It.IsAny<CancellationToken>())
           )
           .ReturnsAsync(validationResults.Object);
    }

    [Fact]
    public async Task GetBusinessQueryHandler_Should_ReturnListOfBusinesses_WhenInvoked()
    {
        // arange
        SetupValidator(true);
        _mockBusinessReadOnlyRepository
            .Setup(r => r.GetBusinessesAsync(It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(new List<Business>()
            {
                new (
                    new BusinessId(Guid.NewGuid()),
                    "Test Business",
                    new Address(){ StreetAddress1 = "1 Main Street" },
                    0.0
                    ),
            });
        var query = new GetBusinessesQuery { Offset = 0, Limit = 100 };
        var handler = new GetBusinessesQueryHandler(_mockBusinessReadOnlyRepository.Object, _mockValidator.Object);

        // act
        var result = await handler.Handle(query, default);

        // assert
        Assert.NotEmpty(result.Value);
    }
}

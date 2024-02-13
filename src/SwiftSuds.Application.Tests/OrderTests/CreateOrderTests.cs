using FluentValidation;
using Moq;
using SwiftSuds.Application.Abstractions;
using SwiftSuds.Application.Abstractions.Repositories.Write;
using SwiftSuds.Application.Abstractions.Repositories.ReadOnly;
using SwiftSuds.Application.UseCases.Orders.CreateOrder;
using FluentValidation.Results;
using SwiftSuds.Domain.ValueObjects;
using SwiftSuds.Domain.Entities.Businesses;
using SwiftSuds.Domain.Entities.Customers;
using SwiftSuds.Domain.Entities.BusinessServices;
using SwiftSuds.Domain.Entities.Orders;

namespace SwiftSuds.Application.Tests.OrderTests;
public class CreateOrderTests
{
    private readonly Mock<IOrderWriteRepository> _mockOrderRepository = new();
    private readonly Mock<IBusinessServiceReadOnlyRepository> _mockBusinessServiceRepository = new();

    private readonly Mock<IUnitOfWork> _mockUnitOfWork = new();
    private readonly Mock<IValidator<CreateOrderCommand>> _mockValidator = new();

    private void Setup(bool setIsValid)
    {
        var validationResults = new Mock<ValidationResult>();
        validationResults.Setup(v => v.IsValid).Returns(setIsValid);
        _mockValidator.Setup(x =>
            x.ValidateAsync(
                It.IsAny<CreateOrderCommand>(),
                It.IsAny<CancellationToken>())
            )
            .ReturnsAsync(validationResults.Object);

        _mockOrderRepository.Setup(r => r.Add(It.IsAny<Order>())).Returns(new Order());
    }

    [Fact]
    public async Task CreateOrderCommandHandler_Should_ReturnNewOrder_WhenAllRequiredValuesAreProvided()
    {
        // arrange
        Setup(true);
        var command = new CreateOrderCommand()
        {
            BusinessId = new BusinessId(Guid.NewGuid()),
            CurrencySymbol = "PHP",
            CustomerId = new CustomerId(Guid.NewGuid()),
            PickupAddress = new Address()
            {
                StreetAddress1 = "1 Main Street"
            },
            DeliveryAddress = new Address()
            {
                StreetAddress1 = "1 Main Street"
            },
            IsPaid = false,
            Items = new List<CreateOrderCommand.OrderItem>() {
                new("Shirts", 5)
            },
            OrderDate = DateTime.Now,
            ScheduledDeliveryDateTimeStart = DateTime.Now,
            ScheduledDeliveryDateTimeEnd = DateTime.Now.AddHours(2),
            ScheduledPickupDateTimeStart = DateTime.Now.AddDays(5),
            ScheduledPickupDateTimeEnd = DateTime.Now.AddDays(5).AddHours(2),
            Services = new List<CreateOrderCommand.OrderService>() {
                new(new BusinessServiceId(Guid.NewGuid()), 1, (decimal)240.00)
            }
        };

        var handler = new CreateOrderCommandHandler(
            _mockOrderRepository.Object, 
            _mockBusinessServiceRepository.Object, 
            _mockUnitOfWork.Object, 
            _mockValidator.Object);

        // act
        var result = await handler.Handle(command, default);

        // assert
        Assert.NotNull(result.Value);
    }

}

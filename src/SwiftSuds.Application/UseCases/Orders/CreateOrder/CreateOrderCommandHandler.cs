using FluentValidation;
using MediatR;
using SwiftSuds.Application.Abstractions;
using SwiftSuds.Domain.Entities.Orders;
using SwiftSuds.Domain.Errors;
using SwiftSuds.Application.Abstractions.Repositories.Write;
using SwiftSuds.Domain.ValueObjects;
using SwiftSuds.Application.Abstractions.Repositories.ReadOnly;

namespace SwiftSuds.Application.UseCases.Orders.CreateOrder;
internal class CreateOrderCommandHandler(
    IOrderWriteRepository orderWriteRepository, 
    IBusinessServiceReadOnlyRepository businessServiceReadOnlyRepository,
    IUnitOfWork unitOfWork, 
    IValidator<CreateOrderCommand> validator) 
    : IRequestHandler<CreateOrderCommand, Result<Order, DomainError>>
{
    public async Task<Result<Order, DomainError>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
       
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return new ValidationError(validationResult.ToDictionary());
        }

        var businessServiceIds = request.Services.Select(s => s.BusinessServiceId).ToArray();
        var businessServices = await businessServiceReadOnlyRepository.GetBusinessServicesByIdsAsync(businessServiceIds);
        var totalPrice = request.Services.Aggregate(0, (total, service) =>
        {
            decimal currentPrice = 0;
            if (service.Price > 0)
            {
                currentPrice = service.Price;
            }
            else
            {
                var servicePrice = businessServices.SingleOrDefault(s => s.BusinessServiceId == service.BusinessServiceId)?.Price;
                if (servicePrice != null) currentPrice = servicePrice.Amount;
            }
            
            total = (int)(total + (currentPrice * service.Quantity));
            return total;
        });
        
        var orderId = new OrderId(Guid.NewGuid());
        var order = new Order(
            orderId,
            DateTime.UtcNow,
            request.BusinessId,
            request.CustomerId,
            0,
            request.PickupAddress,
            request.ScheduledPickupDateTimeStart,
            request.ScheduledPickupDateTimeEnd,
            request.DeliveryAddress,
            request.ScheduledDeliveryDateTimeStart,
            request.ScheduledDeliveryDateTimeEnd,
            request.IsPaid,
            new Money(totalPrice, new Currency(request.CurrencySymbol))
        );

        foreach (var item in request.Items) {
            order.Items.Add(new Domain.Entities.Orders.OrderItem
            {
                OrderItemId = new OrderItemId(Guid.NewGuid()),
                Item = item.Item,
                Quantity = item.Quantity
            });
        }

        foreach (var service in request.Services)
        {
            order.Services.Add(new Domain.Entities.Orders.OrderService
            {
                OrderServiceId = new OrderServiceId(Guid.NewGuid()),
                BusinessServiceId = service.BusinessServiceId,
                OrderId = orderId,
                FinalPrice = new Money(service.Price, new Currency(request.CurrencySymbol)),
                Quantity = service.Quantity
            });
        }

        order = orderWriteRepository.Add(order);

        await unitOfWork.CommitAsync();
        
        return order;
       
    }
}

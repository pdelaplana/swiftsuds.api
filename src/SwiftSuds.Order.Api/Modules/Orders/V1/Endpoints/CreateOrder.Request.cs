using SwiftSuds.Domain.ValueObjects;

namespace SwiftSuds.Order.Api.Modules.Orders.V1.Endpoints;

public record CreateOrderRequest(
    Guid CustomerId,
    Guid BusinessId,
    Address PickupAddress,
    DateTime ScheduledPickupDateTimeStart,
    DateTime ScheduledPickupDateTimeEnd,
    Address DeliveryAddress,
    DateTime ScheduledDeliveryDateTimeStart,
    DateTime ScheduledDeliveryDateTimeEnd,
    bool IsPaid,
    string CurrencySymbol,
    IList<CreateOrderRequestItem> Items,
    IList<CreateOrderRequestService> Services
    );

public record CreateOrderRequestItem(string Item, int Quantity);

public record CreateOrderRequestService(Guid BusinessServiceId, int Quantity, decimal Price);

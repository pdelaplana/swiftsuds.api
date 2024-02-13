using MediatR;
using SwiftSuds.Domain.Entities.Businesses;
using SwiftSuds.Domain.Entities.BusinessServices;
using SwiftSuds.Domain.Entities.Customers;
using SwiftSuds.Domain.Entities.Orders;
using SwiftSuds.Domain.Errors;
using SwiftSuds.Domain.ValueObjects;

namespace SwiftSuds.Application.UseCases.Orders.CreateOrder;
public class CreateOrderCommand : IRequest<Result<Order, DomainError>>
{
    public record OrderService(BusinessServiceId BusinessServiceId, int Quantity, decimal Price);
    public record OrderItem(string Item, int Quantity);

    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public BusinessId BusinessId { get; set; } = null!;
    public CustomerId CustomerId { get; set; } = null!;
    public Address PickupAddress { get; set; } = null!;
    public DateTime ScheduledPickupDateTimeStart { get; set; } = DateTime.UtcNow;
    public DateTime ScheduledPickupDateTimeEnd { get; set; } = DateTime.UtcNow;
    public Address DeliveryAddress { get; set; } = null!;
    public DateTime ScheduledDeliveryDateTimeStart {get;set; } = DateTime.UtcNow;
    public DateTime ScheduledDeliveryDateTimeEnd { get;set; } = DateTime.UtcNow;
    public bool IsPaid { get; set; } = false;
    public string CurrencySymbol { get; set; } = "USD";
    public IList<OrderItem> Items { get; set; } = new List<OrderItem>();
    public IList<OrderService> Services { get; set; } = new List<OrderService>();

}





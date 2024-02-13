using SwiftSuds.Domain.Entities.BusinessServices;
using SwiftSuds.Domain.ValueObjects;

namespace SwiftSuds.Domain.Entities.Orders;
public sealed class OrderService
{
    public OrderServiceId OrderServiceId { get; set; } = null!;
    public OrderId OrderId { get; set; } = null!;
    public Order Order { get; set; } = null!;
    public BusinessServiceId BusinessServiceId { get; set; } = null!;
    public BusinessService BusinessService { get; set; } = null!;
    public Money FinalPrice { get; set; } = new Money(0, Currency.Php);
    public int Quantity { get; set; } = 0;
}

using SwiftSuds.Domain.Entities.Businesses;
using SwiftSuds.Domain.Entities.BusinessServices;
using SwiftSuds.Domain.Entities.Customers;
using SwiftSuds.Domain.Entities.Drivers;
using SwiftSuds.Domain.ValueObjects;

namespace SwiftSuds.Domain.Entities.Orders;
public sealed class Order
{
    public Order() { }
    public Order(OrderId orderId,
        DateTime orderDate,
        int pieceCount,
        DateTime? scheduledPickupDateTimeStart,
        DateTime? scheduledPickupDateTimeEnd,
        DateTime? scheduledDeliveryDateTimeStart,
        DateTime? scheduledDeliveryDateTimeEnd,
        bool isPaid) 
    {
        OrderId = orderId;
        OrderDate = orderDate;
        PieceCount = pieceCount;    
        ScheduledDeliveryDateTimeStart = scheduledDeliveryDateTimeStart;
        ScheduledDeliveryDateTimeEnd = scheduledDeliveryDateTimeEnd;
        ScheduledPickupDateTimeStart = scheduledPickupDateTimeStart;
        ScheduledPickupDateTimeEnd = scheduledPickupDateTimeEnd;
        IsPaid = isPaid;
    }

    public Order(OrderId orderId,
        DateTime orderDate,
        BusinessId businessId,
        CustomerId customerId,
        int pieceCount,
        Address pickupAddress,
        DateTime? scheduledPickupDateTimeStart,
        DateTime? scheduledPickupDateTimeEnd,
        Address deliveryAddress,
        DateTime? scheduledDeliveryDateTimeStart,
        DateTime? scheduledDeliveryDateTimeEnd,
        bool isPaid,
        Money amountDue): this(
            orderId, 
            orderDate, 
            pieceCount, 
            scheduledPickupDateTimeStart,
            scheduledPickupDateTimeEnd,
            scheduledDeliveryDateTimeStart, 
            scheduledDeliveryDateTimeEnd,
            isPaid)
    {
        BusinessId = businessId;
        CustomerId = customerId;
        PickupAddress = pickupAddress;
        DeliveryAddress = deliveryAddress;
        AmountDue = amountDue;
    }

    public OrderId OrderId { get; set; } = null!;
    public DateTime OrderDate { get; set; } = default;
    public BusinessId BusinessId { get; set; } = null!;
    public Business Business { get; set; } = null!;
    public CustomerId CustomerId { get; set; } = null!;
    public Customer Customer { get; set; } = null!;
    public int PieceCount { get; set; } = 0;
    public Address PickupAddress { get; set; } = default!;
    public DateTime? ScheduledPickupDateTimeStart{ get; set; } = null!;
    public DateTime? ScheduledPickupDateTimeEnd { get; set; } = null!;
    public DateTime ActualPickupDateTime { get; set; } = DateTime.MinValue;
    public DriverId? PickupDriverId { get; set; } = default!;
    public Driver? PickupDriver { get; set; } = null!;
    public Address DeliveryAddress { get; set; } = null!;    
    public DateTime? ScheduledDeliveryDateTimeStart { get; set; } = null!;
    public DateTime? ScheduledDeliveryDateTimeEnd { get; set; } = null!;
    public DateTime ActualDeliveryDateTime { get; set; } = DateTime.MinValue;
    public DriverId? DeliveryDriverId { get; set; } = null!;
    public Driver? DeliveryDriver { get; set; } = null!;
    public bool IsPaid { get; set; } = false;
    public Money AmountDue { get; set; } = null!;
    public Money? AmountPaid { get; set; } = null!;
    public bool IsCancelled { get; set; } = false;
    public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    public ICollection<OrderService> Services { get; set; } = new List<OrderService>();

    
}

using SwiftSuds.Domain.Entities.Businesses;
using SwiftSuds.Domain.Entities.BusinessServices;
using SwiftSuds.Domain.Entities.Customers;
using SwiftSuds.Domain.Entities.Drivers;
using SwiftSuds.Domain.ValueObjects;

namespace SwiftSuds.Domain.Entities.Orders;
public class Order
{

    private Order(OrderId orderId,
        DateTime orderDate,
        int pieceCount,
        DateTime? scheduledPickupDateTime,
        DateTime actualPickupDateTime,
        DateTime? scheduledDeliveryDateTime,
        DateTime actualDeliveryDateTime,
        bool isPaid) 
    {
        OrderId = orderId;
        OrderDate = orderDate;
        PieceCount = pieceCount;    
        ScheduledDeliveryDateTime = scheduledDeliveryDateTime;
        ActualDeliveryDateTime = actualDeliveryDateTime;
        ScheduledPickupDateTime = scheduledPickupDateTime; 
        ActualPickupDateTime = actualPickupDateTime;
        IsPaid = isPaid;
    }

    public Order(OrderId orderId,
        DateTime orderDate,
        BusinessId businessId,
        CustomerId customerId,
        BusinessServiceId businessServiceId,
        int pieceCount,
        DateTime? scheduledPickupDateTime,
        DateTime actualPickupDateTime,
        DriverId pickupDriverId,
        DateTime? scheduledDeliveryDateTime,
        DateTime actualDeliveryDateTime,
        DriverId deliveryDriverId,
        bool isPaid,
        Money amountDue): this(orderId, orderDate, pieceCount, scheduledPickupDateTime, actualPickupDateTime, scheduledDeliveryDateTime, actualDeliveryDateTime, isPaid)
    {
        BusinessId = businessId;
        CustomerId = customerId;
        BusinessServiceId = businessServiceId;
        PickupDriverId = pickupDriverId;
        DeliveryDriverId = deliveryDriverId;
        AmountDue = amountDue;
    }

    public OrderId OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public BusinessId BusinessId { get; set;}
    public Business Business { get; set; }
    public CustomerId CustomerId { get; set;}
    public Customer Customer { get; set; }
    public BusinessServiceId BusinessServiceId { get; set; }
    public BusinessService BusinessService { get; set; }
    public int PieceCount { get; set; }
    public DateTime? ScheduledPickupDateTime { get; set; }
    public DateTime ActualPickupDateTime { get; set; } 
    public DriverId PickupDriverId { get; set; } 
    public Driver PickupDriver { get; set; }
    public DateTime? ScheduledDeliveryDateTime { get; set; } 
    public DateTime ActualDeliveryDateTime { get; set; } 
    public DriverId DeliveryDriverId { get; set; } 
    public Driver DeliveryDriver { get; set; }
    public bool IsPaid { get; set; } 
    public Money AmountDue { get; set;  } 
    
}

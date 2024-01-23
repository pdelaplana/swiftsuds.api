using SwiftSuds.Domain.Entities.Orders;
using SwiftSuds.Domain.Entities.Users;
using SwiftSuds.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwiftSuds.Domain.Entities.Drivers;
public sealed class Driver: User
{
    public Driver()
    {
    }

    public Driver(DriverId driverId,
        string name,
        string email,
        string phone,
        string driversLicense,
        Vehicle vehicle,
        Address address) 
    {
        DriverId = driverId;
        Name = name;
        Email = email;
        DriversLicense = driversLicense;
        Vehicle = vehicle;
        Address = address;
    }

    public DriverId DriverId { get; set; } = null!;
    
    public required Vehicle Vehicle { get; set; } = null!;
    
    [Column(TypeName="nvarchar(20)")]
    public string DriversLicense { get; set; } = null!;
    public ICollection<Order> PickupOrders { get; set; } = null!;
    public ICollection<Order> DeliveryOrders { get; set; } = null!;
}

using SwiftSuds.Domain.Entities.BusinessEmployees;
using SwiftSuds.Domain.Entities.BusinessServices;
using SwiftSuds.Domain.Entities.Orders;
using SwiftSuds.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwiftSuds.Domain.Entities.Businesses;
public sealed class Business
{
    public Business()
    {
    }

    public Business(BusinessId businessId, string name, Address address, double serviceRadius)
    {
        BusinessId = businessId;
        Name = name;
        Address = address;
        ServiceRadius = serviceRadius;
    }

    public BusinessId BusinessId { get; set; } = null!;

    [Column(TypeName = "nvarchar(50)")]
    public string Name { get; set; } = null!;
    public Address Address { get; set; } = null!;
    public double ServiceRadius { get; set; } = 0.0;
    public ICollection<Order> Orders { get; } = null!;
    public ICollection<BusinessService> BusinessServices { get; } = null!;
    public ICollection<BusinessEmployee> BusinessEmployees { get; } = null!;
}

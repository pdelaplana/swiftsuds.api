using SwiftSuds.Domain.Entities.BusinessEmployees;
using SwiftSuds.Domain.Entities.BusinessOwners;
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
    public BusinessOwnerId BusinessOwnerId { get; set; } = null!;
    public BusinessOwner BusinessOwner { get; set; } = null!;

    [Column(TypeName = "nvarchar(50)")]
    public string Name { get; set; } = null!;
    public Address Address { get; set; } = null!;
    public double ServiceRadius { get; set; } = 0.0;
    public ICollection<Order> Orders { get; set; } = null!;
    public ICollection<BusinessService> BusinessServices { get; set; } = new List<BusinessService>();
    public ICollection<BusinessEmployee> BusinessEmployees { get; set;  } = null!;
}

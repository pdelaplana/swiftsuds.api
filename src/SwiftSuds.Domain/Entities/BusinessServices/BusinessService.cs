using SwiftSuds.Domain.Entities.Businesses;
using SwiftSuds.Domain.Entities.Orders;
using SwiftSuds.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwiftSuds.Domain.Entities.BusinessServices;
public sealed class BusinessService
{
    public BusinessService(){}
    public BusinessService(
        BusinessServiceId businessServiceId,
        BusinessId businessId,
        string name,
        string description,
        Money price)
    {
        BusinessServiceId = businessServiceId;
        BusinessId = businessId;
        Name = name;
        Description = description;
        Price = price;
    }

    public BusinessServiceId BusinessServiceId { get; set; } = null!;
    public BusinessId BusinessId { get; set; } = null!;
    public Business Business { get; set; } = null!;

    [Column(TypeName = "nvarchar(60)")] 
    public string Name { get; set; } = null!;

    [Column(TypeName = "nvarchar(120)")] 
    public string Description { get; set; } = null!;
    public Money Price { get; set; } = null!;

    public ICollection<Order> Orders { get; set; }
}

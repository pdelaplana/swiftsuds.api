using SwiftSuds.Domain.Entities.Businesses;
using SwiftSuds.Domain.Entities.Orders;
using SwiftSuds.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwiftSuds.Domain.Entities.BusinessServices;
public sealed class BusinessService
{
    public BusinessService(){}

    private BusinessService(
        BusinessServiceId businessServiceId,
        BusinessId businessId,
        string name,
        string description,
        int maxQuantityPerOrder)
    {
        BusinessServiceId = businessServiceId;
        BusinessId = businessId;
        Name = name;
        Description = description;
        MaxQuantityPerOrder = maxQuantityPerOrder;
    }

    public BusinessService(
        BusinessServiceId businessServiceId,
        BusinessId businessId,
        string name,
        string description,
        int maxQuantityPerOrder,
        Money price) : this(businessServiceId, businessId, name, description, maxQuantityPerOrder)
    {
        Price = price;
    }

    public BusinessServiceId BusinessServiceId { get; set; } = null!;
    public BusinessId BusinessId { get; set; } = null!;
    public Business Business { get; set; } = null!;

    [Column(TypeName = "nvarchar(60)")] 
    public string Name { get; set; } = null!;

    [Column(TypeName = "nvarchar(120)")] 
    public string? Description { get; set; } = null!;
    public Money Price { get; set; } = null!;

    public int MaxQuantityPerOrder { get; set; } = 1;

    public int Sequence { get; set; } = 1;

    public ICollection<OrderService> OrderServices { get; set; } = null!;
}

using System.ComponentModel.DataAnnotations.Schema;

namespace SwiftSuds.Domain.Entities.Orders;
public sealed class OrderItem
{
    public OrderItemId OrderItemId { get; set; } = null!;
    
    [Column(TypeName = "nvarchar(60)")]
    public string Item { get; set; } = null!;
    public int Quantity { get; set; } = 0;
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwiftSuds.Domain.Entities.Businesses;
using SwiftSuds.Domain.Entities.BusinessServices;
using SwiftSuds.Domain.Entities.Customers;
using SwiftSuds.Domain.Entities.Drivers;
using SwiftSuds.Domain.Entities.Orders;

namespace SwiftSuds.Infrastructure.Persistence.EFCore.Configurations;
internal sealed class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(order => order.OrderId);
        builder.Property(order => order.OrderId)
            .HasConversion(id => id.Value, 
                value => new OrderId(value));
        builder.Property(order => order.CustomerId)
            .HasConversion(id => id.Value, 
                value => new CustomerId(value));
        builder.Property(order => order.BusinessId)
            .HasConversion(id => id.Value, 
                value => new BusinessId(value));
        builder.Property(order => order.BusinessServiceId)
            .HasConversion(id => id.Value, 
                value => new BusinessServiceId(value));
        builder.Property(order => order.DeliveryDriverId)
            .HasConversion(id => id.Value, 
                value => new DriverId(value));
        builder.Property(order => order.PickupDriverId)
            .HasConversion(id => id.Value, 
                value => new DriverId(value));
        builder.OwnsOne(order => order.AmountDue);

    }
}

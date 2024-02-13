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
        builder.Property(order => order.DeliveryDriverId)
            .HasConversion(id => id.Value, 
                value => new DriverId(value));
        builder.Property(order => order.PickupDriverId)
            .HasConversion(id => id.Value, 
                value => new DriverId(value));
        builder.OwnsOne(order => order.AmountDue, moneyBuilder =>
        {
            moneyBuilder.Property(m => m.Amount);
            moneyBuilder.OwnsOne(m => m.Currency, currencyBuilder => currencyBuilder.Property(c => c.Symbol));
        });
        builder.OwnsOne(order => order.AmountPaid, moneyBuilder =>
        {
            moneyBuilder.Property(m => m.Amount);
            moneyBuilder.OwnsOne(m => m.Currency, currencyBuilder => currencyBuilder.Property(c => c.Symbol));
        });
        builder.OwnsOne(order => order.PickupAddress, addressBuilder =>
        {
            addressBuilder.Property(a => a.StreetAddress1);
            addressBuilder.Property(a => a.StreetAddress2);
            addressBuilder.Property(a => a.StreetAddress3);
            addressBuilder.Property(a => a.City);
            addressBuilder.Property(a => a.PostCode);
        });
        builder.OwnsOne(order => order.DeliveryAddress, addressBuilder =>
        {
            addressBuilder.Property(a => a.StreetAddress1);
            addressBuilder.Property(a => a.StreetAddress2);
            addressBuilder.Property(a => a.StreetAddress3);
            addressBuilder.Property(a => a.City);
            addressBuilder.Property(a => a.PostCode);
        });
        builder.OwnsMany<OrderItem>(order => order.Items, a => {
            a.WithOwner().HasForeignKey("OrderId");
            a.Property(i => i.OrderItemId).HasConversion(id => id.Value,
                value => new OrderItemId(value)); ;
            a.HasKey(i => i.OrderItemId);
        });
        builder.HasMany<OrderService>(order => order.Services)
           .WithOne(orderService => orderService.Order)
           .OnDelete(DeleteBehavior.Restrict);

    }
}

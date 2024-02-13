using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwiftSuds.Domain.Entities.BusinessServices;
using SwiftSuds.Domain.Entities.Orders;


namespace SwiftSuds.Infrastructure.Persistence.EFCore.Configurations;
internal class OrderServiceEntityTypeConfiguration : IEntityTypeConfiguration<OrderService>
{
    public void Configure(EntityTypeBuilder<OrderService> builder)
    {
        builder.HasKey(orderService => orderService.OrderServiceId);
        builder.Property(orderService => orderService.OrderServiceId)
            .HasConversion(
                id => id.Value,
                value => new OrderServiceId(value));
        builder.Property(orderService => orderService.OrderId)
          .HasConversion(
              id => id.Value,
              value => new OrderId(value));
        builder.Property(orderService => orderService.BusinessServiceId)
         .HasConversion(
             id => id.Value,
             value => new BusinessServiceId(value));
        builder.OwnsOne(orderService => orderService.FinalPrice, moneyBuilder => {
            moneyBuilder.Property(m => m.Amount);
            moneyBuilder.OwnsOne(m => m.Currency, currencyBuilder => currencyBuilder.Property(c => c.Symbol));
        });
    }
}

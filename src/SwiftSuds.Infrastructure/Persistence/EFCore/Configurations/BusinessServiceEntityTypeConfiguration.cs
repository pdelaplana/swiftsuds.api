using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwiftSuds.Domain.Entities.Businesses;
using SwiftSuds.Domain.Entities.BusinessServices;
using SwiftSuds.Domain.Entities.Orders;

namespace SwiftSuds.Infrastructure.Persistence.EFCore.Configurations;
internal sealed class BusinessServiceEntityTypeConfiguration : IEntityTypeConfiguration<BusinessService>
{
    public void Configure(EntityTypeBuilder<BusinessService> builder)
    {
        builder.HasKey(businessService => businessService.BusinessServiceId);
        builder.Property(businessService => businessService.BusinessServiceId)
            .HasConversion(id => id.Value,
                value => new BusinessServiceId(value));
        builder.Property(businessService => businessService.BusinessId)
            .HasConversion(id => id.Value,
                value => new BusinessId(value));
        builder.OwnsOne(businessService => businessService.Price, moneyBuilder => 
        {
            moneyBuilder.Property(m => m.Amount);
            moneyBuilder.OwnsOne(m => m.Currency, currencyBuilder => currencyBuilder.Property(c => c.Symbol));
        });
        builder.HasMany<OrderService>(businessService => businessService.OrderServices)
            .WithOne(orderService => orderService.BusinessService)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

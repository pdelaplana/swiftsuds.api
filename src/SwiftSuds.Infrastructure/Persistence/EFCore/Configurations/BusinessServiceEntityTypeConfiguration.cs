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
        builder.OwnsOne(businessService => businessService.Price);

        builder.HasMany<Order>(businessService => businessService.Orders)
            .WithOne(order => order.BusinessService)
            .OnDelete(DeleteBehavior.Restrict);


    }
}

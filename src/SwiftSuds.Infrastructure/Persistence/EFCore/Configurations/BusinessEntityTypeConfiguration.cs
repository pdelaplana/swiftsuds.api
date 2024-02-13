using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwiftSuds.Domain.Entities.BusinessEmployees;
using SwiftSuds.Domain.Entities.Businesses;
using SwiftSuds.Domain.Entities.BusinessOwners;
using SwiftSuds.Domain.Entities.BusinessServices;
using SwiftSuds.Domain.Entities.Orders;

namespace SwiftSuds.Infrastructure.Persistence.EFCore.Configurations;
internal class BusinessEntityTypeConfiguration : IEntityTypeConfiguration<Business>
{
    public void Configure(EntityTypeBuilder<Business> builder)
    {
        builder.HasKey(business => business.BusinessId);
        builder.Property(business => business.BusinessId)
            .HasConversion(
                id => id.Value,
                value => new BusinessId(value));
        builder.Property(order => order.BusinessOwnerId)
            .HasConversion(
                id => id.Value,
                value => new BusinessOwnerId(value));
        builder.OwnsOne(business => business.Address, addressBuilder =>
        {
            addressBuilder.Property(a => a.StreetAddress1);
            addressBuilder.Property(a => a.StreetAddress2);
            addressBuilder.Property(a => a.StreetAddress3);
            addressBuilder.Property(a => a.City);
            addressBuilder.Property(a => a.PostCode);
        });

        builder.HasMany<Order>(order => order.Orders)
            .WithOne(order => order.Business)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany<BusinessEmployee>(business => business.BusinessEmployees)
            .WithOne(businessEmployee => businessEmployee.Business)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany<BusinessService>(business => business.BusinessServices)
            .WithOne(businessService => businessService.Business)
            .OnDelete(DeleteBehavior.Restrict);

    }
}

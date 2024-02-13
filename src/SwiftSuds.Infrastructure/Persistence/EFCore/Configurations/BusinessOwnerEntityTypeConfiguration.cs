using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwiftSuds.Domain.Entities.BusinessOwners;

namespace SwiftSuds.Infrastructure.Persistence.EFCore.Configurations;
internal class BusinessOwnerEntityTypeConfiguration : IEntityTypeConfiguration<BusinessOwner>
{
    public void Configure(EntityTypeBuilder<BusinessOwner> builder)
    {
        builder.HasKey(owner => owner.BusinessOwnerId);
        builder.Property(owner => owner.BusinessOwnerId)
            .HasConversion(
                id => id.Value,
                value => new BusinessOwnerId(value)
                );
        builder.OwnsOne(owner => owner.Address, addressBuilder =>
        {
            addressBuilder.Property(a => a.StreetAddress1);
            addressBuilder.Property(a => a.StreetAddress2);
            addressBuilder.Property(a => a.StreetAddress3);
            addressBuilder.Property(a => a.City);
            addressBuilder.Property(a => a.PostCode);
        });

    }
}

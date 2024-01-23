using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwiftSuds.Domain.Entities.BusinessEmployees;
using SwiftSuds.Domain.Entities.Businesses;

namespace SwiftSuds.Infrastructure.Persistence.EFCore.Configurations;
internal class BusinessEmployeeEntityTypeConfiguration : IEntityTypeConfiguration<BusinessEmployee>
{
    public void Configure(EntityTypeBuilder<BusinessEmployee> builder)
    {
        builder.HasKey(businessEmployee => businessEmployee.BusinessEmployeeId);
        builder.Property(businessEmployee => businessEmployee.BusinessEmployeeId)
            .HasConversion(id => id.Value,
                value => new BusinessEmployeeId(value));
        builder.Property(businessEmployee => businessEmployee.BusinessId)
            .HasConversion(id => id.Value,
                value => new BusinessId(value));
        builder.OwnsOne(businessEmployee => businessEmployee.Address, addressBuilder =>
        {
            addressBuilder.Property(a => a.StreetAddress1);
            addressBuilder.Property(a => a.StreetAddress2);
            addressBuilder.Property(a => a.StreetAddress3);
            addressBuilder.Property(a => a.City);
            addressBuilder.Property(a => a.PostCode);
        });

      
    }
}

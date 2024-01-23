using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwiftSuds.Domain.Entities.Customers;
using SwiftSuds.Domain.Entities.Orders;

namespace SwiftSuds.Infrastructure.Persistence.EFCore.Configurations;
internal class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(customer => customer.CustomerId);
        builder.Property(customer => customer.CustomerId)
            .HasConversion(id => id.Value,
            value => new CustomerId(value));
        builder.OwnsOne(customer => customer.Address, addressBuilder =>
        {
            addressBuilder.Property(a => a.StreetAddress1);
            addressBuilder.Property(a => a.StreetAddress2);
            addressBuilder.Property(a => a.StreetAddress3);
            addressBuilder.Property(a => a.City);
            addressBuilder.Property(a => a.PostCode);
        });

        builder.HasMany<Order>(order => order.Orders)
            .WithOne(order => order.Customer)
            .OnDelete(DeleteBehavior.Restrict);

    }
}

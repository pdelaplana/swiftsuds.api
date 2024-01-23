using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwiftSuds.Domain.Entities.Drivers;
using SwiftSuds.Domain.Entities.Orders;

namespace SwiftSuds.Infrastructure.Persistence.EFCore.Configurations;
internal class DriverEntityTypeConfiguration : IEntityTypeConfiguration<Driver>
{
    public void Configure(EntityTypeBuilder<Driver> builder)
    {
        builder.HasKey(driver => driver.DriverId);
        builder.Property(driver => driver.DriverId)
            .HasConversion(id => id.Value,
                value => new DriverId(value));
        builder.OwnsOne(driver => driver.Address, addressBuilder =>
        {
            addressBuilder.Property(a => a.StreetAddress1);
            addressBuilder.Property(a => a.StreetAddress2);
            addressBuilder.Property(a => a.StreetAddress3);
            addressBuilder.Property(a => a.City);
            addressBuilder.Property(a => a.PostCode);
        });
        builder.OwnsOne(driver => driver.Vehicle, vehicleBuilder =>
        {
            vehicleBuilder.OwnsOne(vehicle => vehicle.VehicleType, vehicleTypeBuilder =>
            {
                vehicleTypeBuilder.Property(vt => vt.Type).HasColumnType("nvarchar(20)");
            });
            vehicleBuilder.Property(v => v.RegistrationExpiryDate);
            vehicleBuilder.Property(v => v.RegistrationNumber);
        });
        builder.HasMany<Order>(driver => driver.DeliveryOrders)
            .WithOne(order => order.DeliveryDriver)
            .HasForeignKey(driver => driver.DeliveryDriverId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasMany<Order>(driver => driver.PickupOrders)
            .WithOne(order => order.PickupDriver)
            .HasForeignKey(driver => driver.PickupDriverId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

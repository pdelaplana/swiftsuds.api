using Microsoft.EntityFrameworkCore;
using SwiftSuds.Domain.Entities.BusinessEmployees;
using SwiftSuds.Domain.Entities.Businesses;
using SwiftSuds.Domain.Entities.BusinessServices;
using SwiftSuds.Domain.Entities.Customers;
using SwiftSuds.Domain.Entities.Drivers;
using SwiftSuds.Domain.Entities.Orders;
using SwiftSuds.Domain.Entities.UserAccounts;
using SwiftSuds.Infrastructure.Persistence.EFCore.Configurations;


namespace SwiftSuds.Infrastructure.Persistence.EFCore.Contexts;
public abstract class BaseDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new DriverEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new BusinessEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new BusinessServiceEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new BusinessEmployeeEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new UserAccountTypeConfiguration());
    }

    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Driver> Drivers { get; set; } = null!;
    public DbSet<Business> Businesses { get; set; } = null!;
    public DbSet<BusinessService> BusinessServices { get; set; } = null!;
    public DbSet<BusinessEmployee> BusinessEmployees { get; set; } = null!;
    public DbSet<UserAccount> UserAccounts { get; set; } = null!;
}

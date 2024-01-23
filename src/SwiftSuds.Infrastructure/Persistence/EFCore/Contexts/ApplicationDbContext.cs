using Microsoft.EntityFrameworkCore;
using SwiftSuds.Application.Abstractions;
using SwiftSuds.Domain.Entities.BusinessEmployees;
using SwiftSuds.Domain.Entities.Businesses;
using SwiftSuds.Domain.Entities.BusinessServices;
using SwiftSuds.Domain.Entities.Customers;
using SwiftSuds.Domain.Entities.Drivers;
using SwiftSuds.Domain.Entities.Orders;
using SwiftSuds.Infrastructure.Persistence.EFCore.Configurations;

namespace SwiftSuds.Infrastructure.Persistence.EFCore.Contexts;
public sealed class ApplicationDbContext(DbContextOptions options) : DbContext(options), IUnitOfWork
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new DriverEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new BusinessEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new BusinessServiceEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new BusinessEmployeeEntityTypeConfiguration());

    }

    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Driver> Drivers { get; set; } = null!;
    public DbSet<Business> Businesses { get; set; } = null!;
    public DbSet<BusinessService> BusinessServices { get; set; } = null!;
    public DbSet<BusinessEmployee> BusinessEmployees { get; set; } = null!;

    public void Commit()
    {
        base.SaveChanges();
    }

    public async Task CommitAsync()
    {
        await base.SaveChangesAsync();
    }

    public void Rollback()
    {
        throw new NotImplementedException();
    }

    public Task RollbackAsync()
    {
        throw new NotImplementedException();
    }
}

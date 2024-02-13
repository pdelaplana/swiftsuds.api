using Microsoft.EntityFrameworkCore;
using SwiftSuds.Domain.Entities.BusinessEmployees;
using SwiftSuds.Domain.Entities.Businesses;
using SwiftSuds.Domain.Entities.BusinessOwners;
using SwiftSuds.Domain.Entities.BusinessServices;
using SwiftSuds.Domain.Entities.Customers;
using SwiftSuds.Domain.Entities.Drivers;
using SwiftSuds.Domain.Entities.Orders;
using SwiftSuds.Domain.Entities.UserAccounts;
using SwiftSuds.Infrastructure.Persistence.EFCore.Configurations;


namespace SwiftSuds.Infrastructure.Persistence.EFCore.Contexts;
public abstract class BaseDbContext(DbContextOptions options) : DbContext(options)
{

    private void GenerateCustomerSeedData(ModelBuilder modelBuilder) 
    {
        var customerGuid = Guid.Parse("A8307AC9-ECB2-4044-A665-37DC743ED839");
        modelBuilder.Entity<Customer>().HasData(
            new Customer {
                CustomerId = new CustomerId(customerGuid),
                Name = "Seed Customer",
                Email = "seed.customer@mail.com",
                Phone = "+619617891787" 
            });

        modelBuilder.Entity<Customer>().OwnsOne(c => c.Address)
            .HasData(new { 
                CustomerId = new CustomerId(customerGuid), 
                StreetAddress1 = "1 Main Street" 
            });

        modelBuilder.Entity<UserAccount>().HasData(
            new UserAccount
            {
                UserAccountId = new UserAccountId(Guid.NewGuid()),
                AccountType = AccountType.Customer,
                Email = "seed.customer@mail.com"
            });
    }

    private void GenerateBusinessSeedData(ModelBuilder modelBuilder)
    {
        var businessOwnerGuid = Guid.NewGuid();
        var businessGuid = Guid.Parse("C7E0C728-A2B7-4DAB-85EA-A5835DDD149F");
        modelBuilder.Entity<Business>().HasData(
            new Business
            {
                BusinessId = new BusinessId(businessGuid),
                BusinessOwnerId = new BusinessOwnerId(businessOwnerGuid),
                Name = "SwiftSuds Laundry",
                ServiceRadius = 10,
            });

        modelBuilder.Entity<Business>().OwnsOne(c => c.Address)
            .HasData(new { 
                BusinessId = new BusinessId(businessGuid), 
                StreetAddress1 = "1 Main Street" 
            });

        BusinessService[] businessServices = [
            new BusinessService 
            {
                BusinessServiceId = new BusinessServiceId(Guid.Parse("C58A7A3C-1C43-43A8-B425-DFF82C915792")),
                BusinessId = new BusinessId(businessGuid),
                Name = "Wash (Max 8 Kilos)",
                MaxQuantityPerOrder = 5,
                Sequence = 1 
            },
            new BusinessService
            {
                BusinessServiceId = new BusinessServiceId(Guid.NewGuid()),
                BusinessId = new BusinessId(businessGuid),
                Name = "Dry (Max 8 Kilos)",
                MaxQuantityPerOrder = 5,
                Sequence = 2,
            },
            new BusinessService
            {
                BusinessServiceId = new BusinessServiceId(Guid.NewGuid()),
                BusinessId = new BusinessId(businessGuid),
                Name = "Folds (Max 8 Kilos)",
                MaxQuantityPerOrder = 5,
                Sequence= 3,
            },
            new BusinessService
            {
                BusinessServiceId = new BusinessServiceId(Guid.NewGuid()),
                BusinessId = new BusinessId(businessGuid),
                Name = "Dry Cleaning",
                MaxQuantityPerOrder = 1,
                Sequence= 4,
            },
            new BusinessService
            {
                BusinessServiceId = new BusinessServiceId(Guid.NewGuid()),
                BusinessId = new BusinessId(businessGuid),
                Name = "Ironing",
                MaxQuantityPerOrder = 1,
                Sequence = 5,
            },
        ];

        object[] prices = [
            new
            {
                BusinessServiceId = businessServices[0].BusinessServiceId,
                Amount = (decimal)75.00
            },
            new
            {
                BusinessServiceId = businessServices[1].BusinessServiceId,
                Amount = (decimal)75.00
            },
            new
            {
                BusinessServiceId = businessServices[2].BusinessServiceId,
                Amount = (decimal)50.00
            },
            new
            {
                BusinessServiceId = businessServices[3].BusinessServiceId,
                Amount = (decimal)50.00
            },
            new
            {
                BusinessServiceId = businessServices[4].BusinessServiceId,
                Amount = (decimal)50.00
            },
           

        ];

        object[] currencies = [
            new
            {
                MoneyBusinessServiceId = businessServices[0].BusinessServiceId,
                Symbol = "PHP"
            },
            new
            {
                MoneyBusinessServiceId = businessServices[1].BusinessServiceId,
                Symbol = "PHP"
            },
            new
            {
                MoneyBusinessServiceId = businessServices[2].BusinessServiceId,
                Symbol = "PHP"
            },
            new
            {
                MoneyBusinessServiceId = businessServices[3].BusinessServiceId,
                Symbol = "PHP"
            },
            new
            {
                MoneyBusinessServiceId = businessServices[4].BusinessServiceId,
                Symbol = "PHP"
            },
           
        ];

        modelBuilder.Entity<BusinessService>().HasData(businessServices);

        modelBuilder.Entity<BusinessService>().OwnsOne(s => s.Price).HasData(prices);

        modelBuilder.Entity<BusinessService>().OwnsOne(s => s.Price).OwnsOne(p => p.Currency).HasData(currencies);

        modelBuilder.Entity<BusinessOwner>().HasData(
            new BusinessOwner { 
                BusinessOwnerId = new BusinessOwnerId(businessOwnerGuid),
                Name = "Business Owner",
                Email = "business.owner@mail.com",
                Phone = "+619019090"
            });
        modelBuilder.Entity<BusinessOwner>().OwnsOne(bo => bo.Address)
           .HasData(new { 
               BusinessOwnerId = new BusinessOwnerId(businessOwnerGuid), 
               StreetAddress1 = "1 Main Street" 
           });

        modelBuilder.Entity<UserAccount>().HasData(
            new UserAccount
            {
                UserAccountId = new UserAccountId(Guid.NewGuid()),
                AccountType = AccountType.BusinessOwner,
                Email = "business.owner@mail.com"
            });
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new DriverEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new BusinessEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new BusinessServiceEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new BusinessEmployeeEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new UserAccountTypeConfiguration());
        modelBuilder.ApplyConfiguration(new BusinessOwnerEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new OrderServiceEntityTypeConfiguration());

        // seed database
        GenerateCustomerSeedData(modelBuilder);
        GenerateBusinessSeedData(modelBuilder);

    }

    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Driver> Drivers { get; set; } = null!;
    public DbSet<Business> Businesses { get; set; } = null!;
    public DbSet<BusinessService> BusinessServices { get; set; } = null!;
    public DbSet<BusinessEmployee> BusinessEmployees { get; set; } = null!;
    public DbSet<BusinessOwner> BusinessOwners { get; set; } = null!;
    public DbSet<UserAccount> UserAccounts { get; set; } = null!;
}

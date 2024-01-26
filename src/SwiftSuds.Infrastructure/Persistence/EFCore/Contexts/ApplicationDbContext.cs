using Microsoft.EntityFrameworkCore;
using SwiftSuds.Application.Abstractions;
using SwiftSuds.Domain.Entities.BusinessEmployees;
using SwiftSuds.Domain.Entities.Businesses;
using SwiftSuds.Domain.Entities.BusinessServices;
using SwiftSuds.Domain.Entities.Customers;
using SwiftSuds.Domain.Entities.Drivers;
using SwiftSuds.Domain.Entities.Orders;
using SwiftSuds.Domain.Entities.UserAccounts;
using SwiftSuds.Infrastructure.Persistence.EFCore.Configurations;

namespace SwiftSuds.Infrastructure.Persistence.EFCore.Contexts;
public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : BaseDbContext(options), IUnitOfWork
{
    
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

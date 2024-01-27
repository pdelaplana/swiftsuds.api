using Microsoft.EntityFrameworkCore;
using SwiftSuds.Application.Abstractions;


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

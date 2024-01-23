using SwiftSuds.Application.Abstractions;
using SwiftSuds.Infrastructure.Persistence.EFCore.Contexts;

namespace SwiftSuds.Infrastructure.Persistence;
internal class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    public ApplicationDbContext Context { get; } = context;

    public void Commit() => Context.SaveChanges();

    public async Task CommitAsync() => await Context.SaveChangesAsync();
    
    public void Rollback() => Context.Dispose();

    public async Task RollbackAsync() => await Context.DisposeAsync();
    
}

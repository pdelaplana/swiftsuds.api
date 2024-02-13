using Microsoft.EntityFrameworkCore;
using SwiftSuds.Application.Abstractions.Repositories.ReadOnly;
using SwiftSuds.Domain.ValueObjects;
using System.Linq.Expressions;

namespace SwiftSuds.Infrastructure.Persistence.Repositories.ReadOnly;
public class GenericReadOnlyRepository<T>(DbContext context) : IReadOnlyRepository<T> where T : class
{
    public T? GetById(EntityId entityId)
    {
        return context.Set<T>().Find(entityId);
    }

    public async Task<T?> GetByIdAsync(EntityId entityId)
    {
        return await context.Set<T>().FindAsync(entityId);
    }
}

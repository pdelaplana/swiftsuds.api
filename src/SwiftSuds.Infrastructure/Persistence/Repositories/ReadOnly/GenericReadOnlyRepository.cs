using Microsoft.EntityFrameworkCore;
using SwiftSuds.Application.Abstractions.Repositories.ReadOnly;
using SwiftSuds.Domain.ValueObjects;

namespace SwiftSuds.Infrastructure.Persistence.Repositories.ReadOnly;
public class GenericReadOnlyRepository<T>(DbContext context) : IReadOnlyRepository<T> where T : class
{
    public T? GetById(EntityId entityId)
    {
        return context.Set<T>().Find(entityId);
    }

    public Task<T?> GetByIdAsync(EntityId entityId)
    {
        throw new NotImplementedException();
    }
}

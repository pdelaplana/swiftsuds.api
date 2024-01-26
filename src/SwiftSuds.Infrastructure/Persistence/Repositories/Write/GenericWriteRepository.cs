using Microsoft.EntityFrameworkCore;
using SwiftSuds.Application.Abstractions.Repositories.Write;
using SwiftSuds.Domain.ValueObjects;

namespace SwiftSuds.Infrastructure.Persistence.Repositories.Write;

public class GenericWriteRepository<T>(DbContext context) : IWriteRepository<T> where T : class
{
    public T Add(T entity)
    {
        context.Add(entity);
        return entity;
    }

    public T? Update(EntityId entityId, T entity)
    {
        var found = context.Set<T>().Find(entityId);
        if (found == null)
        {
            return null;
        }

        found = entity;
        context.Update(found);

        return found;
    }

    public bool Delete(EntityId entityId)
    {
        throw new NotImplementedException();
    }
}
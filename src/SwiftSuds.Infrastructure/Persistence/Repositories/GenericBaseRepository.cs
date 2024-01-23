using Microsoft.EntityFrameworkCore;
using SwiftSuds.Application.Abstractions.Repositories;
using SwiftSuds.Domain.ValueObjects;

namespace SwiftSuds.Infrastructure.Persistence.Repositories;

public class GenericBaseRepository<T>(DbContext context) : IRepository<T> where T : class
{
    public void Add(T entity)
    {
        context.Add(entity);
    }

    public void Delete(EntityId entityId)
    {
        context.Remove(entityId);
    }

    public T? GetById(EntityId entityId)
    {
        return context.Set<T>().Find(entityId);
    }

    public async Task<T?> GetByIdAsync(EntityId entityId)
    {
        return await context.Set<T>().FindAsync(entityId);
    }

    public void Update(EntityId entityId, T entity)
    {
        var found = context.Set<T>().Find(entityId);
        if (found == null)
        {
            return;
        }

        found = entity;
        context.Update(found);
    }
}
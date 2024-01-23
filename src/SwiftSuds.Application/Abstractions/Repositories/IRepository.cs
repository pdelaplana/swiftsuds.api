using SwiftSuds.Domain.ValueObjects;

namespace SwiftSuds.Application.Abstractions.Repositories;
public interface IRepository<T> where T : class
{
    T? GetById(EntityId entityId);

    Task<T?> GetByIdAsync(EntityId entityId);

    void Add(T entity);

    void Update(EntityId entityId, T entity);

    void Delete(EntityId entityId);
}

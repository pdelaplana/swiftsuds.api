using SwiftSuds.Domain.ValueObjects;

namespace SwiftSuds.Application.Abstractions.Repositories.Write;
public interface IWriteRepository<T> where T : class
{
    T Add(T entity);
    T? Update(EntityId entityId, T entity);
    bool Delete(EntityId entityId);
}

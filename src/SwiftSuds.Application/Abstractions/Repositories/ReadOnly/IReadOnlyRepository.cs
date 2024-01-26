using SwiftSuds.Domain.ValueObjects;

namespace SwiftSuds.Application.Abstractions.Repositories.ReadOnly;
public interface IReadOnlyRepository<T> where T : class
{
    T? GetById(EntityId entityId);
    Task<T?> GetByIdAsync(EntityId entityId);
}

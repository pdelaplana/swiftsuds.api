using SwiftSuds.Domain.Entities.Businesses;
using System.Linq.Expressions;

namespace SwiftSuds.Application.Abstractions.Repositories.ReadOnly;
public interface IBusinessReadOnlyRepository : IReadOnlyRepository<Business>
{
    Task<ICollection<Business>> GetBusinessesAsync(int offset = 0, int limit = 100);

    Task<Business?> GetBusinessByIdAsync(BusinessId businessId, Expression<Func<Business, object?>>[]? includes = null);
}

using Microsoft.EntityFrameworkCore;
using SwiftSuds.Application.Abstractions.Repositories.ReadOnly;
using SwiftSuds.Domain.Entities.Businesses;
using SwiftSuds.Infrastructure.Persistence.EFCore.Contexts;
using System.Linq.Expressions;

namespace SwiftSuds.Infrastructure.Persistence.Repositories.ReadOnly;
public sealed class BusinessReadOnlyRepository(ReadOnlyDbContext context) : GenericReadOnlyRepository<Business>(context), IBusinessReadOnlyRepository
{
    public async Task<Business?> GetBusinessByIdAsync(BusinessId businessId, Expression<Func<Business, object?>>[]? includes = null)
    {
        var query = context.Businesses.AsQueryable();
        if (includes != null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }
        return await query.Where(b => b.BusinessId == businessId).SingleOrDefaultAsync();
    }

    public async Task<ICollection<Business>> GetBusinessesAsync(int offset = 0, int limit = 100) =>
        await context.Businesses.Skip(offset).Take(limit).ToListAsync();

}

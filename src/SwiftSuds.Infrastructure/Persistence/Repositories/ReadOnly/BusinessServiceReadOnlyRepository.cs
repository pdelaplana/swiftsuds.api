using Microsoft.EntityFrameworkCore;
using SwiftSuds.Application.Abstractions.Repositories.ReadOnly;
using SwiftSuds.Domain.Entities.BusinessServices;
using SwiftSuds.Infrastructure.Persistence.EFCore.Contexts;

namespace SwiftSuds.Infrastructure.Persistence.Repositories.ReadOnly;
public class BusinessServiceReadOnlyRepository(ReadOnlyDbContext context)
    : GenericReadOnlyRepository<BusinessService>(context), IBusinessServiceReadOnlyRepository
{
    public async Task<ICollection<BusinessService>> GetBusinessServicesByIdsAsync(BusinessServiceId[] busineseServicesIds)
        => await context.BusinessServices.Where(bs => busineseServicesIds.Contains(bs.BusinessServiceId)).ToListAsync();
    
}

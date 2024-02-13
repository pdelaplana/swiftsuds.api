using SwiftSuds.Domain.Entities.BusinessServices;

namespace SwiftSuds.Application.Abstractions.Repositories.ReadOnly;
public interface IBusinessServiceReadOnlyRepository: IReadOnlyRepository<BusinessService>
{
    Task<ICollection<BusinessService>> GetBusinessServicesByIdsAsync(BusinessServiceId[] busineseServicesIds);
}

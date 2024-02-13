using SwiftSuds.Domain.ValueObjects;
using SwiftSuds.Order.Api.Modules.Businesses.V1.Models;

namespace SwiftSuds.Order.Api.Modules.Businesses.V1.Endpoints;

public record GetBusinessByIdResponse(
    Guid BusinessId, 
    string Name, 
    Address Address, 
    IList<BusinessServiceItem> BusinessServices);

public record BusinessServiceItem(
    Guid BusinessServiceId,
    string Name,
    string Description,
    int MaxQuantityPerOrder,
    int Sequence,
    Money Price);
using SwiftSuds.Order.Api.Modules.Businesses.V1.Models;

namespace SwiftSuds.Order.Api.Modules.Businesses.V1.Endpoints;

public record GetBusinessesResponse(IList<BusinessInfo> Businesses, int Page, int Size);
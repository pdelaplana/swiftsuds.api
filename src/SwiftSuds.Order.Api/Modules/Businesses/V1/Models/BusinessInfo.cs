using SwiftSuds.Domain.ValueObjects;

namespace SwiftSuds.Order.Api.Modules.Businesses.V1.Models;

public record BusinessInfo(Guid BusinessId, string Name, Address Address);


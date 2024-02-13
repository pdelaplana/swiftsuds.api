using SwiftSuds.Domain.ValueObjects;

namespace SwiftSuds.Domain.Entities.BusinessOwners;
public record BusinessOwnerId(Guid Value): EntityId(Value);

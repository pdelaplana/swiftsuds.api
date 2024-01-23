using SwiftSuds.Domain.ValueObjects;

namespace SwiftSuds.Domain.Entities.Businesses;
public record BusinessId (Guid Value) : EntityId(Value);
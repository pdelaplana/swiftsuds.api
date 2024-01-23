using SwiftSuds.Domain.ValueObjects;

namespace SwiftSuds.Domain.Entities.Orders;

public record OrderId(Guid Value) : EntityId(Value);
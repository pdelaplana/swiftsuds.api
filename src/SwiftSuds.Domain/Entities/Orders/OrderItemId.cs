using SwiftSuds.Domain.ValueObjects;

namespace SwiftSuds.Domain.Entities.Orders;
public record OrderItemId(Guid Value) : EntityId(Value);
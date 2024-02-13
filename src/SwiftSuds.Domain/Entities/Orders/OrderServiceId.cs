using SwiftSuds.Domain.ValueObjects;

namespace SwiftSuds.Domain.Entities.Orders;
public record OrderServiceId(Guid Value) : EntityId(Value);

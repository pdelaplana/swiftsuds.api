using SwiftSuds.Domain.ValueObjects;

namespace SwiftSuds.Domain.Entities.Customers;

public record CustomerId(Guid Value) : EntityId(Value);

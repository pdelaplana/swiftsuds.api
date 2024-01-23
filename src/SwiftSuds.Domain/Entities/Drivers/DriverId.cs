using SwiftSuds.Domain.ValueObjects;

namespace SwiftSuds.Domain.Entities.Drivers;
public record DriverId(Guid Value) : EntityId(Value);

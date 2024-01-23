using SwiftSuds.Domain.ValueObjects;

namespace SwiftSuds.Domain.Entities.BusinessServices;
public record BusinessServiceId(Guid Value) : EntityId(Value);

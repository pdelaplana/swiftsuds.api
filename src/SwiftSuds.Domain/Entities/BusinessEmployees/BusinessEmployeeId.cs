using SwiftSuds.Domain.ValueObjects;


namespace SwiftSuds.Domain.Entities.BusinessEmployees;
public record BusinessEmployeeId(Guid Value) : EntityId(Value);
using SwiftSuds.Domain.ValueObjects;

namespace SwiftSuds.Domain.Entities.UserAccounts;

public record UserAccountId(Guid Value) : EntityId(Value);


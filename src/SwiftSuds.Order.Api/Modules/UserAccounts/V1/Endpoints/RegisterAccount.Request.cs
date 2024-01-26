using SwiftSuds.Domain.Entities.UserAccounts;
using SwiftSuds.Domain.ValueObjects;

namespace SwiftSuds.Order.Api.Modules.UserAccounts.V1.Endpoints;

public record RegisterAccountRequest(string Name, string Email, string Phone, Address Address, AccountType AccountType);


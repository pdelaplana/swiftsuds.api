
using System.Text.Json.Serialization;

namespace SwiftSuds.Domain.Entities.UserAccounts;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AccountType
{
    Customer, 
    Driver,
    BusinessOwner,
    BusinessEmployee
}

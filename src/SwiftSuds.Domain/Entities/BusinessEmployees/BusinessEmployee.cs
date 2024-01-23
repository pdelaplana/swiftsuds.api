using SwiftSuds.Domain.Entities.Businesses;
using SwiftSuds.Domain.Entities.Users;


namespace SwiftSuds.Domain.Entities.BusinessEmployees;
public class BusinessEmployee : User
{
    public BusinessEmployeeId BusinessEmployeeId { get; set; } = null!;

    public BusinessId BusinessId { get; set; } = null!;
    public Business Business { get; set; } = null!;
}

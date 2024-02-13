using SwiftSuds.Domain.Entities.Users;


namespace SwiftSuds.Domain.Entities.BusinessOwners;
public sealed class BusinessOwner : User
{
    public BusinessOwnerId BusinessOwnerId { get; set; } = null!;

}

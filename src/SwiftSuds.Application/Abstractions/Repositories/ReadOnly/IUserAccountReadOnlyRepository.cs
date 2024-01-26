using SwiftSuds.Domain.Entities.UserAccounts;

namespace SwiftSuds.Application.Abstractions.Repositories.ReadOnly;
public interface IUserAccountReadOnlyRepository : IReadOnlyRepository<UserAccount>
{
    Task<UserAccount?> GetUserAccountByEmailAsync(string email);
}

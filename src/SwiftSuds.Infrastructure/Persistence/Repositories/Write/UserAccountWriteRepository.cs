using SwiftSuds.Application.Abstractions.Repositories.Write;
using SwiftSuds.Domain.Entities.UserAccounts;
using SwiftSuds.Infrastructure.Persistence.EFCore.Contexts;

namespace SwiftSuds.Infrastructure.Persistence.Repositories.Write;
public class UserAccountWriteRepository(ApplicationDbContext context) : GenericWriteRepository<UserAccount>(context), IUserAccountWriteRepository
{
}

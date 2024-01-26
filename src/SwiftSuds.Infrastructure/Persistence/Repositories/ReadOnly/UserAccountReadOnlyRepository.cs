using Microsoft.EntityFrameworkCore;
using SwiftSuds.Application.Abstractions.Repositories.ReadOnly;
using SwiftSuds.Domain.Entities.UserAccounts;
using SwiftSuds.Infrastructure.Persistence.EFCore.Contexts;

namespace SwiftSuds.Infrastructure.Persistence.Repositories.ReadOnly;
public sealed class UserAccountReadOnlyRepository(ReadOnlyDbContext context) : GenericReadOnlyRepository<UserAccount>(context), IUserAccountReadOnlyRepository
{
    public async Task<UserAccount?> GetUserAccountByEmailAsync(string email) 
        => await context.UserAccounts.Where(c => c.Email == email).SingleOrDefaultAsync();
}

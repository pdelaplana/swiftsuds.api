using Microsoft.EntityFrameworkCore;

namespace SwiftSuds.Infrastructure.Persistence.EFCore.Contexts;
public sealed class MigrationDbContext(DbContextOptions<MigrationDbContext> options) : BaseDbContext(options)
{
}

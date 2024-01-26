using Microsoft.EntityFrameworkCore;

namespace SwiftSuds.Infrastructure.Persistence.EFCore.Contexts;

public class ReadOnlyDbContext(DbContextOptions<ReadOnlyDbContext> options) : BaseDbContext(options)
{

}

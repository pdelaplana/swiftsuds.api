using SwiftSuds.Application.Abstractions.Repositories.Write;
using SwiftSuds.Domain.Entities.Orders;
using SwiftSuds.Infrastructure.Persistence.EFCore.Contexts;

namespace SwiftSuds.Infrastructure.Persistence.Repositories.Write;
public class OrderWriteRepository(ApplicationDbContext context) : GenericWriteRepository<Order>(context), IOrderWriteRepository
{
}

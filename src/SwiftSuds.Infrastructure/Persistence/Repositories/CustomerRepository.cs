using Microsoft.EntityFrameworkCore;
using SwiftSuds.Application.Abstractions.Repositories;
using SwiftSuds.Domain.Entities.Customers;
using SwiftSuds.Infrastructure.Persistence.EFCore.Contexts;

namespace SwiftSuds.Infrastructure.Persistence.Repositories;
public sealed class CustomerRepository(ApplicationDbContext context) : GenericBaseRepository<Customer>(context), ICustomerRepository
{
    public async Task<ICollection<Customer>> GetCustomersAsync(int offset = 0, int limit = 100) => 
        await context.Customers.Skip(offset).Take(limit).ToListAsync();

    public async Task<Customer?> GetCustomerByEmailAsync(string email) =>
        await context.Customers.Where(c => c.Email == email).SingleOrDefaultAsync();

    
}

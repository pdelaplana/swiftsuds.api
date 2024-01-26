using SwiftSuds.Domain.Entities.Customers;

namespace SwiftSuds.Application.Abstractions.Repositories;
public interface ICustomerRepository: IRepository<Customer>
{
    Task<ICollection<Customer>> GetCustomersAsync(int offset = 0, int limit = 100);

    Task<Customer?> GetCustomerByEmailAsync(string email);
}

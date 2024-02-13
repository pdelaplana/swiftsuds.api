using SwiftSuds.Domain.Entities.Orders;
using SwiftSuds.Domain.Entities.Users;
using SwiftSuds.Domain.ValueObjects;

namespace SwiftSuds.Domain.Entities.Customers;
public sealed class Customer : User
{
    public Customer(){}

    public Customer(CustomerId customerId, string name, string email, string phone, Address address)
    {
        CustomerId = customerId;
        Name = name;
        Email = email;
        Phone = phone;
        Address = address;
    }
    public CustomerId CustomerId { get; set; } = null!;
   
    public ICollection<Order> Orders { get; set; } = null!;
}

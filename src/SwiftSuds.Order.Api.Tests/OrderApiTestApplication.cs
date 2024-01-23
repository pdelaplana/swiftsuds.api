using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moq;
using SwiftSuds.Application.Abstractions.Repositories;
using SwiftSuds.Domain.Entities.Customers;
using SwiftSuds.Domain.ValueObjects;

namespace SwiftSuds.Order.Api.Tests;
public class OrderApiTestApplication : WebApplicationFactory<Program> {
    
    private readonly IList<Customer> _customers = new List<Customer>()
    {
        new (
            new CustomerId(Guid.NewGuid()),
            "John Doe",
            "john@mail.com",
            "909090",
            new Address(){ StreetAddress1 = "1 Main Street" }
        ),
    };
    protected override IHost CreateHost(IHostBuilder builder)
    {

        var mockCustomerRepository = new Mock<ICustomerRepository>();
        mockCustomerRepository.Setup(r => 
            r.GetCustomersAsync(It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(_customers);
        mockCustomerRepository.Setup(r =>
                r.GetByIdAsync(It.IsAny<EntityId>()))
            .ReturnsAsync(_customers.First());

        builder.ConfigureServices(services =>
        {
            services.AddScoped<ICustomerRepository>(sp => mockCustomerRepository.Object);
        }); 
       
        return base.CreateHost(builder);
    }
}

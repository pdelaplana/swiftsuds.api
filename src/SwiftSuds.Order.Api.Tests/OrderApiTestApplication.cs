using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moq;
using SwiftSuds.Application.Abstractions.Repositories;
using SwiftSuds.Application.Abstractions.Repositories.ReadOnly;
using SwiftSuds.Application.Abstractions.Repositories.Write;
using SwiftSuds.Domain.Entities.Businesses;
using SwiftSuds.Domain.Entities.BusinessServices;
using SwiftSuds.Domain.Entities.Customers;
using SwiftSuds.Domain.Entities.Orders;
using SwiftSuds.Domain.ValueObjects;
using SwiftSuds.Order.Api.Modules.Orders.V1.Endpoints;
using System.Linq.Expressions;

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

    private readonly IList<Business> _businesses = new List<Business>()
    {
        new (
            new BusinessId(Guid.NewGuid()),
            "Laundry Business",
            new Address(){ StreetAddress1 = "1 Main Street" },
            10
        ),
    };

    private readonly CreateOrderResponse _createOrderResponse = new CreateOrderResponse(Guid.NewGuid(), DateTime.Now,  250);

    protected override IHost CreateHost(IHostBuilder builder)
    {

        var mockCustomerRepository = new Mock<ICustomerRepository>();
        mockCustomerRepository
            .Setup(r => r.GetCustomersAsync(It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(_customers);
        mockCustomerRepository
            .Setup(r => r.GetByIdAsync(It.IsAny<EntityId>()))
            .ReturnsAsync(_customers.First());

        var mockBusinessReadOnlyRepository = new Mock<IBusinessReadOnlyRepository>();
        mockBusinessReadOnlyRepository
            .Setup(r => r.GetBusinessesAsync(It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(_businesses);
        mockBusinessReadOnlyRepository
            .Setup(r => r.GetBusinessByIdAsync(It.IsAny<BusinessId>(), It.IsAny<Expression<Func<Business, object?>>[]?>()))
            .ReturnsAsync(_businesses[0]);

        var mockBusinessServicesReadOnlyRepository = new Mock<IBusinessServiceReadOnlyRepository>();
        mockBusinessServicesReadOnlyRepository
            .Setup(r => r.GetBusinessServicesByIdsAsync(It.IsAny<BusinessServiceId[]>()))
            .ReturnsAsync( new List<BusinessService>() {
                new(
                    new BusinessServiceId(Guid.NewGuid()),
                    new BusinessId(Guid.NewGuid()),
                    "Test Service",
                    "",
                    1,
                    new Money(100, Currency.Php)
                )
            });

        var mockOrderWriteRepository = new Mock<IOrderWriteRepository>();
        mockOrderWriteRepository
            .Setup(r => r.Add(It.IsAny<Domain.Entities.Orders.Order>()))
            .Returns(new Domain.Entities.Orders.Order() { 
                OrderId = new OrderId(Guid.NewGuid()),
                OrderDate = DateTime.UtcNow,
                AmountDue = new Money(250, Currency.Php)
            });

        builder.ConfigureServices(services =>
        {
            services.AddScoped<ICustomerRepository>(sp => mockCustomerRepository.Object);
            services.AddScoped<IBusinessReadOnlyRepository>(sp => mockBusinessReadOnlyRepository.Object);
            services.AddScoped<IBusinessServiceReadOnlyRepository>(sp => mockBusinessServicesReadOnlyRepository.Object);
            services.AddScoped<IOrderWriteRepository>(sp => mockOrderWriteRepository.Object);
        }); 
       
        return base.CreateHost(builder);
    }
}

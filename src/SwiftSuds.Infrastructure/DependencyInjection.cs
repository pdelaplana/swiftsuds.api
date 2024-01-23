using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SwiftSuds.Application.Abstractions;
using SwiftSuds.Application.Abstractions.Repositories;
using SwiftSuds.Infrastructure.Persistence.EFCore.Contexts;
using SwiftSuds.Infrastructure.Persistence.Repositories;

namespace SwiftSuds.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options
                .UseSqlServer(configuration.GetConnectionString("Database"))
        );

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ICustomerRepository, CustomerRepository>();

        return services;
    }
}

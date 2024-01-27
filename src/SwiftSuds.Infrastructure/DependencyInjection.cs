using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SwiftSuds.Application.Abstractions;
using SwiftSuds.Application.Abstractions.Repositories;
using SwiftSuds.Application.Abstractions.Repositories.ReadOnly;
using SwiftSuds.Application.Abstractions.Repositories.Write;
using SwiftSuds.Infrastructure.Persistence.EFCore.Contexts;
using SwiftSuds.Infrastructure.Persistence.Repositories;
using SwiftSuds.Infrastructure.Persistence.Repositories.ReadOnly;
using SwiftSuds.Infrastructure.Persistence.Repositories.Write;

namespace SwiftSuds.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options
                .UseSqlServer(configuration.GetConnectionString("Primary"))
        );
        services.AddDbContext<ReadOnlyDbContext>(options =>
            options
                .UseSqlServer(configuration.GetConnectionString("ReadOnly"))
        );
        services.AddDbContext<MigrationDbContext>(options =>
            options
                .UseSqlServer(configuration.GetConnectionString("Migration"))
        );


        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IUserAccountReadOnlyRepository, UserAccountReadOnlyRepository>();
        services.AddScoped<IUserAccountWriteRepository, UserAccountWriteRepository>();

        return services;
    }
}

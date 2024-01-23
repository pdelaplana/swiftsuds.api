﻿using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SwiftSuds.Application.UseCases.Customers.CreateCustomer;

namespace SwiftSuds.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssembly(assembly));

        services.AddValidatorsFromAssembly(assembly, includeInternalTypes:true);

        return services;
    }
}

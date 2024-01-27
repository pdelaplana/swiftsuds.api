using Carter;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.OpenApi.Models;
using NLog;
using NLog.Web;
using SwiftSuds.Application;
using SwiftSuds.Domain.Entities.Customers;
using SwiftSuds.Infrastructure;
using SwiftSuds.Order.Api.Helpers.Converters;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("Starting Application");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(options =>
    {
        options.SupportNonNullableReferenceTypes();
        options.UseAllOfToExtendReferenceSchemas();
        options.UseAllOfForInheritance();
        options.UseOneOfForPolymorphism();
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
        });
    });

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog();


    // Add Dependencies
    builder.Services
        .AddCarter()
        .AddApplication()
        .AddPersistence(builder.Configuration);

    // Configure Json Options
    builder.Services.Configure<JsonOptions>(options =>
    {
        options.SerializerOptions.IncludeFields = true;
        options.SerializerOptions.Converters.Add(
            new EntityIdConverter<CustomerId, Guid>());
    });


    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.MapCarter();

    app.Run();

}
catch (Exception exception)
{
    logger.Error(exception, "Stopped application");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}


// Used this partial class for unit testing
namespace SwiftSuds.Order.Api
{
    public partial class Program { }
}


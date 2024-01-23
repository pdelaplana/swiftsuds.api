using Carter;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.OpenApi.Models;
using SwiftSuds.Application;
using SwiftSuds.Domain.Entities.Customers;
using SwiftSuds.Infrastructure;
using SwiftSuds.Order.Api.Helpers.Converters;


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

// Used this partial class for unit testing
namespace SwiftSuds.Order.Api
{
    public partial class Program { }
}


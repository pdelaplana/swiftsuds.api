using Carter;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.OpenApi.Models;
using SwiftSuds.Application;
using SwiftSuds.Infrastructure;
using WebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen(options =>
    {
        options.SupportNonNullableReferenceTypes();
        options.UseAllOfToExtendReferenceSchemas();
        options.UseAllOfForInheritance();
        options.UseOneOfForPolymorphism();
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
        });
    })
    .AddCarter()
    .AddApplication()
    .AddPersistence(builder.Configuration);

// Configure Json Options
builder.Services.Configure<JsonOptions>(options => 
    options.SerializerOptions.IncludeFields = true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/helloworld", () => "Hello World 2!");

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapCarter();
app.Run();

namespace WebApi
{
    internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}

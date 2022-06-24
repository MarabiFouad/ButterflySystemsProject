using ButterflySystems.API.Middlewares;
using ButterflySystems.Core.IoC;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var env = Environment.GetEnvironmentVariable("ENV") ?? "dev";
var developmentEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";


var services = builder.Services;
var configuration = builder.Configuration;

if (string.Compare(developmentEnvironment, "Production", StringComparison.InvariantCultureIgnoreCase) == 0)
{
    // add cloud provider secret manager

    configuration.AddJsonFile($"appsettings.{env}.json", false, false);

    // cloud providers loging
}
else
{
    builder.Host.ConfigureLogging(logging =>
    {
        logging.ClearProviders();
        logging.AddConsole();
    });
    configuration.AddUserSecrets<Program>()
        .AddEnvironmentVariables();
}

services.InjectDependencies();

services.AddControllers();

services.AddEndpointsApiExplorer();

services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Butterfly Systems API",
        Description = "The API provided by ButterflySystems using CalculatorService",
        TermsOfService = new Uri("https://butterfly.systems/terms"),
        Contact = new OpenApiContact
        {
            Name = "Butterfly Systems API",
            Email = "info@butterfly.systems",
            Url = new Uri("https://butterfly.systems/contact"),
        },
        License = new OpenApiLicense
        {
            Name = "Butterfly Systems API license",
            Url = new Uri("https://butterfly.systems/license"),
        }
    });
    c.SwaggerDoc("v2", new OpenApiInfo
    {
        Version = "v2",
        Title = "Butterfly Systems API",
        Description = "The API provided by ButterflySystems using startegy and factory design patterns",
        TermsOfService = new Uri("https://butterfly.systems/terms"),
        Contact = new OpenApiContact
        {
            Name = "Butterfly Systems API",
            Email = "info@butterfly.systems",
            Url = new Uri("https://butterfly.systems/contact"),
        },
        License = new OpenApiLicense
        {
            Name = "Butterfly Systems API license",
            Url = new Uri("https://butterfly.systems/license"),
        }
    });
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});


// CORS policies
services.AddCors(options =>
{
    options.AddPolicy("Restricted",
        builder => builder.WithOrigins(configuration["CORS:Origin"].Split(",", StringSplitOptions.TrimEntries))
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials());
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

// Add API versioning to the Project
services.AddApiVersioning(config =>
    {
        // Specify the default API Version as 1.0
        config.DefaultApiVersion = new ApiVersion(1, 0);
        // If the client hasn't specified the API version in the request, use the default API version number 
        config.AssumeDefaultVersionWhenUnspecified = true;
        // Advertise the API versions supported for the particular endpoint
        config.ReportApiVersions = true;
    });


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint($"/swagger/v1/swagger.json", "ButterflySystems API V1");
                    c.SwaggerEndpoint($"/swagger/v2/swagger.json", "ButterflySystems API V2");
                });
}

// Use the CORS policy
app.UseCors(configuration["CORS:ActivePolicy"]);
app.UseMiddleware<ExceptionHandler>();
app.UseAuthorization();
app.MapControllers();

app.Run();

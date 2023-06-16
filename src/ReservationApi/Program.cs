using ReservationApi.sdk.Application;
using Orleans.Configuration;
using Orleans.Hosting;
using Orleans.Runtime;
using Microsoft.Extensions.Hosting;
using ReservationApi.Application;
using Toolbox.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

ApiOption option = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build()
    .Bind<ApiOption>();

builder.Host.UseOrleansClient(silobuilder =>
{
    silobuilder.UseLocalhostClustering();
});

builder.Logging.AddApplicationInsights(
    configureTelemetryConfiguration: (config) => config.ConnectionString = option.ApplicationInsightsConnectionString,
    configureApplicationInsightsLoggerOptions: (options) => { }
);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddReservation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapReservationApi();

Console.WriteLine($"Reservation API - Version {Assembly.GetExecutingAssembly().GetName().Version}");
Console.WriteLine();

app.Run();

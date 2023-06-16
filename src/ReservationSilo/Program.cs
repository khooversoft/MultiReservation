using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ReservationSilo.Application;
using Toolbox.Extensions;

SiloOption option = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build()
    .Bind<SiloOption>();

IHostBuilder builder = Host.CreateDefaultBuilder(args)
    .UseOrleans(silo =>
    {
        silo.UseLocalhostClustering()
            .ConfigureLogging(logging => logging.AddConsole())
            .AddAzureBlobGrainStorage("Customers", config =>
            {
                config.ConfigureBlobServiceClient(option.StorageAccountConnectionString);
            })
            .AddAzureBlobGrainStorage("PLan", config =>
            {
                config.ConfigureBlobServiceClient(option.StorageAccountConnectionString);
            });
    })
    .UseConsoleLifetime()
    .ConfigureLogging(config =>
    {
        config.AddApplicationInsights(
            configureTelemetryConfiguration: (config) => config.ConnectionString = option.ApplicationInsightsConnectionString,
            configureApplicationInsightsLoggerOptions: (options) => { }
        );
    });

using IHost host = builder.Build();

Console.WriteLine($"Reserveration Silo - Version {Assembly.GetExecutingAssembly().GetName().Version}");
Console.WriteLine();

await host.RunAsync();
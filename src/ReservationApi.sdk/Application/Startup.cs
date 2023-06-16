using Grains.Abstractions.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using ReservationApi.sdk.Connectors;
using ReservationApi.sdk.Endpoints;

namespace ReservationApi.sdk.Application;

public static class Startup
{
    public static IServiceCollection AddReservation(this IServiceCollection services)
    {
        services.AddSingleton<CustomerEndPoints>();
        services.AddSingleton<PlanEndPoints>();

        services.AddSingleton<CustomerConnector>();
        services.AddSingleton<PlanConnector>();

        return services;
    }

    public static void MapReservationApi(this IEndpointRouteBuilder app)
    {
        app.AddCustomer();
        app.AddPlan();
    }

    private static void AddCustomer(this IEndpointRouteBuilder app)
    {
        CustomerEndPoints endpoint = app.ServiceProvider.GetRequiredService<CustomerEndPoints>();

        var group = app.MapGroup("/customer");

        group.MapGet("/{customerId}", async (string customerId, CancellationToken token) => await endpoint.Get(customerId))
            .WithName("Read")
            .WithOpenApi();

        group.MapPost("/", async (CustomerModel customer, CancellationToken token) => await endpoint.Set(customer))
            .WithName("Write")
            .WithOpenApi();

        group.MapDelete("/{customerId}", async (string customerId, CancellationToken token) => await endpoint.Delete(customerId))
            .WithName("Delete")
            .WithOpenApi();
    }

    private static void AddPlan(this IEndpointRouteBuilder app)
    {
        PlanEndPoints endpoint = app.ServiceProvider.GetRequiredService<PlanEndPoints>();

        var group = app.MapGroup("/plan");

        group.MapGet("/{planId}", async (string planId, CancellationToken token) => await endpoint.Get(planId))
            .WithName("Read")
            .WithOpenApi();

        group.MapPost("/", async (PlaneModel plan, CancellationToken token) => await endpoint.Set(plan))
            .WithName("Write")
            .WithOpenApi();

        group.MapDelete("/{planId}", async (string planId, CancellationToken token) => await endpoint.Delete(planId))
            .WithName("Delete")
            .WithOpenApi();
    }
}

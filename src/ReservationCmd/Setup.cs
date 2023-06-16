using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ReservationApi.sdk.Client;
using ReservationCmd.Activities;
using ReservationCmd.Application;
using ReservationCmd.Commands;

namespace ReservationCmd;

internal static class Setup
{
    public static IServiceCollection AddApplication(this IServiceCollection services, CmdOption option)
    {
        services.AddSingleton(option);
        services.AddSingleton<CustomerCommand>();
        services.AddSingleton<PlaneCommands>();

        services.AddSingleton<CustomerAccess>();
        services.AddSingleton<PlaneAccess>();

        services.AddHttpClient<CustomerClient>((services, httpClient) =>
        {
            var option = services.GetRequiredService<CmdOption>();

            httpClient.BaseAddress = new Uri(option.ReservationUri);
        });
        
        services.AddHttpClient<PlaneClient>((services, httpClient) =>
        {
            var option = services.GetRequiredService<CmdOption>();

            httpClient.BaseAddress = new Uri(option.ReservationUri);
        });

        return services;
    }
}

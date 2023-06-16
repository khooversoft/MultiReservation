using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grains.Abstractions;
using Grains.Abstractions.Models;
using Microsoft.Extensions.Logging;
using Toolbox.Tools;
using Toolbox.Types;

namespace ReservationApi.sdk.Connectors;

internal class CustomerConnector : IConnector<CustomerModel>
{
    private readonly IClusterClient _client;
    private readonly ILogger<CustomerConnector> _logger;

    public CustomerConnector(IClusterClient client, ILogger<CustomerConnector> logger)
    {
        _client = client.NotNull();
        _logger = logger.NotNull();
    }

    public async Task<CustomerModel?> Get(string customerId)
    {
        _logger.LogInformation("Getting customer customerId={customerId}", customerId);

        ICustomer customerActor = _client.GetGrain<ICustomer>(customerId);
        return await customerActor.Get();
    }

    public async Task<StatusCode> Set(CustomerModel customer)
    {
        _logger.LogInformation("Setting customer customerId={customerId}", customer.CustomerId);

        ICustomer customerActor = _client.GetGrain<ICustomer>(customer.CustomerId);
        return await customerActor.Set(customer);
    }

    public async Task Delete(string customerId)
    {
        _logger.LogInformation("Deleting customer customerId={customerId}", customerId);

        ICustomer customerActor = _client.GetGrain<ICustomer>(customerId);
        await customerActor.Delete();
    }
}

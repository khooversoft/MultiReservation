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

internal class PlanConnector : IConnector<PlaneModel>
{
    private readonly IClusterClient _client;
    private readonly ILogger<PlanConnector> _logger;

    public PlanConnector(IClusterClient client, ILogger<PlanConnector> logger)
    {
        _client = client.NotNull();
        _logger = logger.NotNull();
    }

    public async Task<PlaneModel?> Get(string planId)
    {
        _logger.LogInformation("Getting plan planId={planId}", planId);

        IPlane planActor = _client.GetGrain<IPlane>(planId);
        return await planActor.Get();
    }

    public async Task<StatusCode> Set(PlaneModel plan)
    {
        _logger.LogInformation("Setting plane planId={planId}", plan.PlanId);

        IPlane planActor = _client.GetGrain<IPlane>(plan.PlanId);
        return await planActor.Set(plan);
    }

    public async Task Delete(string planId)
    {
        _logger.LogInformation("Deleting plan planId={planId}", planId);

        IPlane planActor = _client.GetGrain<IPlane>(planId);
        await planActor.Delete();
    }
}

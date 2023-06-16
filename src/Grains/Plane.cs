using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grains.Abstractions;
using Grains.Abstractions.Models;
using Microsoft.Extensions.Logging;
using Orleans.Runtime;
using Toolbox.Types;

namespace Grains;

public class Plane : Grain, IPlane
{
    private readonly IPersistentState<PlaneModel?> _state;
    private readonly ILogger<MillageAccount> _logger;

    public Plane(
        [PersistentState(stateName: "Plan", storageName: "Plans")] IPersistentState<PlaneModel?> state,
        ILogger<MillageAccount> logger
        )
    {
        _state = state;
        _logger = logger;
    }

    public async Task<PlaneModel?> Get()
    {
        _logger.LogInformation("Getting plane, planeId={planeId}", this.GetPrimaryKeyString());

        await _state.ReadStateAsync();

        if (!_state.RecordExists)
        {
            return null;
        }

        var option = _state.State switch
        {
            null => null,
            PlaneModel v => v,
        };

        return option;
    }

    public async Task<StatusCode> Set(PlaneModel plan)
    {
        try { plan.Verify(); }
        catch { return StatusCode.BadRequest; }

        string key = this.GetPrimaryKeyString();
        if (key != plan.PlanId) return StatusCode.BadRequest;

        _state.State = plan;
        await _state.WriteStateAsync();

        return StatusCode.OK;
    }

    public async Task Delete()
    {
        _state.State = null;
        await _state.WriteStateAsync();
    }
}

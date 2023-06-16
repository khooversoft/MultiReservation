using System.Reflection.Metadata;
using Grains.Abstractions.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ReservationApi.sdk.Connectors;
using Toolbox.Tools;
using Toolbox.Types;

namespace ReservationApi.sdk.Endpoints;

internal class PlanEndPoints : ConnectorAbstract<PlanConnector, PlaneModel>
{
    public PlanEndPoints(PlanConnector connector, ILogger<PlanEndPoints> logger)
        : base(connector, logger)
    {
    }
}

//internal class PlanEndPoints
//{
//    private readonly PlanConnector _connector;

//    public PlanEndPoints(PlanConnector actorConnector, ILogger<PlanEndPoints> logger)
//    {
//        _connector = actorConnector.NotNull();
//        Logger = logger.NotNull();
//    }

//    public ILogger<PlanEndPoints> Logger { get; }

//    public async Task<IResult> Get(string planId)
//    {
//        PlaneModel? result = await _connector.Get(planId);

//        return result switch
//        {
//            null => Results.NotFound(),
//            var v => Results.Ok(v),
//        };
//    }

//    public async Task<IResult> Set(PlaneModel planeModel)
//    {
//        var statusCode = await _connector.Set(planeModel);
//        return Results.StatusCode((int)statusCode.ToHttpStatusCode());
//    }

//    public async Task<IResult> Delete(string planId)
//    {
//        await _connector.Delete(planId);
//        return Results.Ok();
//    }
//}

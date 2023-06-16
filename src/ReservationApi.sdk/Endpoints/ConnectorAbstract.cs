using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grains.Abstractions.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ReservationApi.sdk.Connectors;
using Toolbox.Tools;
using Toolbox.Types;

namespace ReservationApi.sdk.Endpoints;

public class ConnectorAbstract<TConnector, TModel> where TConnector : IConnector<TModel>
{
    private readonly TConnector _connector;

    public ConnectorAbstract(TConnector connector, ILogger logger)
    {
        _connector = connector.NotNull();
        Logger = logger.NotNull();
    }

    public ILogger Logger { get; }

    public async Task<IResult> Get(string customerId)
    {
        TModel? result = await _connector.Get(customerId);

        return result switch
        {
            null => Results.NotFound(),
            var v => Results.Ok(v),
        };
    }

    public async Task<IResult> Set(TModel model)
    {
        var statusCode = await _connector.Set(model);
        return Results.StatusCode((int)statusCode.ToHttpStatusCode());
    }

    public async Task<IResult> Delete(string id)
    {
        await _connector.Delete(id);
        return Results.Ok();
    }

}

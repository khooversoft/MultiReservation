using System.Reflection.Metadata;
using Grains.Abstractions.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ReservationApi.sdk.Connectors;
using Toolbox.Tools;
using Toolbox.Types;

namespace ReservationApi.sdk.Endpoints;

internal class CustomerEndPoints : ConnectorAbstract<CustomerConnector, CustomerModel>
{
    public CustomerEndPoints(CustomerConnector connector, ILogger<CustomerEndPoints> logger)
        : base(connector, logger)
    {
    }
}


//internal class CustomerEndPoints : ConnectorAbstract<CustomerConnector, CustomerModel>
//{
//    private readonly CustomerConnector _connector;

//    public CustomerEndPoints(CustomerConnector actorConnector, ILogger<CustomerEndPoints> logger)
//    {
//        _connector = actorConnector.NotNull();
//        Logger = logger.NotNull();
//    }

//    public ILogger<CustomerEndPoints> Logger { get; }

//    public async Task<IResult> Get(string customerId)
//    {
//        CustomerModel? result = await _connector.Get(customerId);

//        return result switch
//        {
//            null => Results.NotFound(),
//            var v => Results.Ok(v),
//        };
//    }

//    public async Task<IResult> Set(CustomerModel customerModel)
//    {
//        var statusCode = await _connector.Set(customerModel);
//        return Results.StatusCode((int)statusCode.ToHttpStatusCode());
//    }

//    public async Task<IResult> Delete(string customerId)
//    {
//        await _connector.Delete(customerId);
//        return Results.Ok();
//    }
//}

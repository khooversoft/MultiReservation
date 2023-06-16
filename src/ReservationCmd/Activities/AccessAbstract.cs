using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grains.Abstractions.Models;
using Microsoft.Extensions.Logging;
using ReservationApi.sdk.Client;
using ReservationCmd.Application;
using Toolbox.Extensions;
using Toolbox.Tools;
using Toolbox.Types;

namespace ReservationCmd.Activities;

internal interface IAccess<T>
{
    Task Create(string file);
    Task Get(string id);
    Task Delete(string id);
}


internal class AccessAbstract<T> : IAccess<T>
{
    private readonly IClient<T> _client;
    private readonly ILogger _logger;

    public AccessAbstract(IClient<T> client, ILogger logger)
    {
        _client = client.NotNull();
        _logger = logger.NotNull();
    }

    public async Task Create(string file)
    {
        if (!File.Exists(file))
        {
            _logger.LogError("File={file} does not exist", file);
            return;
        }

        T customer = JsonFileTools.Read<T>(file).NotNull();

        _logger.LogInformation("Setting customer={customer}", customer.ToSafeJson(new ScopeContext(_logger)));

        StatusCode statusCode = await _client.Set(customer, new ScopeContext(_logger));
        _logger.LogInformation("StatusCode={statusCode}", statusCode);
    }

    public async Task Get(string id)
    {
        _logger.LogInformation("Getting id={id}", id);

        Option<T> result = await _client.Get(id, new ScopeContext(_logger));
        if (result.IsError())
        {
            _logger.LogError("Could not find customer customerId={customerId}", id);
            return;
        }

        T model = result.Return();

        _logger.LogInformation("Get model={model}, statusCode={statusCode}", model.ToJsonPascalSafe(new ScopeContext(_logger)), result.StatusCode);
    }

    public Task Delete(string id) => throw new NotImplementedException();

}

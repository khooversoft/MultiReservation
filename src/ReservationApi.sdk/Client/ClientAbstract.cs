using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grains.Abstractions.Models;
using Microsoft.Extensions.Logging;
using Toolbox.Rest;
using Toolbox.Tools;
using Toolbox.Types;

namespace ReservationApi.sdk.Client;

public interface IClient<T>
{
    Task<Option<T>> Get(string id, ScopeContext context);
    Task<StatusCode> Set(T model, ScopeContext context);
    Task<StatusCode> Delete(string id, ScopeContext context);
}


public class ClientAbstract<T> : IClient<T>
{
    private readonly HttpClient _httpClient;
    private readonly ILogger _logger;
    private readonly string _root;

    public ClientAbstract(HttpClient httpClient, string root, ILogger logger)
    {
        _httpClient = httpClient.NotNull();
        _logger = logger.NotNull();
        _root = root.NotEmpty();
    }

    public async Task<Option<T>> Get(string customerId, ScopeContext context) => await new RestClient(_httpClient)
        .SetPath($"{_root}/{customerId}")
        .GetAsync(context.With(_logger))
        .GetContent<T>();

    public async Task<StatusCode> Set(T model, ScopeContext context) => await new RestClient(_httpClient)
        .SetPath($"{_root}")
        .SetContent(model)
        .PostAsync(context.With(_logger))
        .GetStatusCode();

    public async Task<StatusCode> Delete(string id, ScopeContext context) => await new RestClient(_httpClient)
        .SetPath($"{_root}/{id}")
        .DeleteAsync(context.With(_logger))
        .GetStatusCode();
}

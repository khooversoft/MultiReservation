using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Grains.Abstractions.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ReservationApi.sdk.Client;
using ReservationCmd.Application;
using Toolbox.Extensions;
using Toolbox.Tools;
using Toolbox.Types;

namespace ReservationCmd.Activities;

internal class CustomerAccess : AccessAbstract<CustomerModel>
{
    public CustomerAccess(CustomerClient client, ILogger<CustomerAccess> logger)
        : base(client, logger)
    {
    }
}

//internal class CustomerAccess
//{
//    private readonly ILogger<CustomerAccess> _logger;
//    private readonly CustomerClient _client;

//    public CustomerAccess(CustomerClient client, ILogger<CustomerAccess> logger)
//    {
//        _client = client.NotNull();
//        _logger = logger.NotNull();
//    }

//    public async Task Create(string file)
//    {
//        if (!File.Exists(file))
//        {
//            _logger.LogError("File={file} does not exist", file);
//            return;
//        }

//        var customer = JsonFileTools.Read<CustomerModel>(file);

//        _logger.LogInformation("Setting customer={customer}", customer.ToSafeJson(new ScopeContext(_logger)));

//        StatusCode statusCode = await _client.Set(customer, new ScopeContext(_logger));
//        _logger.LogInformation("StatusCode={statusCode}", statusCode);
//    }

//    public async Task Get(string customerId)
//    {
//        _logger.LogInformation("Getting id={id}", customerId);

//        Option<CustomerModel> result = await _client.Get(customerId, new ScopeContext(_logger));
//        if (result.IsError())
//        {
//            _logger.LogError("Could not find customer customerId={customerId}", customerId);
//            return;
//        }

//        CustomerModel model = result.Return();

//        _logger.LogInformation("Get customer={customer}, statusCode={statusCode}", model.ToJsonPascalSafe(new ScopeContext(_logger)), result.StatusCode);
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Grains.Abstractions.Models;
using Microsoft.Extensions.Logging;
using Toolbox.Rest;
using Toolbox.Tools;
using Toolbox.Types;

namespace ReservationApi.sdk.Client;

public class CustomerClient : ClientAbstract<CustomerModel>
{
    public CustomerClient(HttpClient httpClient, ILogger<CustomerClient> logger)
        : base(httpClient, "customer", logger)
    {
    }
}

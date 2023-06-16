using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grains.Abstractions.Models;
using Toolbox.Types;

namespace ReservationApi.sdk.Connectors;

public interface IConnector<T>
{
    Task<T?> Get(string id);
    Task<StatusCode> Set(T plan);
    Task Delete(string id);
}

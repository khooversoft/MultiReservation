using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grains.Abstractions.Models;
using Toolbox.Types;

namespace Grains.Abstractions;

public interface ICustomer : IGrainWithStringKey
{
    Task<CustomerModel?> Get();
    Task<StatusCode> Set(CustomerModel customer);
    Task Delete();
}

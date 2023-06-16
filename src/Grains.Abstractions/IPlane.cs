using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grains.Abstractions.Models;
using Toolbox.Types;

namespace Grains.Abstractions;

public interface IPlane : IGrainWithStringKey
{
    Task<PlaneModel?> Get();
    Task<StatusCode> Set(PlaneModel plan);
    Task Delete();
}

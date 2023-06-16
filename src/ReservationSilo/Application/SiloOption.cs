using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toolbox.Tools;

namespace ReservationSilo.Application;

public record SiloOption
{
    public string StorageAccountConnectionString { get; init; } = null!;
    public string ApplicationInsightsConnectionString { get; init; } = null!;
}


public static class SiloOptionExtensions
{
    public static SiloOption Verify(this SiloOption option)
    {
        option.NotNull();
        option.StorageAccountConnectionString.NotEmpty();

        return option;
    }
}
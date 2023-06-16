using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toolbox.Tools;

namespace ReservationCmd.Application;

internal record CmdOption
{
    public string ReservationUri { get; init; } = null!;
}


internal static class CmdOptionExtensions
{
    public static CmdOption Verify(this CmdOption option)
    {
        option.NotNull();
        option.ReservationUri.NotEmpty();

        return option;
    }
}

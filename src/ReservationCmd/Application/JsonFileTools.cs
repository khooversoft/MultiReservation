using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grains.Abstractions.Models;
using Toolbox.Tools;

namespace ReservationCmd.Application;

internal static class JsonFileTools
{
    public static T Read<T>(string file)
    {
        file.NotEmpty();
        string subject = File.ReadAllText(file);

        return Json.Default.Deserialize<T>(subject).NotNull();
    }
}

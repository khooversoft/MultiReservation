using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ReservationCmd.Activities;
using Toolbox.Tools;

namespace ReservationCmd.Commands;

internal interface ICommandAbstract
{
}

internal class CommandAbstract<T> : Command, ICommandAbstract
{
    private readonly IAccess<T> _client;
    private readonly ILogger _logger;
    private readonly string _name;

    public CommandAbstract(string command, string description, string name, IAccess<T> client, ILogger logger)
        : base(command, description)
    {
        _name = name.NotEmpty();
        _client = client.NotNull();
        _logger = logger.NotNull();

        AddCommand(CreateCommand());
        AddCommand(GetCommand());
    }

    private Command CreateCommand()
    {
        var cmd = new Command("set", $"Create or update {_name}");
        Argument<string> file = new Argument<string>("file", $"Json file for {_name} data");

        cmd.AddArgument(file);

        cmd.SetHandler(_client.Create, file);

        return cmd;
    }

    public Command GetCommand()
    {
        var cmd = new Command("get", $"Get {_name}");
        Argument<string> idArgument = new Argument<string>("id", $"Id of the {_name}");

        cmd.AddArgument(idArgument);

        cmd.SetHandler(_client.Get, idArgument);
        return cmd;
    }
}

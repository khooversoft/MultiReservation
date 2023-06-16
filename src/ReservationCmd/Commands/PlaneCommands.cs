using System.CommandLine;
using Grains.Abstractions.Models;
using Microsoft.Extensions.Logging;
using ReservationCmd.Activities;
using Toolbox.Tools;

namespace ReservationCmd.Commands;

internal class PlaneCommands : CommandAbstract<PlaneModel>
{
    public PlaneCommands(PlaneAccess client, ILogger<PlaneCommands> logger)
        : base("plane", "Create, update, or get plane info", "plane", client, logger)
    {
    }
}


//internal class PlaneCommands : Command
//{
//    private readonly PlaneAccess _client;
//    private readonly ILogger<PlaneCommands> _logger;

//    public PlaneCommands(PlaneAccess client, ILogger<PlaneCommands> logger)
//        : base("customer", "Create or Edit customer info")
//    {
//        _client = client.NotNull();
//        _logger = logger.NotNull();

//        AddCommand(CreateCommand());
//        AddCommand(EditCommand());
//        AddCommand(GetCommand());
//    }

//    private Command CreateCommand()
//    {
//        var cmd = new Command("set", "Create or update plane");
//        Argument<string> file = new Argument<string>("file", "Json file for plane data");

//        cmd.AddArgument(file);

//        cmd.SetHandler(_client.Create, file);

//        return cmd;
//    }

//    private Command EditCommand()
//    {
//        var cmd = new Command("edit", "Edit customer");
//        var name = new Option<string>("--name", "Provide a new name");

//        Argument<string> idArgument = new Argument<string>("customerId", "Id of the customer");

//        cmd.AddArgument(idArgument);

//        cmd.SetHandler(id =>
//        {
//            Console.WriteLine($"Id={id}");
//        }, idArgument);

//        return cmd;
//    }

//    public Command GetCommand()
//    {
//        var cmd = new Command("get", "Get customer");
//        Argument<string> idArgument = new Argument<string>("customerId", "Id of the customer");

//        cmd.AddArgument(idArgument);

//        cmd.SetHandler(_client.Get, idArgument);
//        return cmd;
//    }
//}

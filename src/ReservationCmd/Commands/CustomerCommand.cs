using System.CommandLine;
using Grains.Abstractions.Models;
using Microsoft.Extensions.Logging;
using ReservationCmd.Activities;
using Toolbox.Tools;

namespace ReservationCmd.Commands;

internal class CustomerCommand : CommandAbstract<CustomerModel>
{
    public CustomerCommand(CustomerAccess client, ILogger<CustomerCommand> logger)
        : base("customer", "\"Create, update, or get customer info", "customer", client, logger)
    {
    }
}


//internal class CustomerCommand : Command
//{
//    private readonly CustomerAccess _client;
//    private readonly ILogger<CustomerCommand> _logger;

//    public CustomerCommand(CustomerAccess client, ILogger<CustomerCommand> logger)
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
//        var cmd = new Command("set", "Create or update customer");
//        Argument<string> file = new Argument<string>("file", "Json file for customer data");

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

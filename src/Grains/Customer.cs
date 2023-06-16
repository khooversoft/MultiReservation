using Grains.Abstractions;
using Grains.Abstractions.Models;
using Microsoft.Extensions.Logging;
using Orleans.Runtime;
using Toolbox.Extensions;
using Toolbox.Types;

namespace Grains;

public class Customer : Grain, ICustomer
{
    private readonly IPersistentState<CustomerModel?> _state;
    private readonly ILogger<Customer> _logger;

    public Customer(
        [PersistentState(stateName: "Customer", storageName: "Customers")] IPersistentState<CustomerModel?> state,
        ILogger<Customer> logger
        )
    {
        _state = state;
        _logger = logger;
    }

    public async Task<CustomerModel?> Get()
    {
        _logger.LogInformation("Getting customer, customerId={customerId}", this.GetPrimaryKeyString());

        await _state.ReadStateAsync();

        if (!_state.RecordExists)
        {
            return null;
        }

        var option = _state.State switch
        {
            null => null,
            CustomerModel v => v,
        };

        return option;
    }

    public async Task<StatusCode> Set(CustomerModel customer)
    {
        _logger.LogInformation("Setting customer customer={customer}", customer.ToJsonPascalSafe(new ScopeContext(_logger)));

        try { customer.Verify(); }
        catch { return StatusCode.BadRequest; }

        string key = this.GetPrimaryKeyString();
        if (key != customer.CustomerId) return StatusCode.BadRequest;

        _state.State = customer;
        await _state.WriteStateAsync();

        return StatusCode.OK;
    }

    public async Task Delete()
    {
        _logger.LogInformation("Deleting customer customerId={customerId}", this.GetPrimaryKeyString());

        _state.State = null;
        await _state.WriteStateAsync();
    }
}

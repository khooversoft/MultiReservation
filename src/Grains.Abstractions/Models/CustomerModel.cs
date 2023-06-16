using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toolbox.Extensions;
using Toolbox.Tools;

namespace Grains.Abstractions.Models;

[GenerateSerializer, Immutable]
public record CustomerModel
{
    [Id(0)]
    public string CustomerId { get; init; } = null!;
    [Id(1)]
    public string CustomerName { get; init; } = null!;
    [Id(2)]
    public Address? HomeAddress { get; init; }
    [Id(3)]
    public Address? BillAddress { get; init; }
    [Id(4)]
    public IReadOnlyList<Phone> Phones { get; init; } = Array.Empty<Phone>();
}

[GenerateSerializer, Immutable]
public record Address
{
    [Id(0)]
    public string Type { get; init; } = null!;
    [Id(1)]
    public string Line1 { get; init; } = null!;
    [Id(2)]
    public string? Line2 { get; init; }
    [Id(3)]
    public string? Country { get; init; }
    [Id(4)]
    public string City { get; init; } = null!;
    [Id(5)]
    public string State { get; init; } = null!;
    [Id(6)]
    public string ZipCode { get; init; } = null!;
}

[GenerateSerializer, Immutable]
public record Phone
{
    [Id(0)]
    public string Type { get; init; } = null!;
    [Id(1)]
    public string Number { get; init; } = null!;
}

public static class CustomerModelExtensions
{
    public static CustomerModel Verify(this CustomerModel subject)
    {
        subject.NotNull();
        subject.CustomerId.NotEmpty();
        subject.CustomerName.NotEmpty();

        subject.HomeAddress?.Verify();
        subject.BillAddress?.Verify();

        subject.Phones.NotNull();
        subject.Phones.ForEach(x => x.Verify());

        return subject;
    }

    public static Address Verify(this Address subject)
    {
        subject.NotNull();
        subject.Type.NotEmpty();
        subject.Line1.NotEmpty();
        subject.City.NotEmpty();
        subject.State.NotEmpty();
        subject.ZipCode.NotEmpty();

        return subject;
    }

    public static Phone Verify(this Phone subject)
    {
        subject.NotNull();
        subject.Type.NotEmpty();
        subject.Number.NotEmpty();

        return subject;
    }
}
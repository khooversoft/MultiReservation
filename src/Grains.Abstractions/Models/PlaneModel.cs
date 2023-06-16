using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toolbox.Tools;

namespace Grains.Abstractions.Models;

[GenerateSerializer, Immutable]
public record PlaneModel
{
    [Id(0)]
    public string PlanId { get; init; } = null!;
    [Id(1)]
    public string PlanName { get; init; } = null!;
    [Id(2)]
    public IReadOnlyList<string> SeatIds { get; init; } = Array.Empty<string>();
}


public static class PlaneModelExtensions
{
    public static PlaneModel Verify(this PlaneModel model)
    {
        model.NotNull();
        model.PlanId.NotEmpty();
        model.PlanName.NotEmpty();
        model.SeatIds.NotNull();

        return model;
    }
}
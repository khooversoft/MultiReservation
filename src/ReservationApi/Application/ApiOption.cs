using Toolbox.Tools;

namespace ReservationApi.Application;

public record ApiOption
{
    public string ApplicationInsightsConnectionString { get; init; } = null!;
}


public static class ApiOptionExtensions
{
    public static ApiOption Verify(this ApiOption option)
    {
        option.NotNull();
        option.ApplicationInsightsConnectionString.NotEmpty();

        return option;
    }
}
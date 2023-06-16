using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Toolbox.Extensions;

public static class StringExtensions
{
    /// <summary>
    /// Is string null or just white spaces
    /// </summary>
    /// <param name="subject">subject</param>
    /// <returns>true or false</returns>
    public static bool IsEmpty([NotNullWhen(false)] this string? subject) => string.IsNullOrWhiteSpace(subject);

    /// <summary>
    /// Is string null or just white spaces
    /// </summary>
    /// <param name="subject">subject</param>
    /// <returns>true or false</returns>
    public static bool IsNotEmpty([NotNullWhen(false)] this string? subject) => !string.IsNullOrWhiteSpace(subject);

    /// <summary>
    /// Convert to null if string is "empty"
    /// </summary>
    /// <param name="subject">subject to test</param>
    /// <returns>null or subject</returns>
    public static string? ToNullIfEmpty(this string? subject) => string.IsNullOrWhiteSpace(subject) ? null : subject;

    /// <summary>
    /// Join vector(s) to string with string delimiter
    /// </summary>
    /// <param name="values">values</param>
    /// <param name="delimiter">delimiter to use in join</param>
    /// <returns>result</returns>
    public static string Join(this IEnumerable<string?> values, string delimiter = "") => string.Join(delimiter, values.Where(x => x != null));

    /// <summary>
    /// Join vector(s) to string with character delimiter
    /// </summary>
    /// <param name="values"></param>
    /// <param name="delimiter"></param>
    /// <returns></returns>
    public static string Join(this IEnumerable<string?> values, char delimiter) => string.Join(delimiter, values.Where(x => x != null));

    /// <summary>
    /// Ignore case equals
    /// </summary>
    /// <param name="subject">subject to compare</param>
    /// <param name="value">value to compare to</param>
    /// <returns>true or false</returns>
    public static bool EqualsIgnoreCase(this string subject, string value) => subject.Equals(value, StringComparison.OrdinalIgnoreCase);

    /// <summary>
    /// Truncate a string based on max length value
    /// </summary>
    /// <param name="subject">string or null</param>
    /// <param name="maxLength">max length allowed, must be positive or defaults to 0</param>
    /// <returns>truncate string if required</returns>
    [DebuggerStepThrough]
    [return: NotNullIfNotNull(nameof(subject))]
    public static string? Truncate(this string? subject, int maxLength) => subject switch
    {
        null => null,
        string v => v[..Math.Min(v.Length, Math.Max(maxLength, 0))],
    };
}
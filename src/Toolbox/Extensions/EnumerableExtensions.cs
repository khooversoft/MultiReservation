using Toolbox.Tools;

namespace Toolbox.Extensions;

public static class EnumerableExtensions
{
    /// <summary>
    /// Convert a scalar value to enumerable
    /// </summary>
    /// <typeparam name="T">type</typeparam>
    /// <param name="self">object to convert</param>
    /// <returns>enumerator</returns>
    public static IEnumerable<T> ToEnumerable<T>(this T self)
    {
        yield return self;
    }

    /// <summary>
    /// Execute 'action' on each item
    /// </summary>
    /// <typeparam name="T">type</typeparam>
    /// <param name="subjects">types to process</param>
    /// <param name="action">action to execute</param>
    public static void ForEach<T>(this IEnumerable<T> subjects, Action<T> action)
    {
        subjects.NotNull();
        action.NotNull();

        foreach (var item in subjects)
        {
            action(item);
        }
    }

    /// <summary>
    /// Execute 'action' on each item
    /// </summary>
    /// <typeparam name="T">type</typeparam>
    /// <param name="subjects">list to operate on</param>
    /// <param name="action">action to execute</param>
    public static void ForEach<T>(this IEnumerable<T> subjects, Action<T, int> action)
    {
        subjects.NotNull();
        action.NotNull();

        int index = 0;
        foreach (var item in subjects)
        {
            action(item, index++);
        }
    }

    /// <summary>
    /// Execute 'action' on each item
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="subjects"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    public static async Task ForEachAsync<T>(this IEnumerable<T> subjects, Func<T, Task> action)
    {
        subjects.NotNull();
        action.NotNull();

        foreach (var item in subjects)
        {
            await action(item);
        }
    }

    /// <summary>
    /// Collection with index to be used with ForEach(...)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    public static IEnumerable<(T Item, int Index)> WithIndex<T>(this IEnumerable<T> source) => source
        .NotNull()
        .Select((item, index) => (item, index));
}

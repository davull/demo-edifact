namespace Edifact.App;

public static class Extensions
{
    public static IEnumerable<TOut> Foreach<TIn, TOut>(this IEnumerable<TIn> source, Func<TIn, TOut> action)
    {
        return source.Select(action);
    }

    public static void Foreach<TIn>(this IEnumerable<TIn> source, Action<TIn> action)
    {
        foreach (var item in source) action(item);
    }
}
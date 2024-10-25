namespace CupKeeper.Extensions;

public static class EnumerableExtensions
{
    public static (int lowest, int secondLowest) Min2(this IEnumerable<int> enumerable)
    {
        return enumerable.Min2((i) => i);
    }

    public static (int lowest, int secondLowest) Min2<T>(this IEnumerable<T> enumerable, Func<T, int> getValue)
    {
        if (enumerable.Count() == 0)
        {
            return (0, 0);
        }
        else if (enumerable.Count() == 1)
        {
            return (getValue(enumerable.First()), 0);
        }

        var first = int.MaxValue;
        var second = int.MaxValue;

        foreach (var element in enumerable)
        {
            var val = getValue(element);
            if (val <= first)
            {
                second = first;
                first = val;
            }
            else if (val < second && val != first)
            {
                second = val;
            }
        }

        return (lowest: first, secondLowest: second);
    }
}

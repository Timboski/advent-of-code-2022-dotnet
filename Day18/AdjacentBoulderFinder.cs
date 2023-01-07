namespace Day18;

public static class AdjacentBoulderFinder
{
    public static int CountAdjacentBoulders(this IEnumerable<Boulder> boulders, Axis axis)
    {
        var sorted = boulders.OrderBy(b => b.GetValue(axis));
        if (sorted.Count() < 2) return 0;

        var count = 0;
        var current = sorted.First().GetValue(axis);
        foreach (var boulder in sorted.Skip(1))
        {
            var axisValue = boulder.GetValue(axis);
            if (axisValue == current + 1) count++;
            current = axisValue;
        }

        return count;
    }
}

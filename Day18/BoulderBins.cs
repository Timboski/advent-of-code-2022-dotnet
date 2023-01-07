namespace Day18;

public static class BoulderBins
{
    public static IEnumerable<IEnumerable<Boulder>> SortIntoBins(this IEnumerable<Boulder> boulders, Axis axis)
    {
        var bins = new Dictionary<int, List<Boulder>>();
        foreach (var boulder in boulders)
        {
            var key = boulder.GetValue(axis);
            if (!bins.ContainsKey(key)) bins[key] = new List<Boulder>();
            bins[key].Add(boulder);
        }

        return bins.Values;
    }
}

namespace Day18;

public static class TrappedAir
{
    public static IEnumerable<Boulder> FindTrappedAir(this IEnumerable<Boulder> boulders)
    {
        var potentialX = boulders.SortIntoBins(Axis.Y)
            .SelectMany(b => b.SortIntoBins(Axis.Z))
            .Where(b => b.Count() > 1)
            .SelectMany(b => b.FindGaps(Axis.X))
            .Select(g => g.ToTuple())
            .ToHashSet();

        var potentialXY = boulders.SortIntoBins(Axis.X)
            .SelectMany(b => b.SortIntoBins(Axis.Z))
            .Where(b => b.Count() > 1)
            .SelectMany(b => b.FindGaps(Axis.Y))
            .Select(g => g.ToTuple())
            .Where(potentialX.Contains)
            .ToHashSet();

        var potentialXYZ = boulders.SortIntoBins(Axis.X)
            .SelectMany(b => b.SortIntoBins(Axis.Y))
            .Where(b => b.Count() > 1)
            .SelectMany(b => b.FindGaps(Axis.Z))
            .Select(g => g.ToTuple())
            .Where(potentialXY.Contains)
            .ToHashSet();

        // TODO: Check that potential gaps are fully enclosed.

        return potentialXYZ.Select(t => new Boulder(t));
    }
    private static IEnumerable<Boulder> FindGaps(this IEnumerable<Boulder> boulders, Axis axis)
    {
        var sorted = boulders.OrderBy(b => b.GetValue(axis));
        var startEdge = sorted.First().GetValue(axis);
        foreach (var boulder in sorted.Skip(1))
        {
            var endEdge = boulder.GetValue(axis);
            for (int i = startEdge + 1; i < endEdge; i++)
            {
                yield return new Boulder(boulder, axis, i);
            }

            startEdge = endEdge;
        }
    }
}

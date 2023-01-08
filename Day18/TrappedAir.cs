namespace Day18;

public static class TrappedAir
{
    public static IEnumerable<Boulder> FindTrappedAir(this IEnumerable<Boulder> boulders)
    {
        var potentialX = boulders
            .FindGapsBetweenBoulders(Axis.X, Axis.Y, Axis.Z)
            .ToHashSet();

        var potentialXY = boulders
            .FindGapsBetweenBoulders(Axis.Y, Axis.X, Axis.Z)
            .Where(potentialX.Contains)
            .ToHashSet();

        var potentialXYZ = boulders
            .FindGapsBetweenBoulders(Axis.Z, Axis.X, Axis.Y)
            .Where(potentialXY.Contains);

        // TODO: Check that potential gaps are fully enclosed.

        return potentialXYZ.Select(t => new Boulder(t));
    }
    private static IEnumerable<(int X, int Y, int Z)> FindGapsBetweenBoulders(this IEnumerable<Boulder> boulders, Axis axis1, Axis axis2, Axis axis3)
        => boulders.SortIntoBins(axis2)
            .SelectMany(b => b.SortIntoBins(axis3))
            .Where(b => b.Count() > 1)
            .SelectMany(b => b.FindGaps(axis1))
            .Select(g => g.ToTuple());

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

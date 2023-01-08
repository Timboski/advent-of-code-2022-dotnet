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
            .Where(potentialXY.Contains)
            .ToHashSet();

        var rock = boulders.Select(b => b.ToTuple()).ToHashSet();
        while (true)
        {
            var changed = false;
            foreach (var gap in potentialXYZ)
            {
                // Check if totally enclosed (either boulder or another gap).
                var checkPositions = new[] {
                    (gap.X + 1, gap.Y, gap.Z),
                    (gap.X - 1, gap.Y, gap.Z),
                    (gap.X, gap.Y + 1, gap.Z),
                    (gap.X, gap.Y -1, gap.Z),
                    (gap.X, gap.Y, gap.Z + 1),
                    (gap.X, gap.Y, gap.Z - 1)
                };

                if (checkPositions.Any(p => !rock.Contains(p) && !potentialXYZ.Contains(p)))
                {
                    // Not fully enclosed. Remove from potential gaps.
                    changed = true;
                    potentialXYZ.Remove(gap);
                }
            }

            if (!changed) return potentialXYZ.Select(t => new Boulder(t));
        }
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

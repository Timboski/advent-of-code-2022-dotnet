namespace Day18;

public static class SurfaceAreaFinder
{
    public static int FindArea(string filename)
    {
        var boulders = File.ReadAllLines(filename).Select(l => new Boulder(l));
        return FindAreaOfBoulders(boulders);
    }

    public static int FindExternalArea(string filename)
    {
        var boulders = File.ReadAllLines(filename).Select(l => new Boulder(l));
        var trappedAir = boulders.FindTrappedAir();
        var solidBoulders = boulders.Concat(trappedAir); // Fill in the air gaps so internal edges not counted
        return FindAreaOfBoulders(solidBoulders);
    }

    private static int FindAreaOfBoulders(IEnumerable<Boulder> boulders)
    {
        // Initial area - assuming no touching
        var area = boulders.Count() * 6;

        var adjacentX = FindAdjacent(boulders, Axis.Y, Axis.Z, Axis.X);
        var adjacentY = FindAdjacent(boulders, Axis.X, Axis.Z, Axis.Y);
        var adjacentZ = FindAdjacent(boulders, Axis.X, Axis.Y, Axis.Z);
        var sidesTouching = adjacentX + adjacentY + adjacentZ;

        return area - (sidesTouching * 2);
    }

    private static int FindAdjacent(IEnumerable<Boulder> boulders, Axis firstAxis, Axis secondAxis, Axis thirdAxis) 
        => boulders
            .SortIntoBins(firstAxis)
            .SelectMany(b => b.SortIntoBins(secondAxis))
            .Select(b => b.CountAdjacentBoulders(thirdAxis))
            .Sum();
}

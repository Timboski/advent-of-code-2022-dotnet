namespace Day5;

public static class ShipLoader
{
    public static void LoadCrates(Ship ship, IEnumerable<string> lines)
    {
        var picture = lines.TakeWhile(line => line.Length > 0);
        AddCrates(ship, picture);
    }

    public static void AddCrates(Ship ship, IEnumerable<string> picture)
    {
        foreach (var row in picture.Reverse().Skip(1)) AddCrates(ship, row);
    }

    public static void AddCrates(Ship ship, string rowOfCrates)
    {
        var crates = rowOfCrates
                .Chunk(4)
                .Select((value, index) => new
                {
                    stackIndex = index + 1, // Stacks are 1 based
                    crateMarker = value[1]
                }) // Ignore rest of picture "[x] "
                .Where(a => !char.IsWhiteSpace(a.crateMarker));

        foreach (var crate in crates) ship.AddCrate(crate.stackIndex, crate.crateMarker);
    }
}

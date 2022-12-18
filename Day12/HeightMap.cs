namespace Day12;

public class HeightMap
{
    public HeightMap(List<string> map)
    {
        foreach (var line in map)
            if (line.Contains('S')) return;

        throw new NoStartException();
    }

    public bool IsComplete => true;
}

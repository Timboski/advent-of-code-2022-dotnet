namespace Day8;

public class TreeRow
{
    private readonly string _row;

    public TreeRow(string row) => _row = row;

    public bool IsVisibleFromLeft(int index)
        => CheckAllShorter(_row[0..index], _row[index]);

    public bool IsVisibleFromRight(int index)
        => CheckAllShorter(_row[(index + 1)..^0], _row[index]);

    private static bool CheckAllShorter(IEnumerable<char> trees, char height)
        => !trees.Where(h => h >= height).Any();
}

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

    public int VisibleTreesToLeft(int index)
    {
        var height = _row[index];
        var count = 0;
        for (var i = index - 1; i >= 0; --i) 
        {
            ++count;
            if (_row[i] >= height) return count;
        }

        return count;
    }
}

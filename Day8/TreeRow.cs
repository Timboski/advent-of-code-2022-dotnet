using System;

namespace Day8;

public class TreeRow
{
    private string _row;

    public TreeRow(string row) => _row = row;

    public bool IsVisibleFromLeft(int index)
        => CheckAllShorter(_row.Take(index), _row[index]);

    public bool IsVisibleFromRight(int index)
        => CheckAllShorter(_row.Skip(index + 1), _row[index]);

    private static bool CheckAllShorter(IEnumerable<char> trees, char height)
        => !trees.Where(h => h >= height).Any();
}

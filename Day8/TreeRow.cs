namespace Day8;

public class TreeRow
{
    private string _row;

    public TreeRow(string row) => _row = row;

    public bool IsVisibleFromLeft(int index) 
        => !_row.Take(index).Where(h => h >= _row[index]).Any();
}

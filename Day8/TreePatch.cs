namespace Day8;

public class TreePatch
{
    private readonly List<TreeRow> _row;
    private readonly List<TreeColumn> _column = new();

    public TreePatch(string[] rows)
    {
        _row = rows.Select(row => new TreeRow(row)).ToList();
        for (int i = 0; i < rows[0].Length; ++i)
        {
            var column = string.Join(null, 
                Enumerable.Range(0, rows.Length)
                    .Select(j => rows[j][i]));

            _column.Add(new TreeColumn(column));
        }
    }

    public int CountVisible()
    {
        var count = 0;
        for (var row = 0; row < _row.Count; ++row) 
        {
            for (var column = 0; column< _column.Count; ++column) 
            {
                if (TreeVisible(row, column)) ++count;
            }
        }
        return count;
    }

    private bool TreeVisible(int row, int column)
    {
        if (_row[row].IsVisibleFromLeft(column)) return true;
        if (_row[row].IsVisibleFromRight(column)) return true;
        if (_column[column].IsVisibleFromTop(row)) return true;
        if (_column[column].IsVisibleFromBottom(row)) return true;
        return false;
    }

    public int GetMaxScenicScore()
    {
        var maxScore = 0;
        for (var row = 0; row < _row.Count; ++row)
        {
            for (var column = 0; column < _column.Count; ++column)
            {
                maxScore = Math.Max(maxScore, ComputeScenicScore(row, column));
            }
        }
        return maxScore;
    }

    private int ComputeScenicScore(int row, int column)
    {
        var left = _row[row].VisibleTreesToLeft(column);
        var right = _row[row].VisibleTreesToRight(column);
        var up = _column[column].VisibleTreesToTop(row);
        var down = _column[column].VisibleTreesToBottom(row);
        return left * right * up * down;
    }
}

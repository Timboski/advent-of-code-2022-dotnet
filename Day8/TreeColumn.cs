namespace Day8;

public class TreeColumn
{
    private readonly TreeRow _column;

    public TreeColumn(string column) => _column = new(column);

    public bool IsVisibleFromTop(int index)
        => _column.IsVisibleFromLeft(index);

    public bool IsVisibleFromBottom(int index)
        => _column.IsVisibleFromRight(index);

    public object VisibleTreesToTop(int index)
        => _column.VisibleTreesToLeft(index);

    public object VisibleTreesToBottom(int index)
        => _column.VisibleTreesToRight(index);
}

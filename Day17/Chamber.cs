namespace Day17;

public class Chamber
{
    private HorizontalShape _shape;
    private int _top = 1;

    public Chamber(HorizontalShape horizontalShape)
    {
        _shape = horizontalShape;
        _shape.SetBottomPos(_top + 3);
    }

    public override string ToString() 
        => string.Join(Environment.NewLine, 
            Enumerable.Range(0, Top).Reverse().Select(GetLine));

    public int Top => Math.Max(_top, _shape.Top);

    private string GetLine(int pos)
	{
		if (pos == 0) return "+-------+";

        const string EmptyLine = "|.......|";
        return _shape?.GetLine(pos, EmptyLine) ?? EmptyLine;
    }
}

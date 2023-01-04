namespace Day17;

public class Chamber
{
    private readonly ShapeFactory _shapeFactory;
    private HorizontalShape _shape;
    private int _top = 1;

    public Chamber(ShapeFactory shapeFactory)
    {
        _shapeFactory = shapeFactory;
        _shape = _shapeFactory.Create(_top + 3);
    }

    public override string ToString() 
        => string.Join(Environment.NewLine, 
            Enumerable.Range(0, Top).Reverse().Select(GetLine));

    public int Top => Math.Max(_top, _shape.Top);

    public void MoveRightIfClear()
    {
        var bottom = _shape.Bottom;
        var pos = _shape.Left + 1;
        var backgroundLines = GetBackgroundLines(bottom, _shape.Height);

        bool isCollision = _shape.IsCollision(pos, backgroundLines);
        if (!isCollision) _shape.MoveRight();
    }

    public void MoveLeftIfClear()
    {
        var bottom = _shape.Bottom;
        var pos = _shape.Left - 1;
        var backgroundLines = GetBackgroundLines(bottom, _shape.Height);

        bool isCollision = _shape.IsCollision(pos, backgroundLines);
        if (!isCollision) _shape.MoveLeft();
    }

    public void TryMoveDown()
        => _shape.MoveDown();

    private string GetLine(int pos) 
        => _shape.GetLine(pos, GetBackgroundLine(pos));

    private string GetBackgroundLine(int pos) 
        => pos == 0 ? "+-------+" : "|.......|";

    private string[] GetBackgroundLines(int bottom, int numLines) 
        => Enumerable.Range(bottom, numLines)
            .Select(GetBackgroundLine)
            .ToArray();
}

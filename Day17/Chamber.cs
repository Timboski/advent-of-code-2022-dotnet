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
        if (!IsCollision(_shape.Bottom, _shape.Left + 1))
            _shape.MoveRight();
    }

    public void MoveLeftIfClear()
    {
        if (!IsCollision(_shape.Bottom, _shape.Left - 1)) 
            _shape.MoveLeft();
    }

    public bool TryMoveDown()
    {
        var canMove = !IsCollision(_shape.Bottom - 1, _shape.Left);
        if (canMove) _shape.MoveDown();
        return canMove;
    }

    private bool IsCollision(int bottom, int pos)
    {
        var backgroundLines = GetBackgroundLines(bottom, _shape.Height);

        bool isCollision = _shape.IsCollision(pos, backgroundLines);
        return isCollision;
    }

    private string GetLine(int pos) 
        => _shape.GetLine(pos, GetBackgroundLine(pos));

    private string GetBackgroundLine(int pos) 
        => pos == 0 ? "+-------+" : "|.......|";

    private string[] GetBackgroundLines(int bottom, int numLines) 
        => Enumerable.Range(bottom, numLines)
            .Select(GetBackgroundLine)
            .ToArray();
}

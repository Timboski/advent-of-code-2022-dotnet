namespace Day17;

public class Chamber
{
    private readonly ShapeFactory _shapeFactory;
    private readonly Dictionary<long, string> _lines = new();
    private readonly IRockShape _nullShape = new NullRock();
    private IRockShape _shape;
    private long _top = 1;

    public Chamber(ShapeFactory shapeFactory)
    {
        _shapeFactory = shapeFactory;
        _shape = _nullShape;
        _lines[0] = "+-------+";
    }

    public override string ToString()
        => string.Join(Environment.NewLine, 
            Enumerable.Range(0, (int)Top)
                .Reverse()
                .Select(i => (long)i)
                .Select(GetLine));

    public long Top => Math.Max(_top, _shape.Top);

    public void AddRock() 
        => _shape = _shapeFactory.Create(_top + 3);

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

    public void RestShape()
    {
        for (long i = _shape.Bottom; i < _shape.Top; i++)
        {
            _lines[i] = _shape.GetLine(i, GetBackgroundLine(i), '#');
        }
        _top = Top;
        _shape = _nullShape;
    }

    private bool IsCollision(long bottom, int pos)
    {
        var backgroundLines = GetBackgroundLines(bottom, _shape.Height);

        bool isCollision = _shape.IsCollision(pos, backgroundLines);
        return isCollision;
    }

    private string GetLine(long pos) 
        => _shape.GetLine(pos, GetBackgroundLine(pos));

    private string GetBackgroundLine(long pos) 
        => _lines.TryGetValue(pos, out var value) ? value : "|.......|";

    private IEnumerable<string> GetBackgroundLines(long bottom, int numLines)
    {
        for (long i = bottom; i < bottom + numLines; i++)
            yield return GetBackgroundLine(i);
    }
}

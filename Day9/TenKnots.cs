namespace Day9;

public class TenKnots : RopeState
{
    private List<EndPosition> _tailPositions = new(10);

    public TenKnots(EndPosition headPosition) 
        : this(headPosition, Enumerable.Repeat(headPosition, 9).ToList())
    {
    }

    public TenKnots(EndPosition headPosition, List<EndPosition> tailPositions) 
        : base(headPosition)
    {
        var nextHead = headPosition;
        foreach(var tail in tailPositions)
        {
            var knot = new RuleBasedMovement(nextHead, tail);
            nextHead = knot.TailPosition;
            _tailPositions.Add(nextHead);
        }
        TailPosition = nextHead;

        // DebugPrint();
    }

    public override EndPosition TailPosition { get; }

    public override RopeState MoveNorth()
        => new TenKnots(HeadPosition.North, _tailPositions);

    public override RopeState MoveEast()
        => new TenKnots(HeadPosition.East, _tailPositions);

    public override RopeState MoveSouth()
        => new TenKnots(HeadPosition.South, _tailPositions);

    public override RopeState MoveWest()
        => new TenKnots(HeadPosition.West, _tailPositions);

    private void DebugPrint()
    {
        var minx = 0;
        var maxx = 0;
        var miny = 0;
        var maxy = 0;
        var knots = _tailPositions.Append(HeadPosition).ToList();
        foreach (var knot in knots)
        {
            if (knot.X > maxx) maxx = knot.X;
            if (knot.X < minx) minx = knot.X;
            if (knot.Y > maxy) maxy = knot.Y;
            if (knot.Y < miny) miny = knot.Y;
        }

        Console.WriteLine();
        for (int y = miny; y <= maxy; ++y)
        {
            for (int x = minx; x <= maxx; ++x)
            {
                var point = new EndPosition(x, y);
                var isKnot = knots.Contains(point);
                var glyph = isKnot ? '#' : '.';
                Console.Write(glyph);
            }

            Console.WriteLine();
        }
    }
}

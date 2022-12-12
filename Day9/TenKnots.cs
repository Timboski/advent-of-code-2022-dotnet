namespace Day9;

public class TenKnots : RopeState
{
    private List<EndPosition> _tailPositions = new(10);

    public TenKnots(EndPosition headPosition) 
        : this(headPosition, Enumerable.Repeat(headPosition, 10).ToList())
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
}

namespace Day9;

public class HeadSouth : RopeState
{
    public HeadSouth(EndPosition headPosition) : base(headPosition)
    {
    }

    public override EndPosition TailPosition => HeadPosition.North;

    public override RopeState MoveNorth()
        => new OverlappingEnds(HeadPosition.North);

    public override RopeState MoveEast()
        => new HeadSouthEast(HeadPosition.East);

    public override RopeState MoveSouth()
        => new HeadSouth(HeadPosition.South);

    public override RopeState MoveWest()
        => new HeadSouthWest(HeadPosition.West);
}

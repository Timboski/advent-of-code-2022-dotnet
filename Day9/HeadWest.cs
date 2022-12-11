namespace Day9;

public class HeadWest : RopeState
{
    public HeadWest(EndPosition headPosition) : base(headPosition)
    {
    }

    public override EndPosition TailPosition => HeadPosition.East;

    public override RopeState MoveNorth()
        => new HeadNorthWest(HeadPosition.North);

    public override RopeState MoveEast()
        => new OverlappingEnds(HeadPosition.East);

    public override RopeState MoveSouth()
        => new HeadSouthWest(HeadPosition.South);

    public override RopeState MoveWest()
        => new HeadWest(HeadPosition.West);
}

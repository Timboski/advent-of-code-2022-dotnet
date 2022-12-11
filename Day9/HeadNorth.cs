namespace Day9;

public class HeadNorth : RopeState
{
    public HeadNorth(EndPosition headPosition) : base(headPosition)
    {
    }

    public override EndPosition TailPosition => HeadPosition.South;

    public override RopeState MoveNorth()
        => new HeadNorth(HeadPosition.North);

    public override RopeState MoveEast()
        => new HeadNorthEast(HeadPosition.East);

    public override RopeState MoveSouth()
        => new OverlappingEnds(HeadPosition.South);

    public override RopeState MoveWest()
        => new HeadNorthWest(HeadPosition.West);
}

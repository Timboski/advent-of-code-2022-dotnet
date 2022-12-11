namespace Day9;

public class HeadEast : RopeState
{
    public HeadEast(EndPosition headPosition) : base(headPosition)
    {
    }

    public override EndPosition TailPosition => HeadPosition.West;

    public override RopeState MoveNorth()
        => new HeadNorthEast(HeadPosition.North);

    public override RopeState MoveEast()
        => new HeadEast(HeadPosition.East);

    public override RopeState MoveSouth()
        => new HeadSouthEast(HeadPosition.South);

    public override RopeState MoveWest()
        => new OverlappingEnds(HeadPosition.West);
}

namespace Day9;

public class OverlappingEnds : RopeState
{
    public OverlappingEnds(EndPosition headPosition) : base(headPosition)
    {
    }

    public override EndPosition TailPosition => HeadPosition;

    public override RopeState MoveNorth() 
        => new HeadNorth(HeadPosition.North);

    public override RopeState MoveEast()
        => new HeadEast(HeadPosition.East);

    public override RopeState MoveSouth()
        => new HeadSouth(HeadPosition.South);

    public override RopeState MoveWest()
    {
        throw new NotImplementedException();
    }
}

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
    {
        throw new NotImplementedException();
    }

    public override RopeState MoveSouth()
    {
        throw new NotImplementedException();
    }

    public override RopeState MoveWest()
    {
        throw new NotImplementedException();
    }
}

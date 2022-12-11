namespace Day9;

public class HeadEast : RopeState
{
    public HeadEast(EndPosition headPosition) : base(headPosition)
    {
    }

    public override EndPosition TailPosition => HeadPosition.West;

    public override RopeState MoveNorth()
    {
        throw new NotImplementedException();
    }

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

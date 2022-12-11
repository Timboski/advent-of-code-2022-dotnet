namespace Day9;

public class HeadSouthEast : RopeState
{
    public HeadSouthEast(EndPosition headPosition) : base(headPosition)
    {
    }

    public override EndPosition TailPosition => HeadPosition.North.West;

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

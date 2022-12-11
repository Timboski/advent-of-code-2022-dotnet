namespace Day9;

public class HeadSouthWest : RopeState
{
    public HeadSouthWest(EndPosition headPosition) : base(headPosition)
    {
    }

    public override EndPosition TailPosition => HeadPosition.North.East;

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

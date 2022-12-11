namespace Day9;

public class HeadNorthWest : RopeState
{
    public HeadNorthWest(EndPosition headPosition) : base(headPosition)
    {
    }

    public override EndPosition TailPosition => HeadPosition.South.East;

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

namespace Day9;

public class HeadSouthWest : RopeState
{
    public HeadSouthWest(EndPosition headPosition) : base(headPosition)
    {
    }

    public override EndPosition TailPosition => HeadPosition.North.East;

    public override RopeState MoveNorth()
        => new HeadWest(HeadPosition.North);

    public override RopeState MoveEast()
        => new HeadSouth(HeadPosition.East);

    public override RopeState MoveSouth()
        => new HeadSouth(HeadPosition.South);

    public override RopeState MoveWest()
        => new HeadWest(HeadPosition.West);
}

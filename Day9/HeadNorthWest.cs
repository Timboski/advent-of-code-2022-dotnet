namespace Day9;

public class HeadNorthWest : RopeState
{
    public HeadNorthWest(EndPosition headPosition) : base(headPosition)
    {
    }

    public override EndPosition TailPosition => HeadPosition.South.East;

    public override RopeState MoveNorth()
        => new HeadNorth(HeadPosition.North);

    public override RopeState MoveEast()
        => new HeadNorth(HeadPosition.East);   

    public override RopeState MoveSouth()
        => new HeadWest(HeadPosition.South);

    public override RopeState MoveWest()
        => new HeadWest(HeadPosition.West);
}

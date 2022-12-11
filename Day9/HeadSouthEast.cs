namespace Day9;

public class HeadSouthEast : RopeState
{
    public HeadSouthEast(EndPosition headPosition) : base(headPosition)
    {
    }

    public override EndPosition TailPosition => HeadPosition.North.West;

    public override RopeState MoveNorth()
        => new HeadEast(HeadPosition.North);

    public override RopeState MoveEast()
        => new HeadEast(HeadPosition.East);

    public override RopeState MoveSouth()
        => new HeadSouth(HeadPosition.South);

    public override RopeState MoveWest()
        => new HeadSouth(HeadPosition.West);
}

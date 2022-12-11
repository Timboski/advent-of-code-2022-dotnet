namespace Day9;

public class HeadNorthEast : RopeState
{
    public HeadNorthEast(EndPosition headPosition) : base(headPosition)
    {
    }

    public override EndPosition TailPosition => HeadPosition.South.West;

    public override RopeState MoveNorth()
        => new HeadNorth(HeadPosition.North); 

    public override RopeState MoveEast()
        => new HeadEast(HeadPosition.East);

    public override RopeState MoveSouth()
        => new HeadEast(HeadPosition.South);

    public override RopeState MoveWest()
    => new HeadNorth(HeadPosition.West);
}

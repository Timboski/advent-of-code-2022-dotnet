namespace Day9;

public abstract class RopeState
{
    public RopeState(EndPosition headPosition) => HeadPosition = headPosition;

    public EndPosition HeadPosition { get; }

    public abstract EndPosition TailPosition { get; }

    public abstract RopeState MoveNorth();

    public abstract RopeState MoveEast();

    public abstract RopeState MoveSouth();

    public abstract RopeState MoveWest();
}

namespace Day9;

public class RuleBasedMovement : RopeState
{
    public RuleBasedMovement(EndPosition headPosition) 
        : this(headPosition, headPosition)
    {
    }

    public RuleBasedMovement(EndPosition headPosition, EndPosition tailPosition) 
        : base(headPosition)
    {
        if (headPosition.X == tailPosition.X)
        {
            // In line vertcally.
            if (headPosition.Y > tailPosition.Y + 1)
            {
                TailPosition = tailPosition.North;
                return;
            }

            if (headPosition.Y < tailPosition.Y - 1)
            {
                TailPosition = tailPosition.South;
                return;
            }

            // Already touching
            TailPosition = tailPosition;
            return;
        }

        if (headPosition.Y == tailPosition.Y)
        {
            // In line horizontally.
            if (headPosition.X > tailPosition.X + 1)
            {
                TailPosition = tailPosition.East;
                return;
            }

            if (headPosition.X < tailPosition.X - 1)
            {
                TailPosition = tailPosition.West;
                return;
            }

            // Already touching
            TailPosition = tailPosition;
            return;
        }

        // Check if already touching
        if (((headPosition.X == tailPosition.X + 1) || (headPosition.X == tailPosition.X - 1))
            && ((headPosition.Y == tailPosition.Y + 1) || (headPosition.Y == tailPosition.Y - 1)))
        {
            TailPosition = tailPosition; 
            return; 
        }

        // Move diagonally towards head
        TailPosition = new EndPosition(
        headPosition.X < tailPosition.X ? tailPosition.X - 1 : tailPosition.X + 1,
        headPosition.Y < tailPosition.Y ? tailPosition.Y - 1 : tailPosition.Y + 1);
    }

    public override EndPosition TailPosition { get; }

    public override RopeState MoveNorth()
        => new RuleBasedMovement(HeadPosition.North, TailPosition);

    public override RopeState MoveEast()
        => new RuleBasedMovement(HeadPosition.East, TailPosition);

    public override RopeState MoveSouth()
        => new RuleBasedMovement(HeadPosition.South, TailPosition);

    public override RopeState MoveWest()
        => new RuleBasedMovement(HeadPosition.West, TailPosition);
}

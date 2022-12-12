namespace Day9;

public class RopeTracker
{
    private readonly RopeState _state = new OverlappingEnds(new EndPosition(0, 0));

    public RopeTracker()
	{
	}

    public RopeTracker(RopeState startState) => _state = startState;

    public void TrackMotion(string instruction)
    {
        _state.MoveNorth();
    }
}

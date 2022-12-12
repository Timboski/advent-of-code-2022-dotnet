namespace Day9;

public class RopeTracker
{
    private RopeState _state = new OverlappingEnds(new EndPosition(0, 0));

    public RopeTracker()
	{
	}

    public RopeTracker(RopeState startState) => _state = startState;

    public void TrackMotion(string instruction)
    {
        var parts = instruction.Split(' ');
        var direction = parts[0];
        for (var i = 0; i < int.Parse(parts[1]); ++i)
        {
            _state = direction switch
            {
                "U" => _state.MoveNorth(),
                "D" => _state.MoveSouth(),
                _ => throw new NotImplementedException(),
            };
        }
    }
}

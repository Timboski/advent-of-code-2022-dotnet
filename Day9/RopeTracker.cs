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
        int iterations = int.Parse(parts[1]);

        for (var i = 0; i < iterations; ++i)
        {
            _state = direction switch
            {
                "U" => _state.MoveNorth(),
                "R" => _state.MoveEast(),
                "D" => _state.MoveSouth(),
                "L" => _state.MoveWest(),
                _ => throw new NotImplementedException(),
            };
        }
    }
}

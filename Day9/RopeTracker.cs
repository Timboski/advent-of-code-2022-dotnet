namespace Day9;

public class RopeTracker
{
    private RopeState _state;
    private HashSet<EndPosition> _tailLocations = new();

    public RopeTracker() : this(new OverlappingEnds(new EndPosition(0, 0)))
	{
	}

    public RopeTracker(RopeState startState)
    {
        _state = startState;
        _tailLocations.Add(_state.TailPosition);
    }

    public int TailVisits => _tailLocations.Count;

    public void ParseFile(string fileName)
    {
        var instructions = File.ReadAllLines(fileName);
        foreach (var instruction in instructions) TrackMotion(instruction);
    }

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
            _tailLocations.Add(_state.TailPosition);
        }
    }
}

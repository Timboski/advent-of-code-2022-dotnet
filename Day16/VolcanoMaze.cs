namespace Day16;

public enum Elephant { WithElephant };

public class VolcanoMaze
{
    /// <example>
    /// "Valve AA has flow rate=0; tunnels lead to valves DD, II, BB"
    /// </example>
    private class Valve
    {
        public Valve(string data)
        {
            Name = data[6..8];
            Pressure = int.Parse(data.Split('=')[1].Split(';')[0]);
            Paths = data.Split(',').Select(a => a[^2..^0]).ToArray();
        }

        public string Name { get; }
        public int Pressure { get; }
        public string[] Paths { get; }
    }

    private readonly Dictionary<string, Valve> _valves;
    private readonly bool _withElephant;
    private readonly Dictionary<string, int> _visitedStates = new();

    public VolcanoMaze(string filename) : this(filename, withElephant: false)
    {
    }

    public VolcanoMaze(string filename, Elephant _) : this(filename, withElephant: true)
    {
    }

    private VolcanoMaze(string filename, bool withElephant)
    {
        static Valve CreateValve(string data) => new(data);

        _valves = File
            .ReadAllLines(filename)
            .Select(CreateValve)
            .ToDictionary(v => v.Name, v => v);

        _withElephant = withElephant;
    }

    public string Valves => string.Concat(_valves.Keys.Order());

    public int GetPressure(string valve) => _valves[valve].Pressure;

    public IEnumerable<string> GetPaths(string valve) => _valves[valve].Paths;

    public IEnumerable<(string State, int Pressure)> FindNextStates(string currentState, int releasedPressure, int timeRemaining)
    {
        var nextStates = new List<(string State, int Pressure)>();
        if (!TestAndAdd(currentState, releasedPressure)) return nextStates;
        if (!_withElephant) return FindNextStatesOneMover(currentState, releasedPressure, timeRemaining).ToList();

        // We have an elephant.
        var currentValves = currentState[2..^0];
        var nextElephantStates = FindNextStatesOneMover(currentValves, releasedPressure, timeRemaining);

        var ourPosition = currentState[0..2];
        foreach (var elephantState in nextElephantStates)
        {
            // Move ourself (taking into account the elephants move)
            var newElephantPosition = elephantState.State[0..2];
            var valvesAfterElephant = elephantState.State[2..^0];
            var ourStartState = ourPosition + valvesAfterElephant;

            var ourNextStates = FindNextStatesOneMover(ourStartState, elephantState.Pressure, timeRemaining);
            nextStates.AddRange(ourNextStates.Select(s=>(newElephantPosition + s.State, s.Pressure)));
        }

        return nextStates; // TODO: Sort positions and make unique.
    }

    private IEnumerable<(string State, int Pressure)> FindNextStatesOneMover(string currentState, int releasedPressure, int timeRemaining)
    {
        var valve = currentState[0..2];
        var openValveStr = currentState[2..^0];

        var openValves = openValveStr.Chunk(2).Select(l => string.Concat(l)).ToList();
        if (_valves[valve].Pressure > 0 && !openValves.Contains(valve))
        {
            // Open the Valve
            openValves.Add(valve);
            var openedState = valve + string.Concat(openValves.Order());

            // Compute released pressure
            var newPressure = checked((_valves[valve].Pressure * timeRemaining) + releasedPressure);
            yield return (openedState, newPressure);
        }

        // Move down paths
        foreach (var nextValve in _valves[valve].Paths)
        {
            yield return (nextValve + openValveStr, releasedPressure);
        }
    }

    private bool TestAndAdd(string state, int pressure)
    {
        // Check is already visited with a preferable route
        if (_visitedStates.TryGetValue(state, out int value) &&
            value >= pressure) return false;

        // We have a better route. Store it.
        _visitedStates[state] = pressure;
        return true;
    }
}
namespace Day16;

public class VolcanoPathFinder
{
    private readonly VolcanoMaze _volcano;
    private Queue<(string State, int Pressure)> _states = new();
    private Queue<(string State, int Pressure)> _nextStates = new();
    private readonly int _initialTimeRemaining;

    public VolcanoPathFinder(string filename)
    {
        _volcano = new VolcanoMaze(filename);
        _states.Enqueue(("AA", 0));
        _initialTimeRemaining = 29;
    }

    public VolcanoPathFinder(string filename, Elephant elephant)
    {
        _volcano = new VolcanoMaze(filename, elephant);
        _states.Enqueue(("AAAA", 0));
        _initialTimeRemaining = 25;
    }

    public int MaximisePressure()
    {
        for (var timeRemaining = _initialTimeRemaining; timeRemaining >= 1; timeRemaining--) 
        {
            ProcessQueue(timeRemaining);

            // Swap queues
            (_nextStates, _states) = (_states, _nextStates);
        }

        return _states.Select(state => state.Pressure).Max();
    }

    private void ProcessQueue(int timeRemaining)
    {
        while (_states.TryDequeue(out var state)) 
        {
            var nextStates = _volcano.FindNextStates(state.State, state.Pressure, timeRemaining);
            foreach (var newState in nextStates) _nextStates.Enqueue(newState);
        }
    }
}

namespace Day16;

public class VolcanoPathFinder
{
    private readonly VolcanoMaze _volcano;
    private Queue<(string State, int Pressure)> _states = new();
    private Queue<(string State, int Pressure)> _nextStates = new();
    private readonly int _initialTimeRemaining;
    private int _maxPressure = 0;

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

        return _maxPressure;
    }

    private void ProcessQueue(int timeRemaining)
    {
        while (_states.TryDequeue(out var state)) 
        {
            // Find states
            var nextStates = _volcano.FindNextStates(state.State, state.Pressure, timeRemaining);
            if (nextStates.Any())
            {
                // Keep track of highest pressure released
                _maxPressure = Math.Max(_maxPressure, nextStates.Select(state => state.Pressure).Max());

                // Queue up the remaining states
                foreach (var newState in nextStates) _nextStates.Enqueue(newState);
            }
        }
    }
}

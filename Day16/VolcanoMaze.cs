﻿namespace Day16;

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

    public VolcanoMaze(string filename)
    {
        static Valve CreateValve(string data) => new(data);

        _valves = File
            .ReadAllLines(filename)
            .Select(CreateValve)
            .ToDictionary(v => v.Name, v => v);
    }

    public string Valves => string.Concat(_valves.Keys.Order());

    public int GetPressure(string valve) => _valves[valve].Pressure;

    public IEnumerable<string> GetPaths(string valve) => _valves[valve].Paths;

    public IEnumerable<string> FindNextStates(string currentState)
    {
        var valve = currentState[0..2];
        var openValveStr = currentState[2..^0];

        var openValves = openValveStr.Chunk(2).Select(l => string.Concat(l)).ToList();
        if (!openValves.Contains(valve))
        {
            // Open the Valve
            openValves.Add(valve);
            yield return valve + string.Concat(openValves.Order());
        }

        // Move down paths
        foreach (var nextValve in _valves[valve].Paths)
        {
            yield return nextValve + openValveStr;
        }
    }
}
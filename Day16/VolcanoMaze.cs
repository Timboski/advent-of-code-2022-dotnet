namespace Day16;

public class VolcanoMaze
{
	private class Valve
	{
		public Valve(string data)
		{
			Name = data[6..8];
		}

		public string Name { get; }
	}

	private readonly Dictionary<string, Valve> _valves;

	public VolcanoMaze(string filename)
	{
		static Valve CreateValve(string data) => new Valve(data);

		_valves = File
			.ReadAllLines(filename)
			.Select(CreateValve)
			.ToDictionary(v => v.Name, v => v);
	}

	public string Valves => string.Concat(_valves.Keys.Order());
}

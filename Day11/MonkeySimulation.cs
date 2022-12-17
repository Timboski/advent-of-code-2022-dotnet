namespace Day11;

public class MonkeySimulation
{
	public MonkeySimulation(string filename)
	{
		var monkeys = new List<Monkey>();
		var lines = File.ReadAllLines(filename);
		for (int i = 0; i < lines.Length; i += 7)
		{
			// Check monkeys are listed in order
			if (!lines[i].Contains($"Monkey {monkeys.Count}")) 
				throw new InvalidOperationException();
			
			monkeys.Add(new Monkey(lines[(i + 1)..(i + 6)].ToList()));
		}

		Monkey = monkeys.ToArray();
	}

	public Monkey[] Monkey { get; }
}

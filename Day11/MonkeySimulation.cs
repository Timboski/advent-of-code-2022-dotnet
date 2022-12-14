using System.Numerics;

namespace Day11;

public class MonkeySimulation
{
	public MonkeySimulation(string filename, bool relief = false)
	{
		var monkeys = new List<Monkey>();
		var lines = File.ReadAllLines(filename);
		for (int i = 0; i < lines.Length; i += 7)
		{
			// Check monkeys are listed in order
			if (!lines[i].Contains($"Monkey {monkeys.Count}")) 
				throw new InvalidOperationException();
			
			monkeys.Add(new Monkey(lines[(i + 1)..(i + 6)].ToList(), relief));
		}

		Monkey = monkeys.ToArray();
	}

	public Monkey[] Monkey { get; }

    public BigInteger FindMonkeyBusiness(int numberOfRounds)
    {
		for (int i = 0; i < numberOfRounds; ++i)
        {
			// Console.Write($"Processing round: {i}");
            ProcessRound();
			// Console.WriteLine(" - done");
        }

        var mostBusiness = Monkey
			.Select(m => m.NumInspections)
			.OrderDescending()
			.Take(2);

		return (BigInteger)mostBusiness.First() * (BigInteger)mostBusiness.Last();
    }

    public void ProcessRound()
    {
		foreach (var monkey in Monkey)
		{
			while (monkey.InspectItem(out int targetMonkey, out IWorryLevel? worryLevel))
			{
				worryLevel = worryLevel ?? throw new NullReferenceException();
				Monkey[targetMonkey].AddItem(worryLevel);
			}
		}
    }
}

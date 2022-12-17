namespace Day11;

public class Monkey
{
	private Queue<int> _items = new();

	public Monkey(List<string> monkeyData)
	{
		// e.g.  "  Starting items: 79, 98"
		var items = monkeyData[0]
			.Split("Starting items:")[1]
			.Split(",")
			.Select(int.Parse);
		foreach (var item in items) _items.Enqueue(item);
		
    }

	public int[] Items => _items.ToArray();

    public bool InspectItem(out int targetMonkey, out int worryLevel)
    {
		targetMonkey = 0;
		return _items.TryDequeue(out worryLevel);
    }
}

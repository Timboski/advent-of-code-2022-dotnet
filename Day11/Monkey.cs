namespace Day11;

public class Monkey
{
	private Queue<int> _items = new();
    private readonly Func<int, int> _worryEvaulation;
    private readonly Func<int, int> _findTargetMonkey;

	public Monkey(List<string> monkeyData)
    {
        ParseStartingItems(monkeyData[0]);
        _worryEvaulation = ParseWorryEvaluation(monkeyData[1]);
        _findTargetMonkey = ParseTargetDecision(monkeyData.Skip(2).ToList());
    }

    public int[] Items => _items.ToArray();

    public bool InspectItem(out int targetMonkey, out int worryLevel)
    {
		targetMonkey = 0;
        worryLevel = 0;
		if (!_items.TryDequeue(out int item)) return false;

        worryLevel = _worryEvaulation(item) / 3;
        targetMonkey = _findTargetMonkey(worryLevel);
        return true;
    }

    /// <example>
    /// String format: "  Starting items: 79, 98"
    /// </example>
    private void ParseStartingItems(string itemsList)
    {
        var items = itemsList
            .Split("Starting items:")[1]
            .Split(",")
            .Select(int.Parse);
        foreach (var item in items) _items.Enqueue(item);
    }

    /// <example>
    /// "  Operation: new = old * 19"
    /// "  Operation: new = old + 6"
    /// "  Operation: new = old * old"
    /// "  Operation: new = old + 3"
    /// </example>
    private static Func<int, int> ParseWorryEvaluation(string operation)
    {
        var rule = operation.Split("Operation: new = old ")[1];
        if (rule == "* old") return a => a * a;

        var part = rule.Split(" ");
        var operand = int.Parse(part[1]);

        return part[0] switch
        {
            "*" => a => a * operand,
            "+" => a => a + operand,
            _ => throw new NotImplementedException(operation),
        };
    }

    /// <example>
    /// """
    ///   Test: divisible by 23
    ///     If true: throw to monkey 2
    ///     If false: throw to monkey 3
    /// """
    /// </example>
    private Func<int, int> ParseTargetDecision(List<string> testDescription)
    {
        var testDivisor = int.Parse(testDescription[0].Split("Test: divisible by ")[1]);
        var trueMonkey = int.Parse(testDescription[1].Split("If true: throw to monkey ")[1]);
        var falseMonkey = int.Parse(testDescription[2].Split("If false: throw to monkey ")[1]);
        return worry => worry % testDivisor == 0 ? trueMonkey: falseMonkey;
    }
}

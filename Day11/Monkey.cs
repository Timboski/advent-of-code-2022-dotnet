using System.Numerics;

namespace Day11;

public class Monkey
{
	private readonly Queue<IWorryLevel> _items = new();
    private readonly Action<IWorryLevel> _worryEvaulation;
    private readonly Func<IWorryLevel, int> _findTargetMonkey;

	public Monkey(List<string> monkeyData, bool relief = false)
    {
        ParseStartingItems(monkeyData[0], relief);
        _worryEvaulation = ParseWorryEvaluation(monkeyData[1]);
        _findTargetMonkey = ParseTargetDecision(monkeyData.Skip(2).ToList());
    }

    public BigInteger[] Items => _items.ToArray().Select(m => m.Level).ToArray();

    public int NumInspections { get; private set; } = 0;

    public bool InspectItem(out int targetMonkey, out IWorryLevel? worryLevel)
    {
        targetMonkey = 0;
		if (!_items.TryDequeue(out worryLevel)) return false;

        NumInspections = checked(NumInspections + 1);

        _worryEvaulation(worryLevel);
        worryLevel.ComputeRelief();
        targetMonkey = _findTargetMonkey(worryLevel);
        return true;
    }

    public void AddItem(IWorryLevel worryLevel)
        => _items.Enqueue(worryLevel);

    /// <example>
    /// String format: "  Starting items: 79, 98"
    /// </example>
    private void ParseStartingItems(string itemsList, bool relief)
    {
        IWorryLevel ToWorry(int level) 
            => relief ? 
                new WorryLevelWithRelief(level) : 
                new WorryLevel(level);

        var items = itemsList
            .Split("Starting items:")[1]
            .Split(",")
            .Select(int.Parse)
            .Select(ToWorry);

        foreach (IWorryLevel item in items) AddItem(item);
    }

    /// <example>
    /// "  Operation: new = old * 19"
    /// "  Operation: new = old + 6"
    /// "  Operation: new = old * old"
    /// "  Operation: new = old + 3"
    /// </example>
    private static Action<IWorryLevel> ParseWorryEvaluation(string operation)
    {
        var rule = operation.Split("Operation: new = old ")[1];
        if (rule == "* old") return a => a.Square();

        var part = rule.Split(" ");
        var operand = int.Parse(part[1]);

        return part[0] switch
        {
            "*" => a => a.Multiply(operand),
            "+" => a => a.Add(operand),
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
    private Func<IWorryLevel, int> ParseTargetDecision(List<string> testDescription)
    {
        var testDivisor = int.Parse(testDescription[0].Split("Test: divisible by ")[1]);
        var trueMonkey = int.Parse(testDescription[1].Split("If true: throw to monkey ")[1]);
        var falseMonkey = int.Parse(testDescription[2].Split("If false: throw to monkey ")[1]);
        return worry => worry.IsDivisibleBy(testDivisor) ? trueMonkey : falseMonkey;
    }
}

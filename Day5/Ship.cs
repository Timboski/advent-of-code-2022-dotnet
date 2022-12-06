namespace Day5;

public abstract class Ship
{
    protected Dictionary<int, Stack<char>> _stack = new();

    public string State => CreateStateString();

    private string CreateStateString()
    {
        var result = string.Empty;
        for (var i = 1; _stack.ContainsKey(i); ++i)
            result += PeekTopCrateMarking(i);
        return result;
    }

    public void AddCrate(int stackIndex, char crateMarking)
    {
        if (!_stack.ContainsKey(stackIndex)) _stack.Add(stackIndex, new Stack<char>());
        _stack[stackIndex].Push(crateMarking);
    }

    public char PeekTopCrateMarking(int stackIndex) => _stack[stackIndex].Peek();

    public void MoveCrates(IEnumerable<string> lines)
    {
        foreach (var line in lines)
        {
            var sections = line.Split(' ');
            if (sections[0] == "move")
            {
                var numberOfCrates = int.Parse(sections[1]);
                var fromStackIndex = int.Parse(sections[3]);
                var toStackIndex = int.Parse(sections[5]);
                MoveCrates(numberOfCrates, fromStackIndex, toStackIndex);
            }
        }
    }

    public abstract void MoveCrates(int numberOfCrates, int fromStackIndex, int toStackIndex);
}

namespace Day5;

public class Ship
{
    private Dictionary<int, Stack<char>> _stack = new();

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
    public void MoveCratesCraneMover9001(IEnumerable<string> lines)
    {
        foreach (var line in lines)
        {
            var sections = line.Split(' ');
            if (sections[0] == "move")
            {
                var numberOfCrates = int.Parse(sections[1]);
                var fromStackIndex = int.Parse(sections[3]);
                var toStackIndex = int.Parse(sections[5]);
                MoveCratesCraneMover9001(numberOfCrates, fromStackIndex, toStackIndex);
            }
        }
    }

    public void MoveCrates(int numberOfCrates, int fromStackIndex, int toStackIndex)
    {
        for (var i = 0; i < numberOfCrates; ++i)
            AddCrate(toStackIndex, _stack[fromStackIndex].Pop());
    }

    public void MoveCratesCraneMover9001(int numberOfCrates, int fromStackIndex, int toStackIndex)
    {
        var tempStack = new Stack<char>(numberOfCrates);
        for (var i = 0; i < numberOfCrates; ++i)
            tempStack.Push(_stack[fromStackIndex].Pop());
        while (tempStack.TryPop(out char crate))
            AddCrate(toStackIndex, crate);
    }
}

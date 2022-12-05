namespace Day5;

public class Ship
{
    private Dictionary<int, Stack<char>> _stack = new();

    public void AddCrates(IEnumerable<string> picture)
    {
        foreach (var row in picture.Reverse().Skip(1)) AddCrates(row);
    }

    public void AddCrates(string rowOfCrates)
    {
        var crates = rowOfCrates
                .Chunk(4)
                .Select((value, index) => new 
                    { stackIndex = index + 1, // Stacks are 1 based
                      crateMarker = value[1] }) // Ignore rest of picture "[x] "
                .Where(a => !char.IsWhiteSpace(a.crateMarker));

        foreach (var crate in crates) AddCrate(crate.stackIndex, crate.crateMarker);
    }

    public void AddCrate(int stackIndex, char crateMarking)
    {
        if (!_stack.ContainsKey(stackIndex)) _stack.Add(stackIndex, new Stack<char>());
        _stack[stackIndex].Push(crateMarking);
    }
    public char PeekTopCrateMarking(int stackIndex) => _stack[stackIndex].Peek();

    public void MoveCrates(int numberOfCrates, int fromStackIndex, int toStackIndex)
    {
        for (var i = 0; i < numberOfCrates; ++i)
            AddCrate(toStackIndex, _stack[fromStackIndex].Pop());
    }
}

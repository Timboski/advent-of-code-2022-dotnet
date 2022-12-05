namespace Day5;

public class Ship
{
    private Dictionary<int, Stack<char>> _stack = new();

    public string Process(IEnumerable<string> lines)
    {
        var picture = lines.TakeWhile(line => line.Length > 0);
        AddCrates(picture);
        MoveCrates(lines);
        var result = string.Empty;
        for (var i = 1; _stack.ContainsKey(i); ++i)
            result += PeekTopCrateMarking(i);
        return result;
    }

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

    public void MoveCrates(int numberOfCrates, int fromStackIndex, int toStackIndex)
    {
        for (var i = 0; i < numberOfCrates; ++i)
            AddCrate(toStackIndex, _stack[fromStackIndex].Pop());
    }
}

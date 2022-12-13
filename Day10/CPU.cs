namespace Day10;

public class CPU
{
    public CPU(int state = 1) => State = state;

    public int State { get; private set; }

    public IEnumerable<int> Noop() 
        => new List<int>(1) { State };

    public IEnumerable<int> Addx(int stateOffset)
    {
        var seq = new List<int>(2) { State, State };
        State += stateOffset;
        return seq;
    }

    public IEnumerable<int> Parse(string instruction)
    {
        if (instruction == "noop") return Noop();

        var split = instruction.Split(' ');
        var offset = int.Parse(split[1]);
        return Addx(offset);
    }

    public List<int> RunProgram(string filename) 
        => new int[] { State }
            .Concat(
                File.ReadLines(filename).SelectMany(Parse))
            .ToList();
}

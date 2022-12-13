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
        => Noop();
}

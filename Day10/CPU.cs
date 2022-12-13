namespace Day10;

public class CPU
{
    public CPU(int state = 1) => State = state;

    public int State { get; }

    public IEnumerable<int> Noop()
    {
        yield return State;
    }
}

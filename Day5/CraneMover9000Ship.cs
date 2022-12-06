namespace Day5;

public class CraneMover9000Ship : Ship
{
    public override void MoveCrates(int numberOfCrates, int fromStackIndex, int toStackIndex)
    {
        for (var i = 0; i < numberOfCrates; ++i)
            AddCrate(toStackIndex, _stack[fromStackIndex].Pop());
    }
}

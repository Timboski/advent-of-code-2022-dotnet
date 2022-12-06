namespace Day5;

public class CraneMover9001Ship : Ship
{
    public override void MoveCrates(int numberOfCrates, int fromStackIndex, int toStackIndex)
    {
        var tempStack = new Stack<char>(numberOfCrates);
        for (var i = 0; i < numberOfCrates; ++i)
            tempStack.Push(_stack[fromStackIndex].Pop());
        while (tempStack.TryPop(out char crate))
            AddCrate(toStackIndex, crate);
    }
}

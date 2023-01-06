namespace Day17;

public class ChamberSimulation
{
    private readonly Chamber _chamber;
    private readonly JetDirectionFactory _jetDirectionFactory;
    private readonly Dictionary<char, Action> _decodeJet;
    private readonly Dictionary<int, (long, long)> _repeatCheck = new();

    public ChamberSimulation(ShapeFactory shapeFactory, JetDirectionFactory jetDirectionFactory)
    {
        _chamber = new Chamber(shapeFactory);
        _jetDirectionFactory = jetDirectionFactory;

        _decodeJet = new() {
            { '<', _chamber.MoveLeftIfClear},
            { '>', _chamber.MoveRightIfClear}};
    }

    public long Height => _chamber.Top - 1;

    public (long start, long numBlocks, long numLines) FindRepeatingPattern(long numBlocks)
    {
        for (long i = 0; i < numBlocks; i++)
        {
            DropRock();

            // Check for repeating pattern
            var topLine = _chamber.Top - 1;
            if (_chamber.GetLine(topLine) == "|#######|")
            {
                // Blocking line at top of stack.
                int nextIndex = _jetDirectionFactory.NextIndex;
                if (_repeatCheck.TryGetValue(nextIndex, out var tup))
                {
                    var block = tup.Item1;
                    var line = tup.Item2;
                    return (block, i - block, topLine - line);
                }

                // Store the value
                _repeatCheck[nextIndex] = (i, topLine);
            }
        }

        throw new InvalidOperationException("Not periodic");
    }

    public void DropRocks(long numBlocks)
    {
        for (long i = 0; i < numBlocks; i++) DropRock();
    }

    public void DropRock()
    {
        _chamber.AddRock();

        while (true)
        {
            MoveRockForJet();
            if (!_chamber.TryMoveDown()) break;
        }

        _chamber.RestShape();
    }

    public override string ToString() => _chamber.ToString();

    private void MoveRockForJet()
        => _decodeJet[_jetDirectionFactory.NextJetDirection()].Invoke();
}

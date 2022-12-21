using System.Linq;

namespace Day13;

public static class CheckPairs
{
    public static int FromFile(string filename) 
        => File.ReadLines(filename).Chunk(3).Select(ScorePair).Sum();

    private static int ScorePair(IEnumerable<string> pair, int index)
    {
        var input = pair.ToArray();
        var left = new ArrayElement(input[0]);
        var right = new ArrayElement(input[1]);

        if (left.CheckOrder(right) != Order.Correct) return 0;
        return index + 1;
    }
}

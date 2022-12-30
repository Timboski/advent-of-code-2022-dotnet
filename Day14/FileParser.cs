using System.Drawing;

namespace Day14;

public static class FileParser
{
    /// <example>
    /// Format: "498,4 -> 498,6 -> 496,6"
    /// </example>
    public static IEnumerable<Point> ReadPath(string path) 
        => path.Split(" -> ").Select(ToPoint);

    /// <example>
    /// Format: "498,4", "498,6", "496,6"
    /// </example>
    private static Point ToPoint(string pointData)
    {
        var point = pointData.Split(',').Select(int.Parse).ToArray();
        return new Point(point[0], point[1]);
    }
}

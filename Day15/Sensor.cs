using System.Drawing;

namespace Day15;

public class Sensor
{
    /// <example>
    /// "Sensor at x=2, y=18: closest beacon is at x=-2, y=15"
    /// </example>
    public Sensor(string data)
    {
        var numbers = data
            .Split('=')
            .Skip(1)
            .Select(TakeLeadingInteger)
            .ToArray();

        Position = new Point(numbers[0], numbers[1]);
    }

    private static int TakeLeadingInteger(string data)
    {
        return int.Parse(string.Concat(data.TakeWhile(l => !",:".Contains(l))));
    }

    public Point Position { get; }
}

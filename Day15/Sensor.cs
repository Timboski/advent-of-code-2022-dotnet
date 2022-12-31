using System.Drawing;

namespace Day15;

public class Sensor
{
    private readonly int _range;

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
        NearestBeaconPosition = new Point(numbers[2], numbers[3]);
        _range = ManhattenDistance(numbers[2], numbers[3]);
    }

    public Point Position { get; }

    public Point NearestBeaconPosition { get; }

    public int DistanceToBeacon => _range;

    private static int TakeLeadingInteger(string data)
    {
        static bool VaildInteger(char digit)
            => char.IsDigit(digit) || digit == '-';

        return int.Parse(string.Concat(data.TakeWhile(VaildInteger)));
    }

    public (int min, int max) GetRange(int row)
    {
        int yDiff = Math.Abs(row - Position.Y);
        var rowRange = _range - yDiff;
        if (rowRange < 0) return (0, 0); // Nothing in range

        int min = Position.X - rowRange;
        int max = Position.X + rowRange + 1; // One after range
        return (min, max);
    }

    public bool IsBeaconPossible(int x, int y)
        => ManhattenDistance(x, y) > _range;

    private int ManhattenDistance(int x, int y)
    {
        var xDiff = Math.Abs(Position.X - x);
        var yDiff = Math.Abs(Position.Y - y);
        return xDiff + yDiff;
    }
}

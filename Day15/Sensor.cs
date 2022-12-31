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

        var xDiff = Math.Abs(Position.X - NearestBeaconPosition.X);
        var yDiff = Math.Abs(Position.Y - NearestBeaconPosition.Y);
        _range = xDiff + yDiff;
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
}

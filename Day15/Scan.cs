namespace Day15;

public class Scan
{
    private readonly List<Sensor> _sensors;

    public Scan(string filename)
        => _sensors = File
            .ReadAllLines(filename)
            .Select(s => new Sensor(s))
            .ToList();

    public IEnumerable<int> FindExcludedPositions(int row)
    {
        var set = new HashSet<int>();
        var beacons = new List<int>();
        foreach (var sensor in _sensors)
        {
            (int min, int max) = sensor.GetRange(row);
            for (var x = min; x < max; x++) set.Add(x);

            if (sensor.NearestBeaconPosition.Y == row)
                beacons.Add(sensor.NearestBeaconPosition.X);
        }

        foreach (var beacon in beacons) set.Remove(beacon);

        return set;
    }

    public int FindTuningFrequency(int maxScan)
    {
        for (int y = 0; y <= maxScan; y++)
            if (!IsRowComplete(y, maxScan, out int x))
                return checked((4000000 * x) + y);

        throw new InvalidDataException("No beacon possible");
    }

    private bool IsRowComplete(int y, int maxScan, out int x)
    {
        var ranges = _sensors
            .Select(s => s.GetRange(y))
            .Select(r => TrimRange(r, maxScan))
            .Where(NotEmptyRange)
            .OrderBy(i => i.min);

        int curr = 0;
        foreach (var range in ranges)
        {
            if (range.min > curr)
            {
                // Found a gap
                x = curr;
                return false;
            }

            // Max could be smaller if fully enclosed.
            curr = Math.Max(curr, range.max);
        }

        // Check if we got to the end
        x = curr;
        return curr > maxScan;
    }

    static (int min, int max) TrimRange((int, int) input, int maxRange)
    {
        int min = Math.Max(input.Item1, 0);
        int max = Math.Min(input.Item2, maxRange + 1);
        return (min, max);
    }

    static bool NotEmptyRange((int, int) input)
        => input.Item2 > input.Item1;
}

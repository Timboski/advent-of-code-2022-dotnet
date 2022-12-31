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
        for (int y = 0; y < maxScan; y++)
            if (IsRowComplete(y, maxScan, out int x))
                return checked((4000000 * x) + y);

        throw new InvalidDataException("No beacon possible");
    }

    public bool IsRowComplete(int y, int maxScan, out int x)
    {
        x = 0;
        for (var curr = 0; curr < maxScan; curr++)
        {
            if (!_sensors.Any(s => !s.IsBeaconPossible(curr, y)))
            {
                x = curr;
                return true;
            }
        }

        return false;
    }
}

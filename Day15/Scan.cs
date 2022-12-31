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
        for (int x = 0; x < maxScan; x++)
        {
            for (int y = 0; y < maxScan; y++)
            {
                if (!_sensors.Any(s => !s.IsBeaconPossible(x, y)))
                {
                    return checked((4000000 * x) + y);
                }
            }
        }

        throw new InvalidDataException("No beacon possible");
    }
}

using System.Numerics;

namespace Day11;

public class WorryLevel
{
	private Dictionary<int, Remainder> _level = new();

    public WorryLevel(int level)
    {
        var divisors = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23 };
        foreach (var divisor in divisors) 
            _level[divisor] = new Remainder(level, divisor);
    }

    public BigInteger Level => 0;

    public bool IsDivisibleBy(int divisor) => _level[divisor].IsDivisible;

    public void Add(int value)
    {
        foreach (var remainder in _level.Values) remainder.Add(value);
    }

    public void Multiply(int value)
    {
        foreach (var remainder in _level.Values) remainder.Multiply(value);
    }

    public void Square()
    {
        foreach (var remainder in _level.Values) remainder.Square();
    }

    public void ComputeRelief()
    {
        // Does nothing
    }
}

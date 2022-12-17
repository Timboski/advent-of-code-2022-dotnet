using System.Numerics;

namespace Day11;

public static class BigIntegerUtils
{
    public static bool IsDivisibleBy(this BigInteger number, int divisor)
        => divisor switch
        {
            2 => number.IsDivisibleBy2(),
            3 => number.IsDivisibleBy3(),
            _ => number % divisor == 0,
        };

    public static bool IsDivisibleBy2(this BigInteger number) => number.IsEven;

    public static bool IsDivisibleBy3(this BigInteger number)
    {
        var sum = number.ToString().Select(d => int.Parse(d.ToString())).Sum();
        return sum % 3 == 0;
    }
}

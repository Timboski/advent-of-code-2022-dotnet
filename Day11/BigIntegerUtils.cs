using System.Numerics;

namespace Day11;

public static class BigIntegerUtils
{
    public static bool IsDivisibleBy(this BigInteger number, int divisor)
    {
        return number.IsEven;
    }
}

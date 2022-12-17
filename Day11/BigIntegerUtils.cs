using System;
using System.Numerics;

namespace Day11;

public static class BigIntegerUtils
{
    public static bool IsDivisibleBy(this BigInteger number, int divisor)
        => divisor switch
        {
            2 => number.IsDivisibleBy2(),
            3 => number.IsDivisibleBy3(),
            5 => number.IsDivisibleBy5(),
            7 => number.IsDivisibleBy7(),
            11 => number.IsDivisibleBy11(),
            _ => number % divisor == 0,
        };

    /// <summary>
    /// Divisible by 2 if number is even
    /// </summary>
    public static bool IsDivisibleBy2(this BigInteger number) => number.IsEven;

    /// <summary>
    /// Divisible by 3 if sum of digits is also divisible by 3
    /// </summary>
    public static bool IsDivisibleBy3(this BigInteger number)
    {
        var sum = number.ToString().Select(d => int.Parse(d.ToString())).Sum();
        return sum.IntIsDivisible(3);
    }

    public static bool IntIsDivisible(this int number, int divisor) 
        => number % divisor == 0;

    /// <summary>
    /// Divisible by 5 if last digit is 0 or 5
    /// </summary>
    public static bool IsDivisibleBy5(this BigInteger number)
    {
        var lastDigit = number.ToString().Last();
        return lastDigit switch
        {
            '0' => true,
            '5' => true,
            _ => false,
        };
    }

    /// <summary>
    /// Compute the remainder of each digit pair (from right to left) 
    /// when divided by 7. Multiply the rightmost remainder by 1, the 
    /// next to the left by 2 and the next by 4, repeating the pattern 
    /// for digit pairs beyond the hundred-thousands place. Adding the 
    /// results gives a multiple of 7 (iff original number divisible by 7)
    /// </summary>
    public static bool IsDivisibleBy7(this BigInteger number)
    {
        var reducedNumber = number.ToString()
            .Reverse()
            .Chunk(2)
            .Select(a => string.Join("", a.Reverse()))
            .Select(int.Parse)
            .Select(n => n % 7)
            .Select((item, index) => item * (int)(Math.Pow(2, index)))
            .Sum();
        return reducedNumber.IntIsDivisible(7);
    }

    /// <summary>
    /// Form the alternating sum of the digits, 
    /// or equivalently sum(odd) - sum(even).
    /// The result must be divisible by 11.
    /// </summary>
    public static bool IsDivisibleBy11(this BigInteger number)
    {
        var reducedNumber = number.ToString()
            .Select(a => int.Parse(a.ToString()))
            .Select((item, index) => item * (index.IntIsDivisible(2) ? 1 : -1))
            .Sum();
        return reducedNumber.IntIsDivisible(11);
    }
}

using System.Numerics;

namespace Day11;

/// <see cref="https://en.wikipedia.org/wiki/Divisibility_rule"/>
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
            13 => number.IsDivisibleBy13(),
            17 => number.IsDivisibleBy17(),
            19 => number.IsDivisibleBy19(),
            23 => number.IsDivisibleBy23(),
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

    /// <summary>
    /// Form the alternating sum of blocks of three from right to left. 
    /// The result must be divisible by 13.
    /// </summary>
    public static bool IsDivisibleBy13(this BigInteger number)
    {
        var reducedNumber = number.ToString()
            .Reverse()
            .Chunk(3)
            .Select(a => string.Join("", a.Reverse()))
            .Select(int.Parse)
            .Select((item, index) => item * (index.IntIsDivisible(2) ? 1 : -1))
            .Sum();
        return reducedNumber.IntIsDivisible(13);
    }

    /// <summary>
    /// Subtract 5 times the last digit from the rest. 
    /// (Works because 51 is divisible by 17.)
    /// </summary>
    public static bool IsDivisibleBy17(this BigInteger number)
        => DivisibleWithLastDigitReduction(number, -5, 17);

    /// <summary>
    /// Add twice the last digit to the rest.
    /// </summary>
    public static bool IsDivisibleBy19(this BigInteger number)
        => DivisibleWithLastDigitReduction(number, 2, 19);

    /// <summary>
    /// Add 7 times the last digit to the rest.
    /// </summary>
    public static bool IsDivisibleBy23(this BigInteger number) 
        => DivisibleWithLastDigitReduction(number, 7, 23);

    private static bool DivisibleWithLastDigitReduction(this BigInteger number, int multiplier, int divisor)
    {
        var reducedNumberDigits = number.ToString();
        while (reducedNumberDigits.Length > 6)
        {
            var lastDigit = int.Parse(reducedNumberDigits.Last().ToString());
            var remainingDigits = BigInteger.Parse(reducedNumberDigits[0..^1]);
            var reducedNumber = remainingDigits + (lastDigit * multiplier);
            reducedNumberDigits = reducedNumber.ToString();
        }

        return int.Parse(reducedNumberDigits).IntIsDivisible(divisor);
    }
}

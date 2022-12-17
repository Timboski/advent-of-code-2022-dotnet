using System.Numerics;
using Xunit.Abstractions;

namespace Day11Test;

public class BigIntegerUtilsTest
{
    [Theory]
    [InlineData(13892429, 2)]
    public void GivenMultipleOfANumber_WhenCheckIfDivisible_ReturnsTrue(long multiple, int divisor)
    {
        // Arrange
        var input = (BigInteger)multiple * divisor;

        // Act
        var isDivisible = input.IsDivisibleBy(divisor);

        // Assert
        Assert.True(isDivisible);
    }

    [Theory]
    [InlineData(13892429, 2, 1)]
    [InlineData(13892429, 2, -1)]
    public void GivenMultipleOfANumberAndOffsetSoNotDivisible_WhenCheckIfDivisible_ReturnsFalse(long multiple, int divisor, int offset)
    {
        // Arrange
        var input = (BigInteger)multiple * divisor + offset;

        // Act
        var isDivisible = input.IsDivisibleBy(divisor);

        // Assert
        Assert.False(isDivisible);
    }
}
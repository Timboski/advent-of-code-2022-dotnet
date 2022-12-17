using System.Numerics;
using Xunit.Abstractions;

namespace Day11Test;

public class BigIntegerUtilsTest
{
    [Theory]
    [InlineData(13892429, 2)]
    [InlineData(575743523424, 3)]
    [InlineData(5757435234245, 3)]
    [InlineData(23432325, 5)]
    [InlineData(95843957984279894, 5)]
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
    [InlineData(575743523424, 3, 1)]
    [InlineData(575743523424, 3, 2)]
    [InlineData(23432325, 5, 1)]
    [InlineData(95843957984279894, 5, 2)]
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
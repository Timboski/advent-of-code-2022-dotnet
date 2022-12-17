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
    [InlineData(6557538333835635, 7)]
    [InlineData(29220, 7)]
    [InlineData(3432583918349934921, 11)]
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
    [InlineData(6557538333835635, 7, 1)]
    [InlineData(6557538333835635, 7, -1)]
    [InlineData(6557538333835635, 7, 4)]
    [InlineData(0, 7, 194536)]
    [InlineData(3432583918349934921, 11, 1)]
    [InlineData(3432583918349934921, 11, 10)]
    [InlineData(3432583918349934921, 11 , 5)]
    [InlineData(3432583918349934921, 11, 7)]
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
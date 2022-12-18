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
    [InlineData(4885798252409458493, 13)]
    [InlineData(8989759424543398, 17)]
    [InlineData(98748395898945295, 17)]
    [InlineData(342423575836635634, 19)]
    [InlineData(66285489254208563, 23)]
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
    [InlineData(4885798252409458493, 13, 1)]
    [InlineData(4885798252409458493, 13, 7)]
    [InlineData(8989759424543398, 17, 1)]
    [InlineData(8989759424543398, 17, 2)]
    [InlineData(8989759424543398, 17, 5)]
    [InlineData(8989759424543398, 17, 10)]
    [InlineData(8989759424543398, 17, 15)]
    [InlineData(8989759424543398, 17, 16)]
    [InlineData(342423575836635634, 19, 1)]
    [InlineData(342423575836635634, 19, -1)]
    [InlineData(342423575836635634, 19, 10)]
    [InlineData(66285489254208563, 23, 1)]
    [InlineData(66285489254208563, 23, 22)]
    [InlineData(66285489254208563, 23, -1)]
    [InlineData(66285489254208563, 23, 11)]
    public void GivenMultipleOfANumberAndOffsetSoNotDivisible_WhenCheckIfDivisible_ReturnsFalse(long multiple, int divisor, int offset)
    {
        // Arrange
        var input = (BigInteger)multiple * divisor + offset;

        // Act
        var isDivisible = input.IsDivisibleBy(divisor);

        // Assert
        Assert.False(isDivisible);
    }

    [Fact]
    public void GivenVeryLargeNumber_WhenCheckIfDivisibleBy7_ReturnsCorrectResult()
    {
        // Arrange
        var number = BigInteger.Parse("741560367431738106290685030976411681679097726943798419121598922246422246224");

        // Act
        var isDivisible = number.IsDivisibleBy(7);

        // Assert
        Assert.False(isDivisible);
    }
}
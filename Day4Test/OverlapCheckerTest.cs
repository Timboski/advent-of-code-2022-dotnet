namespace Day4Test;

public class OverlapCheckerTest
{
    [Theory]
    [InlineData("2-4,6-8")]
    [InlineData("2-3,4-5")]
    [InlineData("5-7,7-9")]
    [InlineData("2-6,4-8")]
    public void GivenNoOrPartialOverlap_WhenCheck_ReturnsFalse(string input)
    {
        // Arrange
        // Act
        var result = OverlapChecker.Check(input);

        // Assert
        Assert.False(result);
    }

    [Theory]
    [InlineData("2-8,3-7")]
    [InlineData("6-6,4-6")]
    public void GivenTotalOverlap_WhenCheck_ReturnsTrue(string input)
    {
        // Arrange
        // Act
        var result = OverlapChecker.Check(input);

        // Assert
        Assert.True(result);
    }
}
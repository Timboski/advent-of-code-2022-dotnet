namespace Day13Test;

public class CheckPairsTest
{
    [Theory]
    [InlineData("day13-example-input.txt", 13)]
    [InlineData("day13-input.txt", 6428)]
    public void GivenDistressSignal_WhenFindCorrectPairs_ReturnsCorrectSumOfIndecies(string filename, int expectedScore)
    {
        // Arrange
        // Act
        var score = CheckPairs.FromFile(filename);

        // Assert
        Assert.Equal(expectedScore, score);
    }
}
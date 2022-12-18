namespace Day12Test;

public class HillCLimbTest
{
    [Theory]
    [InlineData("day12-example-input.txt", 31)]
    public void GivenMapDataWithNoStart_WhenCreateHeightMap_ThrowsException(string filename, int expectedNumberOfSteps)
    {
        // Arrange
        var sut = new HillClimb(filename);

        // Act
        var steps = sut.FindPath();

        // Assert
        Assert.Equal(expectedNumberOfSteps, steps);
    }
}
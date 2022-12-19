namespace Day12Test;

public class HillCLimbTest
{
    [Theory]
    [InlineData("day12-example-input.txt", 31)]
    [InlineData("day12-input.txt", 472)]
    public void GivenHillCLimbWithMapData_WhenFindPath_ReturnsNumberOfSteps(string filename, int expectedNumberOfSteps)
    {
        // Arrange
        var sut = new HillClimb(filename);

        // Act
        var steps = sut.FindPath();

        // Assert
        Assert.Equal(expectedNumberOfSteps, steps);
    }
}
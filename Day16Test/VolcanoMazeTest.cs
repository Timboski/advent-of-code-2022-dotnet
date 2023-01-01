namespace Day16Test;

public class VolcanoMazeTest
{
    [Fact]
    public void GivenInputFile_WhenCreateVolcanoMaze_ContainsExpectedValves()
    {
        // Arrange
        var filename = "day16-example-input.txt";
        var expectedValves = "AABBCCDDEEFFGGHHIIJJ";

        // Act
        var sut = new VolcanoMaze(filename);

        // Assert
        Assert.Equal(expectedValves, sut.Valves);
    }
}
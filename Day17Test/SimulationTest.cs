namespace Day17Test;

public class SimulationTest
{
    [Theory]
    [InlineData("day17-example-input.txt", 3068)]
    [InlineData("day17-input.txt", 3090)]
    public void GivenInputDataFile_WhenFindHeight_ReturnsExpectedHeight(string filename, long expectedHeight)
    {
        // Arrange, Act
        var height = Simulation.FindHeight(filename, 2022);

        // Assert
        Assert.Equal(expectedHeight, height);
    }

    [Theory]
    [InlineData("day17-input.txt", 1530057803453)]
    public void GivenInputDataFile_FindHeightWithRepeat_ReturnsExpectedHeight(string filename, long expectedHeight)
    {
        // Arrange, Act
        var height = Simulation.FindHeightWithRepeat(filename, 1000000000000);

        // Assert
        Assert.Equal(expectedHeight, height);
    }
}
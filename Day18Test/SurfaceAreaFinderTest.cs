namespace Day18Test;

public class SurfaceAreaFinderTest
{
    [Theory]
    [InlineData("day18-example-input.txt", 64)]
    [InlineData("day18-input.txt", 3448)]
    public void GivenInputFile_WhenFindArea_FindsExpectedArea(string filename, int expectedArea)
    {
        // Arrange, Act
        var area = SurfaceAreaFinder.FindArea(filename);

        // Assert
        Assert.Equal(expectedArea, area);
    }

    [Theory]
    [InlineData("day18-example-input.txt", 58)]
    [InlineData("day18-input.txt", 2052)]
    public void GivenInputFile_WhenFindExternalArea_FindsExpectedArea(string filename, int expectedArea)
    {
        // Arrange, Act
        var area = SurfaceAreaFinder.FindExternalArea(filename);

        // Assert
        Assert.Equal(expectedArea, area);
    }
}
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
}
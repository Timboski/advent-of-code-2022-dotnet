using System.Drawing;

namespace Day14Test;

public class FileParserTest
{
    [Theory]
    [InlineData("498,4 -> 498,6 -> 496,6", new[] { 498, 498, 496 }, new[] { 4, 6, 6 })]
    [InlineData("503,4 -> 502,4 -> 502,9 -> 494,9", new[] { 503, 502, 502, 494 }, new[] { 4, 4, 9, 9 })]
    public void GivenStringRepresentation_WhenReadPath_ReturnsListOfPoints(string pathData, int[] xCoords, int[] yCoords)
    {
        // Arrange
        var expected = xCoords.Zip(yCoords, (x, y) => new Point(x, y));

        // Act
        var points = FileParser.ReadPath(pathData);

        // Assert
        Assert.Equal(expected, points);
    }
}
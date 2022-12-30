using System.Drawing;

namespace Day14Test;

public class CaveTest
{
    [Fact]
    public void GivenEmptyCave_WhenConvertToString_ReturnsPrintableRepresentation()
    {
        // Arrange
        var box = new BoundingBox(494, 0, 504, 4);
        var sut = new Cave(box, new Point(500, 0));
        var expectedDisplay = """
            ......+...
            ..........
            ..........
            ..........
            """;

        // Act
        var display = sut.ToString();

        // Assert
        Assert.Equal(expectedDisplay, display);
    }

    [Fact]
    public void GivenEmptyCave_WhenAddVerticalPath_ReturnsPrintableRepresentation()
    {
        // Arrange
        var box = new BoundingBox(494, 0, 504, 5);
        var sut = new Cave(box, new Point(500, 0));
        var path = new[] { new Point(496, 1), new Point(496, 3) };
        var expectedDisplay = """
            ......+...
            ..#.......
            ..#.......
            ..#.......
            ..........
            """;

        // Act
        sut.AddPath(path);

        // Assert
        Assert.Equal(expectedDisplay, sut.ToString());
    }
}
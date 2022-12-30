using System.Drawing;

namespace Day14Test;

public class BoundingBoxTest
{
    [Fact]
    public void GivenBoundingBox_WhenAddPoints_ReturnsExpandedBox()
    {
        // Arrange
        var points = new[] { new Point(503, 4), new Point(503, 4), new Point(502, 4), new Point(494, 9) };
        var expectedBox = new Rectangle(494, 0, 10, 10);
        var sut = new BoundingBox(new Point(500, 0));

        // Act
        sut.EnclosePoints(points);

        // Assert
        Assert.Equal(expectedBox.Left, sut.MinX);
        Assert.Equal(expectedBox.Right, sut.MaxX);
        Assert.Equal(expectedBox.Top, sut.MinY);
        Assert.Equal(expectedBox.Bottom, sut.MaxY);
    }
}
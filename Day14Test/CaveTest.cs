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

    [Theory]
    [MemberData(nameof(PathTestData))]
    public void GivenEmptyCaveAndPath_WhenAddPath_ReturnsPrintableRepresentation(BoundingBox box, IEnumerable<Point> path, string expectedDisplay)
    {
        // Arrange
        var sut = new Cave(box, new Point(500, 0));

        // Act
        sut.AddPath(path);

        // Assert
        Assert.Equal(expectedDisplay, sut.ToString());
    }

    public static IEnumerable<object[]> PathTestData()
        => new List<object[]>
             {
                new object[] {
                    new BoundingBox(494, 0, 504, 5),
                    new[] { new Point(496, 1), new Point(496, 3) },
                    """
                    ......+...
                    ..#.......
                    ..#.......
                    ..#.......
                    ..........
                    """
                },
                new object[] {
                    new BoundingBox(494, 0, 504, 4),
                    new[] { new Point(496, 2), new Point(501, 2) },
                    """
                    ......+...
                    ..........
                    ..######..
                    ..........
                    """
                }
            };
}
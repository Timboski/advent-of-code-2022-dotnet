using System.Drawing;
using Xunit.Abstractions;

namespace Day14Test;

public class CaveTest
{
    private readonly ITestOutputHelper _output;

    public CaveTest(ITestOutputHelper output) => _output = output;

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
    public void GivenEmptyCaveAndPath_WhenAddPath_ReturnsPrintableRepresentation(string desciption, BoundingBox box, IEnumerable<Point> path, string expectedDisplay)
    {
        // Arrange
        _output.WriteLine(desciption);
        var sut = new Cave(box, new Point(500, 0));

        // Act
        sut.AddPath(path);

        // Assert
        Assert.Equal(expectedDisplay, sut.ToString());
    }

    [Fact]
    public void GivenCaveData_WhenAddPaths_ReturnsPrintableRepresentation()
    {
        // Arrange
        var filename = "day14-example-input.txt";
        var box = new BoundingBox(494, 0, 504, 10);
        var paths = FileParser.ReadFile(filename);
        var sut = new Cave(box, new Point(500, 0));

        var expectedDisplay = """
            ......+...
            ..........
            ..........
            ..........
            ....#...##
            ....#...#.
            ..###...#.
            ........#.
            ........#.
            #########.
            """;


        // Act
        sut.AddPaths(paths);

        // Assert
        Assert.Equal(expectedDisplay, sut.ToString());
    }

    public static IEnumerable<object[]> PathTestData()
        => new List<object[]>
             {
                new object[] {
                    "Vertical Line",
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
                    "Horizontal Line",
                    new BoundingBox(494, 0, 504, 4),
                    new[] { new Point(496, 2), new Point(501, 2) },
                    """
                    ......+...
                    ..........
                    ..######..
                    ..........
                    """
                },
                new object[] {
                    "Reverse Vertical Line",
                    new BoundingBox(494, 0, 504, 5),
                    new[] { new Point(496, 3), new Point(496, 1) },
                    """
                    ......+...
                    ..#.......
                    ..#.......
                    ..#.......
                    ..........
                    """
                },
                new object[] {
                    "Reverse Horizontal Line",
                    new BoundingBox(494, 0, 504, 4),
                    new[] { new Point(501, 2), new Point(496, 2) },
                    """
                    ......+...
                    ..........
                    ..######..
                    ..........
                    """
                },
                new object[] {
                    "Two Lines",
                    new BoundingBox(494, 0, 504, 6),
                    new[] { new Point(496, 1), new Point(496, 4), new Point(501, 4) },
                    """
                    ......+...
                    ..#.......
                    ..#.......
                    ..#.......
                    ..######..
                    ..........
                    """
                }
            };
}
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

    [Theory]
    [InlineData(500, 1, 500, 2)] // Nothing below
    [InlineData(500, 2, 500, 2)] // Path blocked
    [InlineData(499, 2, 498, 3)] // Move down left
    [InlineData(501, 2, 502, 3)] // Move down right
    public void GivenCave_WhenMoveSand_ReturnsNewPosition(int startX, int startY, int expectedX, int expectedY)
    {
        // Arrange
        var box = new BoundingBox(494, 0, 504, 4);
        var sut = new Cave(box, new Point(500, 0));
        sut.AddPath(new[] { new Point(499, 3), new Point(501, 3) });
        _output.WriteLine(sut.ToString());

        // Act
        var newPos = sut.FallFrom(new Point(startX, startY));

        // Assert
        Assert.Equal(new Point(expectedX, expectedY), newPos);
    }

    [Theory]
    [MemberData(nameof(ExampleSand))]
    public void GivenExmpaleCave_WhenDropSand_ReturnsPrintableRepresentation(int numIterations, string expectedDisplay)
    {
        // Arrange
        _output.WriteLine($"Iterations: {numIterations}");
        var box = new BoundingBox(494, 0, 504, 10);
        var sut = new Cave(box, new Point(500, 0));
        sut.AddPaths(FileParser.ReadFile("day14-example-input.txt"));

        // Act
        for (int i = 0; i < numIterations; i++) sut.AddSand();

        // Assert
        _output.WriteLine(sut.ToString());
        Assert.Equal(expectedDisplay, sut.ToString());
    }

    [Theory]
    [InlineData("day14-example-input.txt", 24)]
    [InlineData("day14-input.txt", 610)]
    public void GivenCaveData_WhenRunUntilStable_ReturnsNumberOfIterations(string filename, int expectedIterations)
    {
        // Arrange
        var box = FileParser.FindBoundngBox(filename);
        var paths = FileParser.ReadFile(filename);
        var sut = new Cave(box, new Point(500, 0));
        sut.AddPaths(paths);

        // Act
        var iterations = sut.AddSandUntilStable();

        // Assert
        Assert.Equal(expectedIterations, iterations);
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

    public static IEnumerable<object[]> ExampleSand()
        => new List<object[]>
             {
                new object[] {
                    1,
                    """
                    ......+...
                    ..........
                    ..........
                    ..........
                    ....#...##
                    ....#...#.
                    ..###...#.
                    ........#.
                    ......o.#.
                    #########.
                    """
                },
                new object[] {
                    2,
                    """
                    ......+...
                    ..........
                    ..........
                    ..........
                    ....#...##
                    ....#...#.
                    ..###...#.
                    ........#.
                    .....oo.#.
                    #########.
                    """
                },
                new object[] {
                    5,
                    """
                    ......+...
                    ..........
                    ..........
                    ..........
                    ....#...##
                    ....#...#.
                    ..###...#.
                    ......o.#.
                    ....oooo#.
                    #########.
                    """
                },
                new object[] {
                    22,
                    """
                    ......+...
                    ..........
                    ......o...
                    .....ooo..
                    ....#ooo##
                    ....#ooo#.
                    ..###ooo#.
                    ....oooo#.
                    ...ooooo#.
                    #########.
                    """
                },
                new object[] {
                    24,
                    """
                    ......+...
                    ..........
                    ......o...
                    .....ooo..
                    ....#ooo##
                    ...o#ooo#.
                    ..###ooo#.
                    ....oooo#.
                    .o.ooooo#.
                    #########.
                    """
                },
            };
}
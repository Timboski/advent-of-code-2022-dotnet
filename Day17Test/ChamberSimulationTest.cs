using Xunit.Abstractions;

namespace Day17Test;

public class ChamberSimulationTest
{
    private readonly ITestOutputHelper _output;

    public ChamberSimulationTest(ITestOutputHelper output) 
        => _output = output;

    [Theory]
    [InlineData(1, """
                    |..####.|
                    +-------+
                    """)]
    [InlineData(2, """
                    |...#...|
                    |..###..|
                    |...#...|
                    |..####.|
                    +-------+
                    """)]
    [InlineData(3, """
                    |..#....|
                    |..#....|
                    |####...|
                    |..###..|
                    |...#...|
                    |..####.|
                    +-------+
                    """)]
    [InlineData(4, """
                    |....#..|
                    |..#.#..|
                    |..#.#..|
                    |#####..|
                    |..###..|
                    |...#...|
                    |..####.|
                    +-------+
                    """)]
    [InlineData(5, """
                    |....##.|
                    |....##.|
                    |....#..|
                    |..#.#..|
                    |..#.#..|
                    |#####..|
                    |..###..|
                    |...#...|
                    |..####.|
                    +-------+
                    """)]
    [InlineData(6, """
                    |.####..|
                    |....##.|
                    |....##.|
                    |....#..|
                    |..#.#..|
                    |..#.#..|
                    |#####..|
                    |..###..|
                    |...#...|
                    |..####.|
                    +-------+
                    """)]
    [InlineData(7, """
                    |..#....|
                    |.###...|
                    |..#....|
                    |.####..|
                    |....##.|
                    |....##.|
                    |....#..|
                    |..#.#..|
                    |..#.#..|
                    |#####..|
                    |..###..|
                    |...#...|
                    |..####.|
                    +-------+
                    """)]
    [InlineData(8, """
                    |.....#.|
                    |.....#.|
                    |..####.|
                    |.###...|
                    |..#....|
                    |.####..|
                    |....##.|
                    |....##.|
                    |....#..|
                    |..#.#..|
                    |..#.#..|
                    |#####..|
                    |..###..|
                    |...#...|
                    |..####.|
                    +-------+
                    """)]
    [InlineData(9, """
                    |....#..|
                    |....#..|
                    |....##.|
                    |....##.|
                    |..####.|
                    |.###...|
                    |..#....|
                    |.####..|
                    |....##.|
                    |....##.|
                    |....#..|
                    |..#.#..|
                    |..#.#..|
                    |#####..|
                    |..###..|
                    |...#...|
                    |..####.|
                    +-------+
                    """)]
    [InlineData(10, """
                    |....#..|
                    |....#..|
                    |....##.|
                    |##..##.|
                    |######.|
                    |.###...|
                    |..#....|
                    |.####..|
                    |....##.|
                    |....##.|
                    |....#..|
                    |..#.#..|
                    |..#.#..|
                    |#####..|
                    |..###..|
                    |...#...|
                    |..####.|
                    +-------+
                    """)]
    public void GivenSimulationTest_WhenDropBlock_ShowsExpectedRepresentation(int numBlocks, string expectedChamber)
    {
        // Arrange
        var filename = "day17-example-input.txt";
        var shapeFactory = new ShapeFactory();
        var jetDirectionFactory = new JetDirectionFactory(filename);
        var sut = new ChamberSimulation(shapeFactory, jetDirectionFactory);

        // Act
        sut.DropRocks(numBlocks);

        // Assert
        _output.WriteLine(sut.ToString());
        Assert.Equal(expectedChamber, sut.ToString());
    }
}
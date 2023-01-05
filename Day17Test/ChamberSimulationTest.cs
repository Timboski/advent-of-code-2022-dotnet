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
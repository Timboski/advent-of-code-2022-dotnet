namespace Day17Test;

public class ChamberSimulationTest
{
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
        Assert.Equal(expectedChamber, sut.ToString());
    }
}
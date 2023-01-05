namespace Day17Test;

public class ChamberSimulationTest
{
    [Fact]
    public void GivenSimulationTest_WhenDropBlock_ShowsExpectedRepresentation()
    {
        // Arrange
        var filename = "day17-example-input.txt";
        var shapeFactory = new ShapeFactory();
        var jetDirectionFactory = new JetDirectionFactory(filename);
        var sut = new ChamberSimulation(shapeFactory, jetDirectionFactory);
        var expectedChamber = """
            |..####.|
            +-------+
            """;

        // Act
        sut.DropRock();

        // Assert
        Assert.Equal(expectedChamber, sut.ToString());
    }
}
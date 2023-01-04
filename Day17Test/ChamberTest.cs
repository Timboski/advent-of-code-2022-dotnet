namespace Day17Test;

public class ChamberTest
{
    [Fact]
    public void GivenShapeFactory_WhenCreateChamber_ShowsExpectedRepresentation()
    {
        // Arrange
        var shapeFactory = new ShapeFactory();
        var expectedChamber = """
            |..@@@@.|
            |.......|
            |.......|
            |.......|
            +-------+
            """;

        // Act
        var sut = new Chamber(shapeFactory);

        // Assert
        Assert.Equal(expectedChamber, sut.ToString());
    }
}
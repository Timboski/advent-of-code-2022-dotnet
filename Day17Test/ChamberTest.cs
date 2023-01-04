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

    [Fact]
    public void GivenInitialChamber_WhenMoveRightIfClear_ShapeMovesRight()
    {
        // Arrange
        var shapeFactory = new ShapeFactory();
        var sut = new Chamber(shapeFactory);
        var expectedChamber = """
            |...@@@@|
            |.......|
            |.......|
            |.......|
            +-------+
            """;

        // Act
        sut.MoveRightIfClear();

        // Assert
        Assert.Equal(expectedChamber, sut.ToString());
    }
}
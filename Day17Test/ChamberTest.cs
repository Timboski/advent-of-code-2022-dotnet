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

    [Fact]
    public void GivenChamber_WhenTryMoveDown_ShapeMovesDown()
    {
        // Arrange
        var shapeFactory = new ShapeFactory();
        var sut = new Chamber(shapeFactory);
        sut.MoveRightIfClear();
        var expectedChamber = """
            |...@@@@|
            |.......|
            |.......|
            +-------+
            """;

        // Act
        sut.TryMoveDown();

        // Assert
        Assert.Equal(expectedChamber, sut.ToString());
    }

    [Fact]
    public void GivenChamberWithShapeBlockedToRight_WhenMoveRightIfClear_ShapeDoesNotMove()
    {
        // Arrange
        var shapeFactory = new ShapeFactory();
        var sut = new Chamber(shapeFactory);
        sut.MoveRightIfClear();
        sut.TryMoveDown();
        var expectedChamber = """
            |...@@@@|
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
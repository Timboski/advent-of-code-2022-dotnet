namespace Day17Test;

public class ChamberTest
{
    [Fact]
    public void GivenInitialShape_WhenCreateChamber_ShowsExpectedRepresentation()
    {
        // Arrange
        var initialShape = new HorizontalShape();
        var expectedChamber = """
            |..@@@@.|
            |.......|
            |.......|
            |.......|
            +-------+
            """;

        // Act
        var sut = new Chamber(initialShape);

        // Assert
        Assert.Equal(expectedChamber, sut.ToString());
    }
}
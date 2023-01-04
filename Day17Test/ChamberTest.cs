namespace Day17Test;

public class ChamberTest
{
    [Fact]
    public void GivenChamber_WhenConvertToString_ShowsEmptyChamber()
    {
        // Arrange
        var expectedChamber = "+-------+";
        var sut = new Chamber();

        // Act
        var chamber = sut.ToString();

        // Assert
        Assert.Equal(expectedChamber, chamber);
    }
}
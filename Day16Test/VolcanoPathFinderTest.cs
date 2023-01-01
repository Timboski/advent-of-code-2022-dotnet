namespace Day16Test;

public class VolcanoPathFinderTest
{
    [Theory]
    [InlineData("day16-example-input.txt", 1651)]
    [InlineData("day16-input.txt", 1559)]
    public void GivenVolcanoPathFinder_WhenMaximisePressure_ReturnsMostPressureReleased(string filename, int expectedResult)
    {
        // Arrange
        var sut = new VolcanoPathFinder(filename);

        // Act
        var pressure = sut.MaximisePressure();

        // Assert
        Assert.Equal(expectedResult, pressure);
    }
}
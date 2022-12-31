namespace Day15Test;

public class ScanTest
{
    [Theory]
    [InlineData("day15-example-input.txt", 10, 26)]
    [InlineData("day15-example-input.txt", 9, 25)]
    [InlineData("day15-example-input.txt", 11, 28)]
    public void GivenInputData_WhenFindExcludedPositions_ReturnsExpectedNumberOfPositions(string filename, int row, int numPositions)
    {
        // Arrange
        var sut = new Scan(filename);

        // Act
        var positions = sut.FindExcludedPositions(row);

        // Assert
        Assert.Equal(numPositions, positions.Count());
    }
}
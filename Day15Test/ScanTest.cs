namespace Day15Test;

public class ScanTest
{
    [Theory]
    [InlineData("day15-example-input.txt", 10, 26)]
    [InlineData("day15-example-input.txt", 9, 25)]
    [InlineData("day15-example-input.txt", 11, 28)]
    [InlineData("day15-input.txt", 2000000, 5335787)]
    public void GivenInputData_WhenFindExcludedPositions_ReturnsExpectedNumberOfPositions(string filename, int row, int numPositions)
    {
        // Arrange
        var sut = new Scan(filename);

        // Act
        var positions = sut.FindExcludedPositions(row);

        // Assert
        Assert.Equal(numPositions, positions.Count());
    }

    [Theory]
    [InlineData("day15-example-input.txt", 20, 56000011)]
    // [InlineData("day15-input.txt", 4000000, ??)]
    public void GivenInputData_WhenFindOnlyPossiblePosition_ReturnsTuningFrequency(string filename, int maxScan, int expectedTuningFrequency)
    {
        // Arrange
        var sut = new Scan(filename);

        // Act
        var tuningFrequency = sut.FindTuningFrequency(maxScan);

        // Assert
        Assert.Equal(expectedTuningFrequency, tuningFrequency);
    }
}
using System.Drawing;

namespace Day15Test;

public class SensorTest
{
    [Fact]
    public void GivenSensorData_WhenCreateSensor_HasCorrectPosition()
    {
        // Arrange
        var data = "Sensor at x=2, y=18: closest beacon is at x=-2, y=15";

        // Act
        var sut = new Sensor(data);

        // Assert
        Assert.Equal(new Point(2, 18), sut.Position);
    }

    [Fact]
    public void GivenSensorData_WhenCreateSensor_HasCorrectNearestBeaconPosition()
    {
        // Arrange
        var data = "Sensor at x=2, y=18: closest beacon is at x=-2, y=15";

        // Act
        var sut = new Sensor(data);

        // Assert
        Assert.Equal(new Point(-2, 15), sut.NearestBeaconPosition);
    }

    [Fact]
    public void GivenSensorData_WhenCreateSensor_FindsManhattenDistanceToBeacon()
    {
        // Arrange
        var data = "Sensor at x=2, y=18: closest beacon is at x=-2, y=15";

        // Act
        var sut = new Sensor(data);

        // Assert
        Assert.Equal(7, sut.DistanceToBeacon);
    }

    [Theory]
    [InlineData(-1, 14)]
    [InlineData(2, 18)]
    [InlineData(3, 18)]
    [InlineData(3, 19)]
    [InlineData(2, 25)]
    [InlineData(9, 18)]
    [InlineData(2, 11)]
    [InlineData(-5, 18)]
    public void GivenSensor_WhenTestIsBeaconPossibleOnEqualOrCloserPosition_ReturnsFalse(int x, int y)
    {
        // Arrange
        var data = "Sensor at x=2, y=18: closest beacon is at x=-2, y=15";
        var sut = new Sensor(data);

        // Act
        var isPossible = sut.IsBeaconPossible(x, y);

        // Assert
        Assert.False(isPossible);
    }

    [Theory]
    [InlineData(-10, 14)]
    [InlineData(2, 26)]
    [InlineData(10, 18)]
    [InlineData(2, 10)]
    [InlineData(-6, 18)]
    public void GivenSensor_WhenTestIsBeaconPossibleOnFurtherPosition_ReturnsTrue(int x, int y)
    {
        // Arrange
        var data = "Sensor at x=2, y=18: closest beacon is at x=-2, y=15";
        var sut = new Sensor(data);

        // Act
        var isPossible = sut.IsBeaconPossible(x, y);

        // Assert
        Assert.True(isPossible);
    }
}
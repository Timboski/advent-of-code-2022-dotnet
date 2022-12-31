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
}
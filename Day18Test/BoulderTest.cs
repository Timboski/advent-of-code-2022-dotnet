namespace Day18Test;

public class BoulderTest
{
    [Fact]
    public void GivenDescription_WhenGetValueOnXAxis_ReturnsXValueFromDescription()
    {
        // Arrange
        var description = "2,3,5";
        const int expectedX = 2;
        var sut = new Boulder(description);

        // Act
        var x = sut.GetValue(Axis.X);

        // Assert
        Assert.Equal(expectedX, x);
    }
}
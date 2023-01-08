namespace Day18Test;

public class TrappedAirTest
{
    [Fact]
    public void GivenExampleInputBoulders_WhenFindTrappedAir_ReturnsExpectedPosition()
    {
        // Arrange
        var boulders = File.ReadAllLines("day18-example-input.txt")
                            .Select(l => new Boulder(l));
        var expectedPosition = (2, 2, 5);

        // Act
        var trappedAir = boulders.FindTrappedAir();

        // Assert
        Assert.Equal(1, trappedAir.Count());
        Assert.Equal (expectedPosition, trappedAir.First().ToTuple());
    }
}
namespace Day18Test;

public class AdjacentBoulderFinderTest
{
    [Fact]
    public void GivenBouldersWithSameXY_WhenCountAdjacentOnZAxis_FindsCorrectNumber()
    {
        // Arrange
        var boulders = new[] { "1,2,3", "1,2,4", "1,2,6", "1,2,7", "1,2,8", "1,2,10" }
                            .Select(l => new Boulder(l));
        var expectedCount = 3;

        // Act
        var count = boulders.CountAdjacentBoulders(Axis.Z);

        // Assert
        Assert.Equal(expectedCount, count);
    }
}
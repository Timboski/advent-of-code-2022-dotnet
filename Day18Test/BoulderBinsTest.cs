namespace Day18Test;

public class BoulderBinsTest
{
    [Fact]
    public void GivenExampleInputBoulders_WhenSortIntoBinsByXAxis_BouldersWithSameXAreInSameBin()
    {
        // Arrange
        var boulders = File.ReadAllLines("day18-example-input.txt")
                            .Select(l => new Boulder(l));

        // Act
        var bins = boulders.SortIntoBins(Axis.X);

        // Assert
        Assert.Equal(3, bins.Count());
        var binnedBoulders = 0;
        foreach (var bin in bins)
        {
            binnedBoulders += bin.Count();
            var expectedX = bin.First().GetValue(Axis.X);
            foreach (var boulder in bin)
                Assert.Equal(expectedX, boulder.GetValue(Axis.X));
        }

        Assert.Equal(boulders.Count(), binnedBoulders);
    }
}
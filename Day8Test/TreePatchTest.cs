namespace Day8Test;

public class TreePatchTest
{
    [Theory]
    [InlineData("day8-example-input.txt", 21)]
    [InlineData("day8-input.txt", 1807)]
    public void GivenMap_WhenCheckVisibility_ReturnsExpectedCount(string filename, int expectedCount)
    {
        // Arrange
        var rows = File.ReadAllLines(filename);
        var sut = new TreePatch(rows);

        // Act
        var result = sut.CountVisible();

        // Assert
        Assert.Equal(expectedCount, result);
    }

    [Theory]
    [InlineData("day8-example-input.txt", 8)]
    // [InlineData("day8-input.txt", ??)]
    public void GivenMap_WhenCheckScenicScore_ReturnsExpectedScore(string filename, int expectedCount)
    {
        // Arrange
        var rows = File.ReadAllLines(filename);
        var sut = new TreePatch(rows);

        // Act
        var result = sut.GetMaxScenicScore();

        // Assert
        Assert.Equal(expectedCount, result);
    }
}
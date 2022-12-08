namespace Day8Test;

public class TreePatchTest
{
    [Theory]
    [InlineData("day8-example-input.txt", 21)]
    public void GivenExampleMap_WhenCheckVisibility_ReturnsExpectedCount(string filename, int expectedCount)
    {
        // Arrange
        var rows = File.ReadAllLines(filename);
        var sut = new TreePatch(rows);

        // Act
        var result = sut.CountVisible();

        // Assert
        Assert.Equal(expectedCount, result);
    }
}
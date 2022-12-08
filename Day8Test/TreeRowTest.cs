using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;

namespace Day8Test;

public class TreeRowTest
{
    [Theory]
    [InlineData("30373", 0)]
    [InlineData("30373", 3)]
    [InlineData("25512", 0)]
    [InlineData("25512", 1)]
    [InlineData("35390", 0)]
    [InlineData("35390", 1)]
    [InlineData("35390", 3)]
    public void GivenRowAndIndexOfVisibleTree_WhenCheckLeft_ReturnsTrue(string row, int index)
    {
        // Arrange
        var sut = new TreeRow(row);

        // Act
        var result = sut.IsVisibleFromLeft(index);

        // Assert
        Assert.True(result);
    }
}
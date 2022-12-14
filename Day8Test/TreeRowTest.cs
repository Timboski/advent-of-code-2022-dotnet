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

    [Theory]
    [InlineData("30373", 1)]
    [InlineData("30373", 2)]
    [InlineData("30373", 4)]
    [InlineData("25512", 2)]
    [InlineData("25512", 3)]
    [InlineData("25512", 4)]
    [InlineData("35390", 2)]
    [InlineData("35390", 4)]
    public void GivenRowAndIndexOfNonVisibleTree_WhenCheckLeft_ReturnsFalse(string row, int index)
    {
        // Arrange
        var sut = new TreeRow(row);

        // Act
        var result = sut.IsVisibleFromLeft(index);

        // Assert
        Assert.False(result);
    }

    [Theory]
    [InlineData("30373", 4)]
    [InlineData("30373", 3)]
    [InlineData("25512", 4)]
    [InlineData("25512", 2)]
    [InlineData("35390", 4)]
    [InlineData("35390", 3)]
    public void GivenRowAndIndexOfVisibleTree_WhenCheckRight_ReturnsTrue(string row, int index)
    {
        // Arrange
        var sut = new TreeRow(row);

        // Act
        var result = sut.IsVisibleFromRight(index);

        // Assert
        Assert.True(result);
    }

    [Theory]
    [InlineData("30373", 2)]
    [InlineData("30373", 1)]
    [InlineData("30373", 0)]
    [InlineData("25512", 3)]
    [InlineData("25512", 1)]
    [InlineData("25512", 0)]
    [InlineData("35390", 2)]
    [InlineData("35390", 1)]
    [InlineData("35390", 0)]
    public void GivenRowAndIndexOfNonVisibleTree_WhenCheckRight_ReturnsFalse(string row, int index)
    {
        // Arrange
        var sut = new TreeRow(row);

        // Act
        var result = sut.IsVisibleFromRight(index);

        // Assert
        Assert.False(result);
    }

    [Theory]
    [InlineData("25512", 2, 1)]
    [InlineData("25512", 4, 2)]
    [InlineData("33549", 2, 2)]
    [InlineData("33549", 0, 0)]
    public void GivenRowAndIndex_WhenCheckLeft_ReturnsVisibleTreeCount(string row, int index, int expectedCount)
    {
        // Arrange
        var sut = new TreeRow(row);

        // Act
        var count = sut.VisibleTreesToLeft(index);

        // Assert
        Assert.Equal(expectedCount, count);
    }

    [Theory]
    [InlineData("25512", 2, 2)]
    [InlineData("25512", 4, 0)]
    [InlineData("33549", 2, 2)]
    [InlineData("33549", 0, 1)]
    public void GivenRowAndIndex_WhenCheckRight_ReturnsVisibleTreeCount(string row, int index, int expectedCount)
    {
        // Arrange
        var sut = new TreeRow(row);

        // Act
        var count = sut.VisibleTreesToRight(index);

        // Assert
        Assert.Equal(expectedCount, count);
    }
}
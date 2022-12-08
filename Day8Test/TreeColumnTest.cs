namespace Day8Test;

public class TreeColumnTest
{
    [Theory]
    [InlineData("30373", 0)]
    [InlineData("30373", 3)]
    [InlineData("25512", 0)]
    [InlineData("25512", 1)]
    [InlineData("35390", 0)]
    [InlineData("35390", 1)]
    [InlineData("35390", 3)]
    public void GivenColumnAndIndexOfVisibleTree_WhenCheckTop_ReturnsTrue(string column, int index)
    {
        // Arrange
        var sut = new TreeColumn(column);

        // Act
        var result = sut.IsVisibleFromTop(index);

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
    public void GivenColumnAndIndexOfNonVisibleTree_WhenCheckTop_ReturnsFalse(string column, int index)
    {
        // Arrange
        var sut = new TreeColumn(column);

        // Act
        var result = sut.IsVisibleFromTop(index);

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
    public void GivenColumnAndIndexOfVisibleTree_WhenCheckBottom_ReturnsTrue(string column, int index)
    {
        // Arrange
        var sut = new TreeColumn(column);

        // Act
        var result = sut.IsVisibleFromBottom(index);

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
    public void GivenColumnAndIndexOfNonVisibleTree_WhenCheckBottom_ReturnsFalse(string column, int index)
    {
        // Arrange
        var sut = new TreeColumn(column);

        // Act
        var result = sut.IsVisibleFromBottom(index);

        // Assert
        Assert.False(result);
    }

    [Theory]
    [InlineData("35353", 0, 0)]
    [InlineData("35353", 1, 1)]
    [InlineData("35353", 2, 1)]
    [InlineData("35353", 3, 2)]
    [InlineData("35353", 4, 1)]
    public void GivenColumnAndIndex_WhenCheckUp_ReturnsVisibleTreeCount(string column, int index, int expectedCount)
    {
        // Arrange
        var sut = new TreeColumn(column);

        // Act
        var count = sut.VisibleTreesToTop(index);

        // Assert
        Assert.Equal(expectedCount, count);
    }

    [Theory]
    [InlineData("35353", 0, 1)]
    [InlineData("35353", 1, 2)]
    [InlineData("35353", 2, 1)]
    [InlineData("35353", 3, 1)]
    [InlineData("35353", 4, 0)]
    public void GivenColumnAndIndex_WhenCheckDown_ReturnsVisibleTreeCount(string column, int index, int expectedCount)
    {
        // Arrange
        var sut = new TreeColumn(column);

        // Act
        var count = sut.VisibleTreesToBottom(index);

        // Assert
        Assert.Equal(expectedCount, count);
    }
}
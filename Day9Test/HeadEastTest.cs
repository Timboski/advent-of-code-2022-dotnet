namespace Day9Test;

public class HeadEastTest
{
    [Fact]
    public void GivenStartPosition_WhenCreateState_EndsInCorrectLocation()
    {
        // Arrange
        var headPosition = new EndPosition(0, 0);
        var expectedTailPosition = new EndPosition(-1, 0);

        // Act
        var sut = new HeadEast(headPosition);

        // Assert
        Assert.Equal(headPosition, sut.HeadPosition);
        Assert.Equal(expectedTailPosition, sut.TailPosition);
    }

    [Fact]
    public void GivenStartingState_WhenMoveNorth_OnlyHeadMovesNorth()
    {
        // Arrange
        var startPosition = new EndPosition(0, 0);
        var endHeadPosition = new EndPosition(0, 1);
        var endTailPosition = new EndPosition(-1, 0);
        var sut = new HeadEast(startPosition);

        // Act
        var newState = sut.MoveNorth();

        // Assert
        Assert.Equal(endHeadPosition, newState.HeadPosition);
        Assert.Equal(endTailPosition, newState.TailPosition);
    }

    [Fact]
    public void GivenStartingState_WhenMoveSouth_OnlyHeadMovesSouth()
    {
        // Arrange
        var startPosition = new EndPosition(0, 0);
        var endHeadPosition = new EndPosition(0, -1);
        var endTailPosition = new EndPosition(-1, 0);
        var sut = new HeadEast(startPosition);

        // Act
        var newState = sut.MoveSouth();

        // Assert
        Assert.Equal(endHeadPosition, newState.HeadPosition);
        Assert.Equal(endTailPosition, newState.TailPosition);
    }

    [Fact]
    public void GivenStartingState_WhenMoveEast_BothEndsMoveEast()
    {
        // Arrange
        var startPosition = new EndPosition(0, 0);
        var endHeadPosition = new EndPosition(1, 0);
        var endTailPosition = new EndPosition(0, 0);
        var sut = new HeadEast(startPosition);

        // Act
        var newState = sut.MoveEast();

        // Assert
        Assert.Equal(endHeadPosition, newState.HeadPosition);
        Assert.Equal(startPosition, newState.TailPosition);
    }

    [Fact]
    public void GivenStartingState_WhenMoveWest_EndsOverlap()
    {
        // Arrange
        var startPosition = new EndPosition(0, 0);
        var endPosition = new EndPosition(-1, 0);
        var sut = new HeadEast(startPosition);

        // Act
        var newState = sut.MoveWest();

        // Assert
        Assert.Equal(endPosition, newState.HeadPosition);
        Assert.Equal(endPosition, newState.TailPosition);
    }
}
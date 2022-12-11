namespace Day9Test;

public class OverlappingEndsTest
{
    [Fact]
    public void GivenStartingState_WhenMoveNorth_OnlyHeadMovesNorth()
    {
        // Arrange
        var startPosition = new EndPosition(0, 0);
        var endHeadPosition = new EndPosition(0, 1);
        var sut = new OverlappingEnds(startPosition);

        // Act
        var newState = sut.MoveNorth();

        // Assert
        Assert.Equal(endHeadPosition, newState.HeadPosition);
        Assert.Equal(startPosition, newState.TailPosition);
    }

    [Fact]
    public void GivenStartingState_WhenMoveSouth_OnlyHeadMovesSouth()
    {
        // Arrange
        var startPosition = new EndPosition(0, 0);
        var endHeadPosition = new EndPosition(0, -1);
        var sut = new OverlappingEnds(startPosition);

        // Act
        var newState = sut.MoveSouth();

        // Assert
        Assert.Equal(endHeadPosition, newState.HeadPosition);
        Assert.Equal(startPosition, newState.TailPosition);
    }

    [Fact]
    public void GivenStartingState_WhenMoveEast_OnlyHeadMovesEast()
    {
        // Arrange
        var startPosition = new EndPosition(0, 0);
        var endHeadPosition = new EndPosition(1, 0);
        var sut = new OverlappingEnds(startPosition);

        // Act
        var newState = sut.MoveEast();

        // Assert
        Assert.Equal(endHeadPosition, newState.HeadPosition);
        Assert.Equal(startPosition, newState.TailPosition);
    }
}
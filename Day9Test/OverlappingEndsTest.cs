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
}
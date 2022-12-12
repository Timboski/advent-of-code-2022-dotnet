namespace Day9Test;

public class RopeTrackerTest
{
    [Theory]
    [InlineData("U 1", 1)]
    [InlineData("U 5", 5)]
    [InlineData("U 10", 10)]
    public void GivenMockState_WhenParseUpInstruction_CallsExpectedMethods(string instruction, int expectedCount)
    {
        // Arrange
        var position = new EndPosition(0, 0);
        var state = new Mock<RopeState>(position);
        state.Setup(a => a.MoveNorth()).Returns(state.Object);
        var sut = new RopeTracker(state.Object);

        // Act
        sut.TrackMotion(instruction);

        // Assert
        state.Verify(a => a.MoveNorth(), Times.Exactly(expectedCount));
        state.VerifyNoOtherCalls();
    }

    [Theory]
    [InlineData("D 1", 1)]
    [InlineData("D 5", 5)]
    [InlineData("D 10", 10)]
    public void GivenMockState_WhenParseDownInstruction_CallsExpectedMethods(string instruction, int expectedCount)
    {
        // Arrange
        var position = new EndPosition(0, 0);
        var state = new Mock<RopeState>(position);
        state.Setup(a => a.MoveSouth()).Returns(state.Object);
        var sut = new RopeTracker(state.Object);

        // Act
        sut.TrackMotion(instruction);

        // Assert
        state.Verify(a => a.MoveSouth(), Times.Exactly(expectedCount));
        state.VerifyNoOtherCalls();
    }
}
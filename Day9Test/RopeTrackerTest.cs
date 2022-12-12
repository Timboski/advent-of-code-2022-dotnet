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
        state.Verify(a => a.TailPosition, Times.AtLeast(1));
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
        state.Verify(a => a.TailPosition, Times.AtLeast(1));
        state.VerifyNoOtherCalls();
    }

    [Theory]
    [InlineData("L 1", 1)]
    [InlineData("L 5", 5)]
    [InlineData("L 10", 10)]
    public void GivenMockState_WhenParseLeftInstruction_CallsExpectedMethods(string instruction, int expectedCount)
    {
        // Arrange
        var position = new EndPosition(0, 0);
        var state = new Mock<RopeState>(position);
        state.Setup(a => a.MoveWest()).Returns(state.Object);
        var sut = new RopeTracker(state.Object);

        // Act
        sut.TrackMotion(instruction);

        // Assert
        state.Verify(a => a.MoveWest(), Times.Exactly(expectedCount));
        state.Verify(a => a.TailPosition, Times.AtLeast(1));
        state.VerifyNoOtherCalls();
    }

    [Theory]
    [InlineData("R 1", 1)]
    [InlineData("R 5", 5)]
    [InlineData("R 10", 10)]
    public void GivenMockState_WhenParseRightInstruction_CallsExpectedMethods(string instruction, int expectedCount)
    {
        // Arrange
        var position = new EndPosition(0, 0);
        var state = new Mock<RopeState>(position);
        state.Setup(a => a.MoveEast()).Returns(state.Object);
        var sut = new RopeTracker(state.Object);

        // Act
        sut.TrackMotion(instruction);

        // Assert
        state.Verify(a => a.MoveEast(), Times.Exactly(expectedCount));
        state.Verify(a => a.TailPosition, Times.AtLeast(1));
        state.VerifyNoOtherCalls();
    }

    [Theory]
    [InlineData("day9-example-input.txt", 13)]
    [InlineData("day9-input.txt", 6357)]
    public void GivenRopeMotions_WhenTrackTail_VisitsExpectedNumberOfLocations(string fileName, int expectedCount) 
    {
        // Arrange
        var sut = new RopeTracker();

        // Act
        sut.ParseFile(fileName);

        // Assert
        Assert.Equal(expectedCount, sut.TailVisits);
    }
}
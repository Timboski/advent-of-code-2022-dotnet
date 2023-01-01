namespace Day16Test;

public class VolcanoMazeTest
{
    [Fact]
    public void GivenInputFile_WhenCreateVolcanoMaze_ContainsExpectedValves()
    {
        // Arrange
        var filename = "day16-example-input.txt";
        var expectedValves = "AABBCCDDEEFFGGHHIIJJ";

        // Act
        var sut = new VolcanoMaze(filename);

        // Assert
        Assert.Equal(expectedValves, sut.Valves);
    }

    [Fact]
    public void GivenInputFile_WhenCreateVolcanoMaze_ValvesHaveCorrectPressure()
    {
        // Arrange
        var filename = "day16-example-input.txt";
        var expectedValves = new (string Valve, int Pressure)[] {
                ("AA", 0),
                ("BB", 13),
                ("CC", 2),
                ("DD", 20),
                ("EE", 3),
                ("FF", 0),
                ("GG", 0),
                ("HH", 22),
                ("II", 0),
                ("JJ", 21),
            };

        // Act
        var sut = new VolcanoMaze(filename);

        // Assert
        foreach (var (valve, pressure) in expectedValves)
            Assert.Equal(pressure, sut.GetPressure(valve));
    }

    [Fact]
    public void GivenInputFile_WhenCreateVolcanoMaze_PathsToOtherValvesAreListed()
    {
        // Arrange
        var filename = "day16-example-input.txt";
        var expectedValves = new (string Valve, string[] Paths)[] {
                ("AA", new [] { "DD", "II", "BB" }),
                ("BB", new [] { "CC", "AA" }),
                ("CC", new [] { "DD", "BB" }),
                ("DD", new [] { "CC", "AA", "EE" }),
                ("EE", new [] { "FF", "DD" }),
                ("FF", new [] { "EE", "GG" }),
                ("GG", new [] { "FF", "HH" }),
                ("HH", new [] { "GG" }),
                ("II", new [] { "AA", "JJ" }),
                ("JJ", new [] { "II" })
            };

        // Act
        var sut = new VolcanoMaze(filename);

        // Assert
        foreach (var (valve, paths) in expectedValves)
            Assert.Equal(paths, sut.GetPaths(valve));
    }

    [Theory]
    [InlineData("BB", "BBBB", "CC", "AA")] // Open or move
    [InlineData("AA", "DD", "II", "BB")] // Do not open zero pressure valves
    public void GivenVolcanoMazeAndCurrentState_WhenFindNextStates_ReturnsListOfPossibleMoves(string currentState, params string[] expectedNextStates)
    {
        // Arrange
        var filename = "day16-example-input.txt";
        var sut = new VolcanoMaze(filename);

        // Act
        var nextStates = sut.FindNextStates(currentState, 0, 30);

        // Assert
        Assert.Equal(expectedNextStates, nextStates.Select(a => a.State));
    }

    [Fact]
    public void GivenVolcanoMazeAfterMoves_WhenFindNextStatesOnPreviouslyVisitedValveByWorsePath_ReturnsEmptyList()
    {
        // Arrange
        var filename = "day16-example-input.txt";
        var sut = new VolcanoMaze(filename);
        _ = sut.FindNextStates("AA", 20, 30).ToList();

        // Act
        var nextStates = sut.FindNextStates("AA", 10, 30);

        // Assert
        Assert.Empty(nextStates);
    }

    [Fact]
    public void GivenVolcanoMazeAfterMoves_WhenFindNextStatesOnPreviouslyVisitedValveByEqualPath_ReturnsEmptyList()
    {
        // Arrange
        var filename = "day16-example-input.txt";
        var sut = new VolcanoMaze(filename);
        _ = sut.FindNextStates("AA", 20, 30).ToList();

        // Act
        var nextStates = sut.FindNextStates("AA", 20, 30);

        // Assert
        Assert.Empty(nextStates);
    }

    [Fact]
    public void GivenVolcanoMazeAfterMoves_WhenFindNextStatesOnPreviouslyVisitedValveByBetterPath_ReturnsEmptyList()
    {
        // Arrange
        var filename = "day16-example-input.txt";
        var sut = new VolcanoMaze(filename);
        _ = sut.FindNextStates("AA", 20, 30).ToList();

        // Act
        var nextStates = sut.FindNextStates("AA", 21, 30);

        // Assert
        Assert.NotEmpty(nextStates);
    }
}
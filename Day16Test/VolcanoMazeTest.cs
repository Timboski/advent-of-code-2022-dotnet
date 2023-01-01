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
        foreach (var valve in expectedValves )
            Assert.Equal(valve.Pressure, sut.GetPressure(valve.Valve));
    }
}
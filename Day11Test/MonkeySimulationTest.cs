namespace Day11Test;

public class MonkeySimulationTest
{
    [Theory]
    [MemberData(nameof(ExampleRoundData))]
    public void GivenMonkeyData_WhenRunRounds_MonkeysHoldExpectedItems(string monkeyDataFile, int numberOfRounds, int[][] expectedItems)
    {
        // Arrange
        var sut = new MonkeySimulation(monkeyDataFile);

        // Act
        // Run Rounds (for zero just check initial data)

        // Assert
        for (int i = 0; i < expectedItems.Length; ++i)
            Assert.Equal(expectedItems[i], sut.Monkey[i].Items);
    }

    public static IEnumerable<object[]> ExampleRoundData() 
        => new List<object[]>
        {
            new object[] {
                // Check initial Data
                "day11-example-input.txt",
                0,
                new int[4][] {
                    new int[] { 79, 98 },
                    new int[] { 54, 65, 75, 74 },
                    new int[] { 79, 60, 97},
                    new int[] { 74 }
                }},
        };
}
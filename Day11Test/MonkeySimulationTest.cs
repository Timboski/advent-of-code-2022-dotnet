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
        for (int i = 0; i < numberOfRounds; ++i)
            sut.ProcessRound();

        // Assert
        for (int i = 0; i < expectedItems.Length; ++i)
            Assert.Equal(expectedItems[i], sut.Monkey[i].Items);
    }

    [Theory]
    [InlineData("day11-example-input.txt", 10605)]
    public void GivenMonkeyData_WhenFindMonkyBusinessAfter20Rounds_ReturnsExpectedScore(string monkeyDataFile, int expectedMonkeyBusiness)
    {
        // Arrange
        var sut = new MonkeySimulation(monkeyDataFile);

        // Act
        var monkeyBusiness = sut.FindMonkeyBusiness(20);

        // Assert
        Assert.Equal(expectedMonkeyBusiness, monkeyBusiness);
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
            new object[] {
                "day11-example-input.txt",
                1,
                new int[4][] {
                    new int[] { 20, 23, 27, 26 },
                    new int[] { 2080, 25, 167, 207, 401, 1046 },
                    Array.Empty < int >(),
                    Array.Empty < int >()
                }},
            new object[] {
                "day11-example-input.txt",
                2,
                new int[4][] {
                    new int[] { 695, 10, 71, 135, 350 },
                    new int[] { 43, 49, 58, 55, 362 },
                    Array.Empty < int >(),
                    Array.Empty < int >()
                }},
            new object[] {
                "day11-example-input.txt",
                3,
                new int[4][] {
                    new int[] { 16, 18, 21, 20, 122 },
                    new int[] { 1468, 22, 150, 286, 739 },
                    Array.Empty < int >(),
                    Array.Empty < int >()
                }},
            new object[] {
                "day11-example-input.txt",
                4,
                new int[4][] {
                    new int[] { 491, 9, 52, 97, 248, 34 },
                    new int[] { 39, 45, 43, 258 },
                    Array.Empty < int >(),
                    Array.Empty < int >()
                }},
            new object[] {
                "day11-example-input.txt",
                5,
                new int[4][] {
                    new int[] { 15, 17, 16, 88, 1037 },
                    new int[] { 20, 110, 205, 524, 72 },
                    Array.Empty < int >(),
                    Array.Empty < int >()
                }},
            new object[] {
                "day11-example-input.txt",
                6,
                new int[4][] {
                    new int[] { 8, 70, 176, 26, 34 },
                    new int[] { 481, 32, 36, 186, 2190 },
                    Array.Empty < int >(),
                    Array.Empty < int >()
                }},
            new object[] {
                "day11-example-input.txt",
                7,
                new int[4][] {
                    new int[] { 162, 12, 14, 64, 732, 17 },
                    new int[] { 148, 372, 55, 72 },
                    Array.Empty < int >(),
                    Array.Empty < int >()
                }},
            new object[] {
                "day11-example-input.txt",
                8,
                new int[4][] {
                    new int[] { 51, 126, 20, 26, 136 },
                    new int[] { 343, 26, 30, 1546, 36 },
                    Array.Empty < int >(),
                    Array.Empty < int >()
                }},
            new object[] {
                "day11-example-input.txt",
                9,
                new int[4][] {
                    new int[] { 116, 10, 12, 517, 14 },
                    new int[] { 108, 267, 43, 55, 288 },
                    Array.Empty < int >(),
                    Array.Empty < int >()
                }},
            new object[] {
                "day11-example-input.txt",
                10,
                new int[4][] {
                    new int[] { 91, 16, 20, 98 },
                    new int[] { 481, 245, 22, 26, 1092, 30 },
                    Array.Empty < int >(),
                    Array.Empty<int>()
                }},
            new object[] {
                "day11-example-input.txt",
                15,
                new int[4][] {
                    new int[] { 83, 44, 8, 184, 9, 20, 26, 102 },
                    new int[] { 110, 36 },
                    Array.Empty < int >(),
                    Array.Empty<int>()
                }},
            new object[] {
                "day11-example-input.txt",
                20,
                new int[4][] {
                    new int[] { 10, 12, 14, 26, 34 },
                    new int[] { 245, 93, 53, 199, 115 },
                    Array.Empty<int>(),
                    Array.Empty<int>()
                }},
        };
}
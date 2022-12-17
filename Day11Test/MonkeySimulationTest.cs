using Xunit.Abstractions;

namespace Day11Test;

public class MonkeySimulationTest
{
    private readonly ITestOutputHelper _output;

    public MonkeySimulationTest(ITestOutputHelper output) => _output = output;

    [Theory]
    [MemberData(nameof(ExampleRoundData))]
    public void GivenMonkeyData_WhenRunRounds_MonkeysHoldExpectedItems(string monkeyDataFile, int numberOfRounds, long[][] expectedItems)
    {
        // Arrange
        var sut = new MonkeySimulation(monkeyDataFile, true);

        // Act
        for (int i = 0; i < numberOfRounds; ++i)
            sut.ProcessRound();

        // Debug
        _output.WriteLine("Actual:");
        foreach (var monkey in sut.Monkey) 
            _output.WriteLine(string.Join(", ", monkey.Items));
        _output.WriteLine("");
        _output.WriteLine("Expected:");
        foreach (var exp in expectedItems)
            _output.WriteLine(string.Join(", ", exp));

        // Assert
        for (int i = 0; i < expectedItems.Length; ++i)
            Assert.Equal(expectedItems[i], sut.Monkey[i].Items);
    }

    [Theory]
    [InlineData("day11-example-input.txt", 10605)]
    [InlineData("day11-input.txt", 120756)]
    public void GivenMonkeyData_WhenFindMonkyBusinessAfter20Rounds_ReturnsExpectedScore(string monkeyDataFile, long expectedMonkeyBusiness)
    {
        // Arrange
        var sut = new MonkeySimulation(monkeyDataFile, true);

        // Act
        var monkeyBusiness = sut.FindMonkeyBusiness(20);

        // Assert
        Assert.Equal(expectedMonkeyBusiness, monkeyBusiness);
    }

    [Theory]
    [InlineData("day11-example-input.txt", 1, new int[] { 2, 4, 3, 6 })]
    public void GivenMonkeyData_WhenFindMonkyBusinessWithNoRelief_ReturnsExpectedScore(string monkeyDataFile, int numRounds, int[] expectedMonkeyBusiness)
    {
        // Arrange
        var sut = new MonkeySimulation(monkeyDataFile);

        // Act
        _ = sut.FindMonkeyBusiness(numRounds);

        // Assert
        var monkeyBusiness = sut.Monkey.Select(m => m.NumInspections).ToArray();
        Assert.Equal(expectedMonkeyBusiness, monkeyBusiness);
    }

    public static IEnumerable<object[]> ExampleRoundData() 
        => new List<object[]>
        {
            new object[] {
                // Check initial Data
                "day11-example-input.txt",
                0,
                new long[4][] {
                    new long[] { 79, 98 },
                    new long[] { 54, 65, 75, 74 },
                    new long[] { 79, 60, 97},
                    new long[] { 74 }
                }},
            new object[] {
                "day11-example-input.txt",
                1,
                new long[4][] {
                    new long[] { 20, 23, 27, 26 },
                    new long[] { 2080, 25, 167, 207, 401, 1046 },
                    Array.Empty < long >(),
                    Array.Empty < long >()
                }},
            new object[] {
                "day11-example-input.txt",
                2,
                new long[4][] {
                    new long[] { 695, 10, 71, 135, 350 },
                    new long[] { 43, 49, 58, 55, 362 },
                    Array.Empty < long >(),
                    Array.Empty < long >()
                }},
            new object[] {
                "day11-example-input.txt",
                3,
                new long[4][] {
                    new long[] { 16, 18, 21, 20, 122 },
                    new long[] { 1468, 22, 150, 286, 739 },
                    Array.Empty < long >(),
                    Array.Empty < long >()
                }},
            new object[] {
                "day11-example-input.txt",
                4,
                new long[4][] {
                    new long[] { 491, 9, 52, 97, 248, 34 },
                    new long[] { 39, 45, 43, 258 },
                    Array.Empty < long >(),
                    Array.Empty < long >()
                }},
            new object[] {
                "day11-example-input.txt",
                5,
                new long[4][] {
                    new long[] { 15, 17, 16, 88, 1037 },
                    new long[] { 20, 110, 205, 524, 72 },
                    Array.Empty < long >(),
                    Array.Empty < long >()
                }},
            new object[] {
                "day11-example-input.txt",
                6,
                new long[4][] {
                    new long[] { 8, 70, 176, 26, 34 },
                    new long[] { 481, 32, 36, 186, 2190 },
                    Array.Empty < long >(),
                    Array.Empty < long >()
                }},
            new object[] {
                "day11-example-input.txt",
                7,
                new long[4][] {
                    new long[] { 162, 12, 14, 64, 732, 17 },
                    new long[] { 148, 372, 55, 72 },
                    Array.Empty < long >(),
                    Array.Empty < long >()
                }},
            new object[] {
                "day11-example-input.txt",
                8,
                new long[4][] {
                    new long[] { 51, 126, 20, 26, 136 },
                    new long[] { 343, 26, 30, 1546, 36 },
                    Array.Empty < long >(),
                    Array.Empty < long >()
                }},
            new object[] {
                "day11-example-input.txt",
                9,
                new long[4][] {
                    new long[] { 116, 10, 12, 517, 14 },
                    new long[] { 108, 267, 43, 55, 288 },
                    Array.Empty < long >(),
                    Array.Empty < long >()
                }},
            new object[] {
                "day11-example-input.txt",
                10,
                new long[4][] {
                    new long[] { 91, 16, 20, 98 },
                    new long[] { 481, 245, 22, 26, 1092, 30 },
                    Array.Empty < long >(),
                    Array.Empty<long>()
                }},
            new object[] {
                "day11-example-input.txt",
                15,
                new long[4][] {
                    new long[] { 83, 44, 8, 184, 9, 20, 26, 102 },
                    new long[] { 110, 36 },
                    Array.Empty < long >(),
                    Array.Empty<long>()
                }},
            new object[] {
                "day11-example-input.txt",
                20,
                new long[4][] {
                    new long[] { 10, 12, 14, 26, 34 },
                    new long[] { 245, 93, 53, 199, 115 },
                    Array.Empty<long>(),
                    Array.Empty<long>()
                }},
            new object[] {
                // Check initial Data
                "day11-input.txt",
                0,
                new long[8][] {
                    new long[] { 92, 73, 86, 83, 65, 51, 55, 93 },
                    new long[] { 99, 67, 62, 61, 59, 98 },
                    new long[] { 81, 89, 56, 61, 99 },
                    new long[] { 97, 74, 68 },
                    new long[] { 78, 73 },
                    new long[] { 50 },
                    new long[] { 95, 88, 53, 75 },
                    new long[] { 50, 77, 98, 85, 94, 56, 89 },
                }},
        };
}
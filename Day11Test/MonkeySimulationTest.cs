using System.Numerics;
using Xunit.Abstractions;

namespace Day11Test;

public class MonkeySimulationTest
{
    private readonly ITestOutputHelper _output;

    public MonkeySimulationTest(ITestOutputHelper output) => _output = output;

    [Theory]
    [MemberData(nameof(ExampleRoundData))]
    public void GivenMonkeyData_WhenRunRounds_MonkeysHoldExpectedItems(string monkeyDataFile, int numberOfRounds, BigInteger[][] expectedItems)
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
    public void GivenMonkeyData_WhenFindMonkyBusinessAfter20Rounds_ReturnsExpectedScore(string monkeyDataFile, int expectedMonkeyBusiness)
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
    [InlineData("day11-example-input.txt", 20, new int[] { 99, 97, 8, 103 })]
    [InlineData("day11-example-input.txt", 1000, new int[] { 5204, 4792, 199, 5192 })]
    [InlineData("day11-example-input.txt", 2000, new int[] { 10419, 9577, 392, 10391})]
    [InlineData("day11-example-input.txt", 3000, new int[] { 15638, 14358, 587, 15593 })]
    [InlineData("day11-example-input.txt", 4000, new int[] { 20858, 19138, 780, 20797 })]
    [InlineData("day11-example-input.txt", 5000, new int[] { 26075, 23921, 974, 26000 })]
    [InlineData("day11-example-input.txt", 6000, new int[] { 31294, 28702, 1165, 31204 })]
    [InlineData("day11-example-input.txt", 7000, new int[] { 36508, 33488, 1360, 36400 })]
    [InlineData("day11-example-input.txt", 8000, new int[] { 41728, 38268, 1553, 41606 })]
    [InlineData("day11-example-input.txt", 9000, new int[] { 46945, 43051, 1746, 46807 })]
    [InlineData("day11-example-input.txt", 10000, new int[] { 52166, 47830, 1938, 52013 })]
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

    [Theory]
    [MemberData(nameof(Part2Regression))]
    public void GivenMonkeyData_WhenFindTotalMonkyBusinessWithNoRelief_ReturnsExpectedScore(string monkeyDataFile, BigInteger expectedMonkeyBusiness)
    {
        // Arrange
        const int NumRounds = 10000;
        var sut = new MonkeySimulation(monkeyDataFile);

        // Act
        var monkeyBusiness = sut.FindMonkeyBusiness(NumRounds);

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
                new BigInteger[4][] {
                    new BigInteger[] { 79, 98 },
                    new BigInteger[] { 54, 65, 75, 74 },
                    new BigInteger[] { 79, 60, 97},
                    new BigInteger[] { 74 }
                }},
            new object[] {
                "day11-example-input.txt",
                1,
                new BigInteger[4][] {
                    new BigInteger[] { 20, 23, 27, 26 },
                    new BigInteger[] { 2080, 25, 167, 207, 401, 1046 },
                    Array.Empty < BigInteger >(),
                    Array.Empty < BigInteger >()
                }},
            new object[] {
                "day11-example-input.txt",
                2,
                new BigInteger[4][] {
                    new BigInteger[] { 695, 10, 71, 135, 350 },
                    new BigInteger[] { 43, 49, 58, 55, 362 },
                    Array.Empty < BigInteger >(),
                    Array.Empty < BigInteger >()
                }},
            new object[] {
                "day11-example-input.txt",
                3,
                new BigInteger[4][] {
                    new BigInteger[] { 16, 18, 21, 20, 122 },
                    new BigInteger[] { 1468, 22, 150, 286, 739 },
                    Array.Empty < BigInteger >(),
                    Array.Empty < BigInteger >()
                }},
            new object[] {
                "day11-example-input.txt",
                4,
                new BigInteger[4][] {
                    new BigInteger[] { 491, 9, 52, 97, 248, 34 },
                    new BigInteger[] { 39, 45, 43, 258 },
                    Array.Empty < BigInteger >(),
                    Array.Empty < BigInteger >()
                }},
            new object[] {
                "day11-example-input.txt",
                5,
                new BigInteger[4][] {
                    new BigInteger[] { 15, 17, 16, 88, 1037 },
                    new BigInteger[] { 20, 110, 205, 524, 72 },
                    Array.Empty < BigInteger >(),
                    Array.Empty < BigInteger >()
                }},
            new object[] {
                "day11-example-input.txt",
                6,
                new BigInteger[4][] {
                    new BigInteger[] { 8, 70, 176, 26, 34 },
                    new BigInteger[] { 481, 32, 36, 186, 2190 },
                    Array.Empty < BigInteger >(),
                    Array.Empty < BigInteger >()
                }},
            new object[] {
                "day11-example-input.txt",
                7,
                new BigInteger[4][] {
                    new BigInteger[] { 162, 12, 14, 64, 732, 17 },
                    new BigInteger[] { 148, 372, 55, 72 },
                    Array.Empty < BigInteger >(),
                    Array.Empty < BigInteger >()
                }},
            new object[] {
                "day11-example-input.txt",
                8,
                new BigInteger[4][] {
                    new BigInteger[] { 51, 126, 20, 26, 136 },
                    new BigInteger[] { 343, 26, 30, 1546, 36 },
                    Array.Empty < BigInteger >(),
                    Array.Empty < BigInteger >()
                }},
            new object[] {
                "day11-example-input.txt",
                9,
                new BigInteger[4][] {
                    new BigInteger[] { 116, 10, 12, 517, 14 },
                    new BigInteger[] { 108, 267, 43, 55, 288 },
                    Array.Empty < BigInteger >(),
                    Array.Empty < BigInteger >()
                }},
            new object[] {
                "day11-example-input.txt",
                10,
                new BigInteger[4][] {
                    new BigInteger[] { 91, 16, 20, 98 },
                    new BigInteger[] { 481, 245, 22, 26, 1092, 30 },
                    Array.Empty < BigInteger >(),
                    Array.Empty<BigInteger>()
                }},
            new object[] {
                "day11-example-input.txt",
                15,
                new BigInteger[4][] {
                    new BigInteger[] { 83, 44, 8, 184, 9, 20, 26, 102 },
                    new BigInteger[] { 110, 36 },
                    Array.Empty < BigInteger >(),
                    Array.Empty<BigInteger>()
                }},
            new object[] {
                "day11-example-input.txt",
                20,
                new BigInteger[4][] {
                    new BigInteger[] { 10, 12, 14, 26, 34 },
                    new BigInteger[] { 245, 93, 53, 199, 115 },
                    Array.Empty<BigInteger>(),
                    Array.Empty<BigInteger>()
                }},
            new object[] {
                // Check initial Data
                "day11-input.txt",
                0,
                new BigInteger[8][] {
                    new BigInteger[] { 92, 73, 86, 83, 65, 51, 55, 93 },
                    new BigInteger[] { 99, 67, 62, 61, 59, 98 },
                    new BigInteger[] { 81, 89, 56, 61, 99 },
                    new BigInteger[] { 97, 74, 68 },
                    new BigInteger[] { 78, 73 },
                    new BigInteger[] { 50 },
                    new BigInteger[] { 95, 88, 53, 75 },
                    new BigInteger[] { 50, 77, 98, 85, 94, 56, 89 },
                }},
        };

    public static IEnumerable<object[]> Part2Regression()
        => new List<object[]>
        {
            new object[] {
                // Check part2 example
                "day11-example-input.txt",
                (BigInteger)2713310158,
            },
            new object[] {
                // Check part2 example
                "day11-input.txt",
                (BigInteger)39109444654,
            },
        };
}
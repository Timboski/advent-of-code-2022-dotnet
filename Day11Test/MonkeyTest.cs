using System.Numerics;
using Xunit.Abstractions;

namespace Day11Test;

public class MonkeyTest
{
    private readonly ITestOutputHelper _output;

    public MonkeyTest(ITestOutputHelper output) => _output = output;

    [Theory]
    [MemberData(nameof(InitialItems))]
    public void GivenMonkeyData_WhenCreateMonkey_HoldsExpectedItems(List<string> monkeyData, BigInteger[] expectedItems)
    {
        // Arrange
        // Act
        var sut = new Monkey(monkeyData, true);

        // Assert
        Assert.Equal(expectedItems, sut.Items);
    }

    [Theory]
    [MemberData(nameof(NewWorryLevel))]
    public void GivenMonkeyData_WhenInspectItems_ReturnsExpectedWorryLevel(List<string> monkeyData, BigInteger[] expectedWorryLevel)
    {
        // Arrange
        var sut = new Monkey(monkeyData, true);

        // Act
        var res = new List<BigInteger>(expectedWorryLevel.Length);
        while (sut.InspectItem(out int _, out IWorryLevel? worryLevel)) 
            res.Add(worryLevel?.Level ?? 0);

        // Assert
        Assert.Equal(expectedWorryLevel, res);
    }

    [Theory]
    [MemberData(nameof(TargetMonkey))]
    public void GivenMonkeyData_WhenInspectItems_ReturnsExpectedTargetMonkey(List<string> monkeyData, int[] expectedTargetMonkey)
    {
        // Arrange
        var sut = new Monkey(monkeyData, true);

        // Act
        var res = new List<int>(expectedTargetMonkey.Length);
        while (sut.InspectItem(out int targetMonkey, out IWorryLevel? _)) res.Add(targetMonkey);

        // Assert
        Assert.Equal(expectedTargetMonkey, res);
    }

    public static IEnumerable<object[]> InitialItems()
    {
        var monkey = MonkeyData();
        return new List<object[]>
        {
            new object[] { monkey[0], new BigInteger[] { 79, 98 } },
            new object[] { monkey[1], new BigInteger[] { 54, 65, 75, 74 } },
            new object[] { monkey[2], new BigInteger[] { 79, 60, 97 } },
            new object[] { monkey[3], new BigInteger[] { 74 } },
        };
    }

    public static IEnumerable<object[]> NewWorryLevel()
    {
        var monkey = MonkeyData();
        return new List<object[]>
        {
            // new = old * 19  (and then divided by 3)
            new object[] { monkey[0], new BigInteger[] { 500, 620 } },
            // new = old + 6  (and then divided by 3)
            new object[] { monkey[1], new BigInteger[] { 20, 23, 27, 26 } },
            // new = old * old  (and then divided by 3)
            new object[] { monkey[2], new BigInteger[] { 2080, 1200, 3136 } },
            // new = old + 3  (and then divided by 3)
            new object[] { monkey[3], new BigInteger[] { 25 } },
        };
    }

    public static IEnumerable<object[]> TargetMonkey()
    {
        var monkey = MonkeyData();
        return new List<object[]>
        {
            new object[] { monkey[0], new int[] { 3, 3 } },
            new object[] { monkey[1], new int[] { 0, 0, 0, 0 } },
            new object[] { monkey[2], new int[] { 1, 3, 3 } },
            new object[] { monkey[3], new int[] { 1 } },
        };
    }

    private static List<List<string>> MonkeyData()
    {
        var lines = File.ReadAllLines("day11-example-input.txt");
        return new List<List<string>>()
        {
            lines[1..6].ToList(),
            lines[8..13].ToList(),
            lines[15..20].ToList(),
            lines[22..27].ToList(),
        };
    }
}
using System.Linq;
using Xunit.Abstractions;

namespace Day11Test;

public class MonkeyTest
{
    private readonly ITestOutputHelper _output;

    public MonkeyTest(ITestOutputHelper output) => _output = output;

    [Theory]
    [MemberData(nameof(InitialItems))]
    public void GivenMonkeyData_WhenCreateMonkey_HoldsExpectedItems(List<string> monkeyData, int[] expectedItems)
    {
        // Check the test is receving the correct data!
        _output.WriteLine(string.Join(Environment.NewLine, monkeyData));
        _output.WriteLine(string.Join(", ", expectedItems));
    }

    public static IEnumerable<object[]> InitialItems()
    {
        var monkey = MonkeyData();
        return new List<object[]>
        {
                new object[] { monkey[0], new int[] { 79, 98 } },
                new object[] { monkey[1], new int[] { 54, 65, 75, 74 } },
                new object[] { monkey[2], new int[] { 79, 60, 97 } },
                new object[] { monkey[3], new int[] { 74 } },
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
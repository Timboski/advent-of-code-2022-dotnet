var input = File.ReadAllLines("day1-input.txt");

var elves = Split(input).ToList();
elves.Sort();
elves.Reverse();

var max = elves.First();
Console.WriteLine($"Max = {max}");

var topThree = elves.Take(3).Sum();
Console.WriteLine($"Top Three = {topThree}");

// Regression
if (max != 67027 || topThree != 197291)
    Console.WriteLine("ERROR: INCORRECT RESULT");

static IEnumerable<int> Split(IEnumerable<string> input)
{
    var total = 0;
    foreach (var item in input) 
    {
        if (int.TryParse(item, out int calories))
        {
            total += calories;
        }
        else
        {
            yield return total;
            total = 0;
        }
    }
    yield return total;
}
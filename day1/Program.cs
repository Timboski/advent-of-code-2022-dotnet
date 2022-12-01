var lines = File.ReadAllLines("day1-input.txt");

var elves = new List<int>();
var total = 0;
foreach (var line in lines)
{
    try
    {
        var calories = int.Parse(line);
        total += calories;
    }
    catch 
    {
        elves.Add(total);
        total = 0;
    }
}

elves.Add(total);
elves.Sort();
elves.Reverse();
var max = elves.First();

Console.WriteLine($"Max = {max}");

var topThree = elves.Take(3).Sum();

Console.WriteLine($"Top Three = {topThree}");

// Regression
if (max != 67027 || topThree != 197291)
    Console.WriteLine("ERROR: INCORRECT RESULT");
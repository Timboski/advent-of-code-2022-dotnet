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

var max = elves[^1];
Console.WriteLine($"Max = {max}");

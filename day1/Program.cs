var lines = File.ReadAllLines("day1-input.txt");

var total = 0;
var max = 0;
foreach (var line in lines)
{
    try
    {
        var calories = int.Parse(line);
        total += calories;
    }
    catch 
    {
        if (total > max) max = total;
        total = 0;
    }
}
if (total> max) max = total;

Console.WriteLine($"Max = {max}");

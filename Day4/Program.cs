using Day4;

var input = File.ReadAllLines("day4-input.txt");
var result = OverlapChecker.Count(input);
Console.WriteLine($"Part 1: {result}");

var result2 = OverlapChecker.CountPartial(input);
Console.WriteLine($"Part 2: {result2}");

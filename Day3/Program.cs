using Day3;

var input = File.ReadAllLines("day3-input.txt");
var result = input.Select(line => ScoreRucksack.FindPriority(ScoreRucksack.Examine(line))).Sum();
Console.WriteLine(result);
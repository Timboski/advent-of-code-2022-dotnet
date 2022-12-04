using Day3;

var input = File.ReadAllLines("day3-input.txt");
var result = input.Select(line => ScoreRucksack.FindPriority(ScoreRucksack.Examine(line))).Sum();
Console.WriteLine($"Part1: {result}");

var result2 = ElfGroup.BadgePriority(input);
Console.WriteLine($"Part2: {result2}");
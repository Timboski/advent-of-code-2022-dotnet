using day2;

var input = File.ReadAllLines("day2-input.txt");
var result = GameStrategy.Solve(input);
Console.WriteLine($"Part 1: {result}");

var result2 = GameStrategy.SolveFixed(input);
Console.WriteLine($"Part 2: {result2}");
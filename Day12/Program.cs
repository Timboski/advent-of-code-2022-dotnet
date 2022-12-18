using Day12;

var sut = new HillClimb("day12-input.txt");
var steps = sut.FindPath();
Console.WriteLine($"Part 1: {steps}");

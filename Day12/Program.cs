using Day12;

var sut = new HillClimb("day12-input.txt");
var steps = sut.FindPath();
Console.WriteLine($"Part 1: {steps}");

var sut2 = new HillClimb("day12-input.txt");
var steps2 = sut2.FindHikingTrail();
Console.WriteLine($"Part 2: {steps2}");

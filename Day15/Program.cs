using Day15;

var sut = new Scan("day15-input.txt");
var positions = sut.FindExcludedPositions(2000000);
var count = positions.Count();
Console.WriteLine($"Part 1: {count}");

using Day15;

var sut = new Scan("day15-input.txt");
var positions = sut.FindExcludedPositions(2000000);
var count = positions.Count();
Console.WriteLine($"Part 1: {count}");

var tuningFrequency = sut.FindTuningFrequency(4000000);
Console.WriteLine($"Part 2: {tuningFrequency}");
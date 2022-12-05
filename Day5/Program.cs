using Day5;

var lines = File.ReadLines("day5-input.txt");
var sut = new Ship();
var result = sut.Process(lines);
Console.WriteLine($"Part 1: {result}");

var sut2 = new Ship();
var result2 = sut.WhenProcessCraneMover9001(lines);
Console.WriteLine($"Part 2: {result2}");
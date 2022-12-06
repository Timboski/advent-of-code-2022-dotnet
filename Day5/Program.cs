using Day5;

var lines = File.ReadLines("day5-input.txt");
var sut = new Ship();
ShipLoader.LoadCrates(sut, lines);
var result = sut.Process(lines);
Console.WriteLine($"Part 1: {result}");

var sut2 = new Ship();
ShipLoader.LoadCrates(sut2, lines);
var result2 = sut2.WhenProcessCraneMover9001(lines);
Console.WriteLine($"Part 2: {result2}");
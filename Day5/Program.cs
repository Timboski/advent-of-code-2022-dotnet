using Day5;

var lines = File.ReadLines("day5-input.txt");
var sut = new CraneMover9000Ship();
ShipLoader.LoadCrates(sut, lines);
sut.MoveCrates(lines);
Console.WriteLine($"Part 1: {sut.State}");

var sut2 = new CraneMover9001Ship();
ShipLoader.LoadCrates(sut2, lines);
sut2.MoveCrates(lines);
Console.WriteLine($"Part 2: {sut2.State}");
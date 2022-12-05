using Day5;

var lines = File.ReadLines("day5-input.txt");
var sut = new Ship();
var result = sut.Process(lines);
Console.WriteLine(result);
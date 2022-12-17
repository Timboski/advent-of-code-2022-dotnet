using Day11;

var sut = new MonkeySimulation("day11-input.txt");

// Act
var monkeyBusiness = sut.FindMonkeyBusiness(20);
Console.WriteLine($"Part 1: {monkeyBusiness}");

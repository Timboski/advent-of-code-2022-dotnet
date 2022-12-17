using Day11;

var sut = new MonkeySimulation("day11-input.txt", true);
var monkeyBusiness = sut.FindMonkeyBusiness(20);
Console.WriteLine($"Part 1: {monkeyBusiness}");

var sut2 = new MonkeySimulation("day11-input.txt");
var monkeyBusiness2 = sut.FindMonkeyBusiness(10000);
Console.WriteLine($"Part 2: {monkeyBusiness2}");

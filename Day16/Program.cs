using Day16;

var sut = new VolcanoPathFinder("day16-input.txt");
var pressure = sut.MaximisePressure();
Console.WriteLine($"Part 1 {pressure}");

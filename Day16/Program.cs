using Day16;

var sut = new VolcanoPathFinder("day16-input.txt");
var pressure = sut.MaximisePressure();
Console.WriteLine($"Part 1 {pressure}");

var sut2 = new VolcanoPathFinder("day16-input.txt", Elephant.WithElephant);
var pressure2 = sut2.MaximisePressure();
Console.WriteLine($"Part 2 {pressure2}");

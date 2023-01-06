using Day17;

var height1 = Simulation.FindHeight("day17-input.txt", 2022);
Console.WriteLine($"Part 1: {height1}");

var height2 = Simulation.FindHeightWithRepeat("day17-input.txt", 1000000000000);
Console.WriteLine($"Part 2: {height2}");

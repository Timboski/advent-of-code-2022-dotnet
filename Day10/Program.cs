using Day10;

var signalStrength = new CPU().FindSignalStrength("day10-input.txt");
Console.WriteLine($"Part 1: {signalStrength}");

var render = new CPU().RenderScreen("day10-input.txt");
Console.WriteLine("Part 2:");
Console.WriteLine(render);

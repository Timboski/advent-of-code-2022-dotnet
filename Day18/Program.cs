using Day18;

var area = SurfaceAreaFinder.FindArea("day18-input.txt");
Console.WriteLine($"Part 1: {area}");

var externalArea = SurfaceAreaFinder.FindExternalArea("day18-input.txt");
Console.WriteLine($"Part 2: {externalArea}");
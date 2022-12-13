using Day9;

var sut = new RopeTracker();
sut.ParseFile("day9-input.txt");
Console.WriteLine($"Part 1: {sut.TailVisits}");

var origin = new EndPosition(0, 0);
var tenKnots = new TenKnots(origin);
var sut2 = new RopeTracker(tenKnots);
sut2.ParseFile("day9-input.txt");
Console.WriteLine($"Part 2: {sut2.TailVisits}");

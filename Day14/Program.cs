using Day14;
using System.Drawing;

var filename = "day14-input.txt";
var box = FileParser.FindBoundngBox(filename);
var paths = FileParser.ReadFile(filename);
var cave = new Cave(box, new Point(500, 0));
cave.AddPaths(paths);
var iterations = cave.AddSandUntilStable();

Console.WriteLine($"Part1 : {iterations}");
Console.WriteLine(cave.ToString());
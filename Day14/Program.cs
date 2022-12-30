using Day14;
using System.Drawing;

var filename = "day14-input.txt";
var box = FileParser.FindBoundngBox(filename);
var paths = FileParser.ReadFile(filename);
var cave = new Cave(box, new Point(500, 0));
cave.AddPaths(paths);

Console.WriteLine("Part1 : Initial map");
Console.WriteLine(cave.ToString());

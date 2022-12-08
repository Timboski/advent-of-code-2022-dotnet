using Day8;

var rows = File.ReadAllLines("day8-input.txt");
var numberOfTreesVisible = new TreePatch(rows).CountVisible();

Console.WriteLine($"Part 1: {numberOfTreesVisible}");

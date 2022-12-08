using Day8;

var rows = File.ReadAllLines("day8-input.txt");
var sut = new TreePatch(rows);

var numberOfTreesVisible = sut.CountVisible();
Console.WriteLine($"Part 1: {numberOfTreesVisible}");

var scenicScore = sut.GetMaxScenicScore();
Console.WriteLine($"Part 2: {scenicScore}");
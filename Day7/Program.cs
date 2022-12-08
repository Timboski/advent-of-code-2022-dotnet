using Day7;

var tree = new SystemDirectory();
var sut = new TerminalOutputDecoder(tree);
var lines = File.ReadAllLines("day7-input.txt");
foreach (var line in lines) sut.ProcessLine(line);
var result = tree.ListDirectories().Select(d => d.Size).Where(s => s <= 100000).Sum();
Console.WriteLine($"Part 1: {result}");

var max = 70000000 - 30000000;
var target = tree.Size - max;
var largeEnoughDirectories = tree.ListDirectories().Select(d => d.Size).Where(s => s >= target);
var bestMatch = largeEnoughDirectories.OrderDescending().Reverse().First();
Console.WriteLine($"Part 2: {bestMatch}");
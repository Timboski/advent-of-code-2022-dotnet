using Day7;

var tree = new SystemDirectory();
var sut = new TerminalOutputDecoder(tree);
var lines = File.ReadAllLines("day7-input.txt");
foreach (var line in lines) sut.ProcessLine(line);
var result = tree.ListDirectories().Select(d => d.Size).Where(s => s <= 100000).Sum();
Console.WriteLine(result);
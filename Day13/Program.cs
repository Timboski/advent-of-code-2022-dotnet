using Day13;

var score = CheckPairs.FromFile("day13-input.txt");
Console.WriteLine($"Part 1: {score}");

// Act
var key = DecoderKey.Find("day13-input.txt");
Console.WriteLine($"Part 2: {key}");
﻿using Day5;

var lines = File.ReadLines("day5-input.txt");
var sut = new Ship();
ShipLoader.LoadCrates(sut, lines);
sut.Process(lines);
Console.WriteLine($"Part 1: {sut.State}");

var sut2 = new Ship();
ShipLoader.LoadCrates(sut2, lines);
sut2.WhenProcessCraneMover9001(lines);
Console.WriteLine($"Part 2: {sut2.State}");
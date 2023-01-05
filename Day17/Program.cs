using Day17;

var shapeFactory = new ShapeFactory();
var jetDirectionFactory = new JetDirectionFactory("day17-input.txt");
var sut = new ChamberSimulation(shapeFactory, jetDirectionFactory);
sut.DropRocks(2022);
Console.WriteLine($"Part 1: {sut.Height}");

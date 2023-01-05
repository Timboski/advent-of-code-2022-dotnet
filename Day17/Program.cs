using Day17;

Console.WriteLine($"Part 1: {FindHeight(2022)}");
// Console.WriteLine($"Part 2: {FindHeight(1000000000000)}");

static long FindHeight(long numRocks)
{
    var shapeFactory = new ShapeFactory();
    var jetDirectionFactory = new JetDirectionFactory("day17-input.txt");
    var sut = new ChamberSimulation(shapeFactory, jetDirectionFactory);
    sut.DropRocks(numRocks);
    var height = sut.Height;
    return height;
}
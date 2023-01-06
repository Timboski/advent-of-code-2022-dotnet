namespace Day17;

public static class Simulation
{
    public static long FindHeight(string filename, long numRocks)
    {
        var shapeFactory = new ShapeFactory();
        var jetDirectionFactory = new JetDirectionFactory(filename);
        var sut = new ChamberSimulation(shapeFactory, jetDirectionFactory);
        sut.DropRocks(numRocks);
        var height = sut.Height;
        return height;
    }

    public static long FindHeightWithRepeat(string filename, long numRocks)
    {
        var shapeFactory = new ShapeFactory();
        var jetDirectionFactory = new JetDirectionFactory(filename);
        var sut = new ChamberSimulation(shapeFactory, jetDirectionFactory);
        (var start, var blocks, var lines) = sut.FindRepeatingPattern(numRocks);

        var repeatingSections = (numRocks - start) / blocks;
        var blocksInRepeats = repeatingSections * blocks;
        var linesInRepeats = repeatingSections * lines;
        var additionalBlocks = numRocks - blocksInRepeats;

        var height = FindHeight(filename, additionalBlocks);
        return height + linesInRepeats;
    }
}

using Day5;

namespace Day5Test;

public class ShipTest
{
    [Theory]
    [InlineData("    [D]    ", 2, 'D')]
    [InlineData("[N] [C]    ", 1, 'N')]
    [InlineData("[N] [C]    ", 2, 'C')]
    [InlineData("[Z] [M] [P]", 1, 'Z')]
    [InlineData("[Z] [M] [P]", 2, 'M')]
    [InlineData("[Z] [M] [P]", 3, 'P')]
    public void GivenCratePictureRow_WhenRead_AddsToCorrectStack(string line, int stackIndex, char crateMarker)
    {
        // Arrange
        var sut = new Ship();

        // Act
        ShipLoader.AddCrates(sut, line);

        // Assert
        Assert.Equal(crateMarker, sut.PeekTopCrateMarking(stackIndex));
    }

    [Fact]
    public void GivenExamplePicture_WhenRead_TopCratesAreCorrect()
    {
        // Arrange
        var picture = File.ReadLines("day5-example-input.txt")
            .TakeWhile(line => line.Length > 0);
   
        var sut = new Ship();

        // Act
        ShipLoader.AddCrates(sut, picture);

        // Assert
        Assert.Equal('N', sut.PeekTopCrateMarking(1));
        Assert.Equal('D', sut.PeekTopCrateMarking(2));
        Assert.Equal('P', sut.PeekTopCrateMarking(3));
    }

    [Fact]
    public void GivenExampleStacks_WhenPerformFirstMove_TopCratesAreCorrect()
    {
        // Arrange
        var sut = new Ship();
        var picture = File.ReadLines("day5-example-input.txt")
            .TakeWhile(line => line.Length > 0);
        ShipLoader.AddCrates(sut, picture);

        // Act
        sut.MoveCrates(1, 2, 1);

        // Assert
        Assert.Equal('D', sut.PeekTopCrateMarking(1));
        Assert.Equal('C', sut.PeekTopCrateMarking(2));
        Assert.Equal('P', sut.PeekTopCrateMarking(3));
    }

    [Fact]
    public void GivenExampleStacks_WhenPerformSecondMove_TopCratesAreCorrect()
    {
        // Arrange
        var sut = new Ship();
        var picture = File.ReadLines("day5-example-input.txt")
            .TakeWhile(line => line.Length > 0);
        ShipLoader.AddCrates(sut, picture);
        sut.MoveCrates(1, 2, 1);

        // Act
        sut.MoveCrates(3, 1, 3);

        // Assert
        Assert.Throws<InvalidOperationException>(() => sut.PeekTopCrateMarking(1));
        Assert.Equal('C', sut.PeekTopCrateMarking(2));
        Assert.Equal('Z', sut.PeekTopCrateMarking(3));
    }

    [Fact]
    public void GivenExampleStacks_WhenPerformThirdMove_TopCratesAreCorrect()
    {
        // Arrange
        var sut = new Ship();
        var picture = File.ReadLines("day5-example-input.txt")
            .TakeWhile(line => line.Length > 0);
        ShipLoader.AddCrates(sut, picture);
        sut.MoveCrates(1, 2, 1);
        sut.MoveCrates(3, 1, 3);

        // Act
        sut.MoveCrates(2, 2, 1);

        // Assert
        Assert.Equal('M', sut.PeekTopCrateMarking(1));
        Assert.Throws<InvalidOperationException>(() => sut.PeekTopCrateMarking(2));
        Assert.Equal('Z', sut.PeekTopCrateMarking(3));
    }

    [Fact]
    public void GivenExampleStacks_WhenPerformFourthMove_TopCratesAreCorrect()
    {
        // Arrange
        var sut = new Ship();
        var picture = File.ReadLines("day5-example-input.txt")
            .TakeWhile(line => line.Length > 0);
        ShipLoader.AddCrates(sut, picture);
        sut.MoveCrates(1, 2, 1);
        sut.MoveCrates(3, 1, 3);
        sut.MoveCrates(2, 2, 1);

        // Act
        sut.MoveCrates(1, 1, 2);

        // Assert
        Assert.Equal('C', sut.PeekTopCrateMarking(1));
        Assert.Equal('M', sut.PeekTopCrateMarking(2));
        Assert.Equal('Z', sut.PeekTopCrateMarking(3));
    }

    [Fact]
    public void GivenExampleStacks_WhenReadMoves_TopCratesAreCorrect()
    {
        // Arrange
        var sut = new Ship();
        var lines = File.ReadLines("day5-example-input.txt");
        var picture = lines.TakeWhile(line => line.Length > 0);
        ShipLoader.AddCrates(sut, picture);

        // Act
        sut.MoveCrates(lines);

        // Assert
        Assert.Equal('C', sut.PeekTopCrateMarking(1));
        Assert.Equal('M', sut.PeekTopCrateMarking(2));
        Assert.Equal('Z', sut.PeekTopCrateMarking(3));
    }

    [Fact]
    public void GivenExampleData_WhenProcess_ProducesCorrectMarkings()
    {
        // Arrange
        var sut = new Ship();
        var lines = File.ReadLines("day5-example-input.txt");
        ShipLoader.LoadCrates(sut, lines);

        // Act
        sut.Process(lines);

        // Assert
        Assert.Equal("CMZ", sut.State);
    }

    [Fact]
    public void GivenProblemInput_WhenProcess_ProducesCorrectMarkings()
    {
        // Arrange
        var sut = new Ship();
        var lines = File.ReadLines("day5-input.txt");
        ShipLoader.LoadCrates(sut, lines);

        // Act
        sut.Process(lines);

        // Assert
        Assert.Equal("FCVRLMVQP", sut.State);
    }

    [Fact]
    public void GivenExampleData_WhenProcessCraneMover9001_ProducesCorrectMarkings()
    {
        // Arrange
        var sut = new Ship();
        var lines = File.ReadLines("day5-example-input.txt");
        ShipLoader.LoadCrates(sut, lines);

        // Act
        sut.WhenProcessCraneMover9001(lines);

        // Assert
        Assert.Equal("MCD", sut.State);
    }

    [Fact]
    public void GivenProblemInput_WhenProcessCraneMover9001_ProducesCorrectMarkings()
    {
        // Arrange
        var sut = new Ship();
        var lines = File.ReadLines("day5-input.txt");
        ShipLoader.LoadCrates(sut, lines);

        // Act
        sut.WhenProcessCraneMover9001(lines);

        // Assert
        Assert.Equal("RWLWGJGFD", sut.State);
    }
}
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
        sut.AddCrates(line);

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
        sut.AddCrates(picture);

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
        sut.AddCrates(picture);

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
        sut.AddCrates(picture);
        sut.MoveCrates(1, 2, 1);

        // Act
        sut.MoveCrates(3, 1, 3);

        // Assert
        Assert.Throws<InvalidOperationException>(() => sut.PeekTopCrateMarking(1));
        Assert.Equal('C', sut.PeekTopCrateMarking(2));
        Assert.Equal('Z', sut.PeekTopCrateMarking(3));
    }
}
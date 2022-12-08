namespace Day7Test;

public class TerminalOutputDecoderTest
{
    [Fact]
    public void GivenEmptyListFileOutput_WhenProcessLine_TreeIsZeroSize()
    {
        // Arrange
        var tree = new SystemDirectory();
        var sut = new TerminalOutputDecoder(tree);

        // Act
        sut.ProcessLine("$ ls");

        // Assert
        Assert.Equal(0, tree.Size);
    }

    [Fact]
    public void GivenChangeDirectory_WhenProcessLine_SubDirectoryExists()
    {
        // Arrange
        var tree = new SystemDirectory();
        var sut = new TerminalOutputDecoder(tree);

        // Act
        sut.ProcessLine("$ cd a");

        // Assert
        Assert.True(tree.IsChild("a"));
    }

    [Fact]
    public void GivenChangeDirectory_WhenProcessLine_CallsMoveIn()
    {
        // Arrange
        var tree = new Mock<ISystemDirectory>();
        var sut = new TerminalOutputDecoder(tree.Object);

        // Act
        sut.ProcessLine("$ cd a");

        // Assert
        tree.Verify(t => t.MoveIn("a"));
    }

    [Fact]
    public void GivenDirectoryTraversals_WhenProcessLines_SubDirectoriesExist()
    {
        // Arrange
        var tree = new SystemDirectory();
        var sut = new TerminalOutputDecoder(tree);

        // Act
        sut.ProcessLine("$ cd a");
        sut.ProcessLine("$ cd b");
        sut.ProcessLine("$ cd ..");
        sut.ProcessLine("$ cd d");
        sut.ProcessLine("$ cd /");
        sut.ProcessLine("$ cd c");

        // Assert
        Assert.True(tree.IsChild("a"));
        Assert.True(tree.IsChild("c"));
        Assert.True(tree.MoveIn("a").IsChild("b"));
        Assert.True(tree.MoveIn("a").IsChild("d"));
    }

    [Fact]
    public void GivenChangeDirectoryToParent_WhenProcessLine_CallsMoveOut()
    {
        // Arrange
        var tree = new Mock<ISystemDirectory>();
        var sut = new TerminalOutputDecoder(tree.Object);

        // Act
        sut.ProcessLine("$ cd ..");

        // Assert
        tree.Verify(t => t.MoveOut());
    }

    [Fact]
    public void GivenFileDescription_WhenProcessLine_CallsAddFile()
    {
        // Arrange
        var tree = new Mock<ISystemDirectory>();
        var sut = new TerminalOutputDecoder(tree.Object);

        // Act
        sut.ProcessLine("14848514 b.txt");

        // Assert
        tree.Verify(t => t.AddFile(14848514));
    }

    [Fact]
    public void GivenExampleTerminalOutput_WhenSumDirsBelowThresholdSize_CreatesExpectedSize()
    {
        // Arrange
        var tree = new SystemDirectory();
        var sut = new TerminalOutputDecoder(tree);
        var lines = File.ReadAllLines("day7-example-input.txt");
        foreach (var line in lines) sut.ProcessLine(line);

        // Act
        var result = tree.ListDirectories().Select(d => d.Size).Where(s => s <= 100000).Sum();

        // Assert
        Assert.Equal(95437, result);
    }

    [Fact]
    public void GivenProblemInput_WhenSumDirsBelowThresholdSize_CreatesExpectedSize()
    {
        // Arrange
        var tree = new SystemDirectory();
        var sut = new TerminalOutputDecoder(tree);
        var lines = File.ReadAllLines("day7-input.txt");
        foreach (var line in lines) sut.ProcessLine(line);

        // Act
        var result = tree.ListDirectories().Select(d => d.Size).Where(s => s <= 100000).Sum();

        // Assert
        Assert.Equal(1443806, result);
    }

    [Fact]
    public void GivenExampleTerminalOutput_WhenFindSmallestSuitableDirectory_CreatesExpectedSize()
    {
        // Arrange
        var tree = new SystemDirectory();
        var sut = new TerminalOutputDecoder(tree);
        var lines = File.ReadAllLines("day7-example-input.txt");
        foreach (var line in lines) sut.ProcessLine(line);

        // Act
        var max = 70000000 - 30000000;
        var target = tree.Size - max;
        var largeEnoughDirectories = tree.ListDirectories().Select(d => d.Size).Where(s => s >= target);
        var bestMatch = largeEnoughDirectories.OrderDescending().Reverse().First();

        // Assert
        Assert.Equal(24933642, bestMatch);
    }
}
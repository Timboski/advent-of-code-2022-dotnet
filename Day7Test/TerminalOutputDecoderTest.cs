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
        sut.ProcessLine("$ cd /");
        sut.ProcessLine("$ cd c");

        // Assert
        Assert.True(tree.IsChild("a"));
        Assert.True(tree.IsChild("c"));
        Assert.True(tree.MoveIn("a").IsChild("b"));
    }
}
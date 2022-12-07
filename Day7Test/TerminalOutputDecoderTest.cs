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
}
namespace Day7Test;

public class TerminalOutputDecoderTest
{
    [Fact]
    public void GivenEmptyListFileOutput_WhenProcessLine_TreeIsZeroSize()
    {
        // Arrange
        var sut = new TerminalOutputDecoder();

        // Act
        sut.ProcessLine("$ ls");

        // Assert
        Assert.Equal(0, sut.Tree.Size);
    }

    [Fact]
    public void GivenChangeDirectory_WhenProcessLine_SubDirectoryExists()
    {
        // Arrange
        var sut = new TerminalOutputDecoder();

        // Act
        sut.ProcessLine("$ cd a");

        // Assert
        Assert.Equal(0, sut.Tree.Size);
    }
}
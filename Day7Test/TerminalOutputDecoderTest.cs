namespace Day7Test;

public class TerminalOutputDecoderTest
{
    [Fact]
    public void GivenEmptyListFileOutput_WhenBuildTree_IsZeroSize()
    {
        // Arrange
        var sut = new TerminalOutputDecoder();

        // Act
        sut.ProcessLine("$ ls");

        // Assert
        Assert.Equal(0, sut.Tree.Size);
    }
}
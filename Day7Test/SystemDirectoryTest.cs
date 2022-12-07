namespace Day7Test;

public class SystemDirectoryTest
{
    [Fact]
    public void GivenDirectory_WhenAddFiles_ComputesSize()
    {
        // Arrange
        var sut = new SystemDirectory();

        // Act
        sut.AddFile(10);
        sut.AddFile(20);
        sut.AddFile(30);
        sut.AddFile(6);

        // Assert
        Assert.Equal(66, sut.Size);
    }

    [Fact]
    public void GivenDirectory_WhenMoveToNonExistantSubDirectory_ThrowsException()
    {
        // Arrange
        var sut = new SystemDirectory();

        // Act, Assert
        Assert.Throws<InvalidOperationException>(() => sut.MoveIn("test"));
    }

    [Fact]
    public void GivenDirectory_WhenMoveToNonExistantParentDirectory_ThrowsException()
    {
        // Arrange
        var sut = new SystemDirectory();

        // Act, Assert
        Assert.Throws<InvalidOperationException>(sut.MoveOut);
    }

    [Fact]
    public void GivenDirectory_WhenMoveToSubDirectory_ReturnsSubDirectory()
    {
        // Arrange
        var sut = new SystemDirectory();
        var testDir = sut.AddDirectory("test");

        // Act
        var subDirectory = sut.MoveIn("test");

        //Assert
        Assert.Same(testDir, subDirectory);
    }

    [Fact]
    public void GivenDirectory_WhenMoveOut_ReturnsParentDirectory()
    {
        // Arrange
        var parent = new SystemDirectory();
        parent.AddDirectory("test");
        var sut = parent.MoveIn("test");

        // Act
        var newDirectory = sut.MoveOut();

        //Assert
        Assert.Same(parent, newDirectory);
    }
}
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
    public void GivenDirectory_WhenMoveToNonExistantParentDirectory_ThrowsException()
    {
        // Arrange
        var sut = new SystemDirectory();

        // Act, Assert
        Assert.Throws<InvalidOperationException>(sut.MoveOut);
    }

    [Fact]
    public void GivenDirectory_WhenMoveOut_ReturnsParentDirectory()
    {
        // Arrange
        var parent = new SystemDirectory();
        var sut = parent.MoveIn("test");

        // Act
        var newDirectory = sut.MoveOut();

        //Assert
        Assert.Same(parent, newDirectory);
    }

    [Fact]
    public void GivenEmptyDirectory_WhenCheckChild_ReturnsFalse()
    {
        // Arrange
        var sut = new SystemDirectory();

        // Act
        var test = sut.IsChild("test");

        //Assert
        Assert.False(test);
    }

    [Fact]
    public void GivenDirectory_WhenMoveToSubDirectory_CreatesSubDirectory()
    {
        // Arrange
        var sut = new SystemDirectory();

        // Act
        sut.MoveIn("test");

        //Assert
        Assert.True(sut.IsChild("test"));
    }

    [Fact]
    public void GivenDirectoryWithSubDirectory_WhenFindSize_ReturnsTotalSize()
    {
        // Arrange
        var sut = new SystemDirectory();
        sut.AddFile(10);
        sut.AddFile(12);
        var testDir = sut.MoveIn("test");
        testDir.AddFile(30);
        testDir.AddFile(66);

        // Act
        var totalSize = sut.Size;

        //Assert
        Assert.Equal(118, totalSize);
    }
}
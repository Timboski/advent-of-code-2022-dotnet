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
}
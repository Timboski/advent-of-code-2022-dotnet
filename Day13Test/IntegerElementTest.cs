namespace Day13Test;

public class IntegerElementTest
{
    [Fact]
    public void GivenIntegerElements_WhenCheckIsBeforeHigherIntegerElement_ReturnsTrue()
    {
        // Arrange
        var sut = new IntegerElement(4);
        var higher = new IntegerElement(8);

        // Act
        var correctOrder = sut.IsBefore(higher);

        // Assert
        Assert.True(correctOrder);
    }

    [Fact]
    public void GivenIntegerElements_WhenCheckIsBeforeLowerIntegerElement_ReturnsFalse()
    {
        // Arrange
        var sut = new IntegerElement(8);
        var lower = new IntegerElement(4);

        // Act
        var correctOrder = sut.IsBefore(lower);

        // Assert
        Assert.False(correctOrder);
    }

    [Fact]
    public void GivenIntegerElements_WhenCheckIsBeforeEqualIntegerElement_ReturnsTrue()
    {
        // Arrange
        var sut = new IntegerElement(5);
        var equalValue = new IntegerElement(5);

        // Act
        var correctOrder = sut.IsBefore(equalValue);

        // Assert
        Assert.True(correctOrder);
    }
}
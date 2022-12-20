namespace Day13Test;

public class IntegerElementTest
{
    [Fact]
    public void GivenIntegerElement_WhenCheckOrderWithHigherIntegerElement_ReturnsOrderCorrect()
    {
        // Arrange
        var sut = new IntegerElement(4);
        var higher = new IntegerElement(8);

        // Act
        var res = sut.CheckOrder(higher);

        // Assert
        Assert.Equal(Order.Correct, res);
    }

    [Fact]
    public void GivenIntegerElement_WhenCheckOrderWithLowerIntegerElement_ReturnsOrderWrong()
    {
        // Arrange
        var sut = new IntegerElement(8);
        var lower = new IntegerElement(4);

        // Act
        var res = sut.CheckOrder(lower);

        // Assert
        Assert.Equal(Order.Wrong, res);
    }

    [Fact]
    public void GivenIntegerElement_WhenCheckOrderWithEqualIntegerElement_ReturnsOrderEqual()
    {
        // Arrange
        var sut = new IntegerElement(5);
        var equalValue = new IntegerElement(5);

        // Act
        var res = sut.CheckOrder(equalValue);

        // Assert
        Assert.Equal(Order.Equal, res);
    }
}
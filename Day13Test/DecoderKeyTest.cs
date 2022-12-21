namespace Day13Test;

public class DecoderKeyTest
{
    [Theory]
    [InlineData("day13-example-input.txt", 140)]
    [InlineData("day13-input.txt", 22464)]
    public void GivenDistressSignal_WhenFindDecoderKey_ReturnsCorrectValue(string filename, int expectedKey)
    {
        // Arrange
        // Act
        var key = DecoderKey.Find(filename);

        // Assert
        Assert.Equal(expectedKey, key);
    }
}
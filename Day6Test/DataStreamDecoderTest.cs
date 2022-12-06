using Day6;

namespace Day6Test;

public class DataStreamDecoderTest
{
    [Theory]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 6)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
    public void GivenExampleDataStreams_WhenFindPacketStart_ReturnsCorrectResponse(string data, int expectedPacketStart)
    {
        // Arrange
        // Act
        var packetStart = DataStreamDecoder.FindStartOfPacket(data);

        // Assert
        Assert.Equal(expectedPacketStart, packetStart);
    }

    [Fact]
    public void GivenDataInput_WhenFindPacketStart_ReturnsCorrectIndex()
    {
        // Arrange
        var data = File.ReadAllText("day6-input.txt");

        // Act
        var packetStart = DataStreamDecoder.FindStartOfPacket(data);

        // Assert
        Assert.Equal(1140, packetStart);
    }

    [Theory]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 23)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
    public void GivenExampleDataStreams_WhenFindMessageStart_ReturnsCorrectResponse(string data, int expectedPacketStart)
    {
        // Arrange
        // Act
        var messageStart = DataStreamDecoder.FindStartOfMessage(data);

        // Assert
        Assert.Equal(expectedPacketStart, messageStart);
    }

    [Fact]
    public void GivenDataInput_WhenFindMessageStart_ReturnsCorrectIndex()
    {
        // Arrange
        var data = File.ReadAllText("day6-input.txt");

        // Act
        var messageStart = DataStreamDecoder.FindStartOfMessage(data);

        // Assert
        Assert.Equal(3495, messageStart);
    }
}
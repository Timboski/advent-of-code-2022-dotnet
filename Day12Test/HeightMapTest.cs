namespace Day12Test;

public class HeightMapTest
{
    [Fact]
    public void GivenMapDataWithNoStart_WhenCreateHeightMap_ThrowsException()
    {
        // Arrange
        var map = GenerateMap("""
            aaaa
            aaaa
            aaaa
            """);

        // Act, Assert
        Assert.Throws<NoStartException>(() => new HeightMap(map));
    }

    [Fact]
    public void GivenMapDataWithStartAndNoEnd_WhenCreateHeightMap_FlaggedAsComplete()
    {
        // Arrange
        var map = GenerateMap("""
            aaaa
            aSaa
            aaaa
            """);

        // Act
        var sut = new HeightMap(map);

        // Assert
        Assert.True(sut.IsComplete);
    }

    [Fact]
    public void GivenMapDataWithStartAndEnd_WhenCreateHeightMap_FlaggedAsNotComplete()
    {
        // Arrange
        var map = GenerateMap("""
            aaaa
            aSaa
            aaEa
            """);

        // Act
        var sut = new HeightMap(map);

        // Assert
        Assert.False(sut.IsComplete);
    }

    private static List<string> GenerateMap(string mapData) 
        => mapData.Split(Environment.NewLine).ToList();
}
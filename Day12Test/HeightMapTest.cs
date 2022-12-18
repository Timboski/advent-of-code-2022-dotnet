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

    private static List<string> GenerateMap(string mapData) 
        => mapData.Split(Environment.NewLine).ToList();
}
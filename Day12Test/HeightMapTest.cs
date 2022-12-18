namespace Day12Test;

public class HeightMapTest
{
    [Fact]
    public void GivenMapDataWithNoStart_WhenCreateHeightMap_ThrowsException()
    {
        // Arrange
        var map = """
            aaaa
            aaaa
            aaaa
            """;

        // Act, Assert
        Assert.Throws<NoStartException>(() => new HeightMap(map));
    }

    [Fact]
    public void GivenMapDataWithStartAndNoEnd_WhenCreateHeightMap_FlaggedAsComplete()
    {
        // Arrange
        var map = """
            aaaa
            aSaa
            aaaa
            """;

        // Act
        var sut = new HeightMap(map);

        // Assert
        Assert.True(sut.IsComplete);
    }

    [Fact]
    public void GivenMapDataWithStartAndEnd_WhenCreateHeightMap_FlaggedAsNotComplete()
    {
        // Arrange
        var map = """
            aaaa
            aSaa
            aaEa
            """;

        // Act
        var sut = new HeightMap(map);

        // Assert
        Assert.False(sut.IsComplete);
    }

    [Fact]
    public void GivenHeightMapWithAllDirectionsFree_WhenFindSteps_ReturnsFourNewMaps()
    {
        // Arrange
        var sut = new HeightMap("""
            aaaa
            aSaa
            aaaE
            """);

        var up = """
            aSaa
            a#aa
            aaaE
            """;

        var down = """
            aaaa
            a#aa
            aSaE
            """;

        var left = """
            aaaa
            S#aa
            aaaE
            """;

        var right = """
            aaaa
            a#Sa
            aaaE
            """;

        var expectedMaps = new[] { up, down, left, right };

        // Act
        var nextSteps = sut.FindSteps();

        // Assert
        Assert.Equal(expectedMaps, nextSteps.Select(a => a.ToString()));
    }
}
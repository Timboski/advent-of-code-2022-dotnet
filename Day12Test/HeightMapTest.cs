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

    [Fact]
    public void GivenHeightMapWithStartOnTop_WhenFindSteps_ReturnsThreeNewMaps()
    {
        // Arrange
        var sut = new HeightMap("""
            aSaa
            aaaE
            """);

        var down = """
            a#aa
            aSaE
            """;

        var left = """
            S#aa
            aaaE
            """;

        var right = """
            a#Sa
            aaaE
            """;

        var expectedMaps = new[] { down, left, right };

        // Act
        var nextSteps = sut.FindSteps();

        // Assert
        Assert.Equal(expectedMaps, nextSteps.Select(a => a.ToString()));
    }

    [Fact]
    public void GivenHeightMapWithStartOnBottom_WhenFindSteps_ReturnsThreeNewMaps()
    {
        // Arrange
        var sut = new HeightMap("""
            aaaa
            aSaa
            """);

        var up = """
            aSaa
            a#aa
            """;

        var left = """
            aaaa
            S#aa
            """;

        var right = """
            aaaa
            a#Sa
            """;

        var expectedMaps = new[] { up, left, right };

        // Act
        var nextSteps = sut.FindSteps();

        // Assert
        Assert.Equal(expectedMaps, nextSteps.Select(a => a.ToString()));
    }

    [Fact]
    public void GivenHeightMapWithStartOnLef_WhenFindSteps_ReturnsThreeNewMaps()
    {
        // Arrange
        var sut = new HeightMap("""
            aaa
            Saa
            aaE
            """);

        var up = """
            Saa
            #aa
            aaE
            """;

        var down = """
            aaa
            #aa
            SaE
            """;

        var right = """
            aaa
            #Sa
            aaE
            """;

        var expectedMaps = new[] { up, down, right };

        // Act
        var nextSteps = sut.FindSteps();

        // Assert
        Assert.Equal(expectedMaps, nextSteps.Select(a => a.ToString()));
    }

    [Fact]
    public void GivenHeightMapWithStartOnRight_WhenFindSteps_ReturnsThreeNewMaps()
    {
        // Arrange
        var sut = new HeightMap("""
            aaaa
            aaaS
            aaaE
            """);

        var up = """
            aaaS
            aaa#
            aaaE
            """;

        var down = """
            aaaa
            aaa#
            aaaS
            """;

        var left = """
            aaaa
            aaS#
            aaaE
            """;

        var expectedMaps = new[] { up, down, left };

        // Act
        var nextSteps = sut.FindSteps();

        // Assert
        Assert.Equal(expectedMaps, nextSteps.Select(a => a.ToString()));
    }

    [Fact]
    public void GivenHeightMapWithStartInCorner_WhenFindSteps_ReturnsTwoNewMaps()
    {
        // Arrange
        var sut = new HeightMap("""
            Saaa
            aaaa
            aaaE
            """);

        var down = """
            #aaa
            Saaa
            aaaE
            """;

        var right = """
            #Saa
            aaaa
            aaaE
            """;

        var expectedMaps = new[] { down, right };

        // Act
        var nextSteps = sut.FindSteps();

        // Assert
        Assert.Equal(expectedMaps, nextSteps.Select(a => a.ToString()));
    }

    [Fact]
    public void GivenHeightMapWithThreeAlreadyVisitedSteps_WhenFindSteps_ReturnsRemainingOne()
    {
        // Arrange
        var sut = new HeightMap("""
            a#aa
            #S#a
            aaaE
            """);

        var down = """
            a#aa
            ###a
            aSaE
            """;

        var expectedMaps = new[] { down };

        // Act
        var nextSteps = sut.FindSteps();

        // Assert
        Assert.Equal(expectedMaps, nextSteps.Select(a => a.ToString()));
    }
}
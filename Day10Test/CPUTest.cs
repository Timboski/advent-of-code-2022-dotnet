namespace Day10Test;

public class CPUTest
{
    [Fact]
    public void GivenCpuInGivenState_WhenRunNoop_Returns1CycleOfSameState()
    {
        // Arrange
        var sut = new CPU(17);

        // Act
        var seq = sut.Noop();

        // Assert
        Assert.Single(seq);
        Assert.Equal(17, seq.First());
    }

    [Fact]
    public void GivenCpuInGivenState_WhenRunNoop_CpuStateIsUnchanged()
    {
        // Arrange
        var sut = new CPU(17);

        // Act
        _ = sut.Noop();

        // Assert
        Assert.Equal(17, sut.State);
    }

    [Fact]
    public void GivenCpuInGivenState_WhenRunAddx_Returns2CyclesOfSameState()
    {
        // Arrange
        var sut = new CPU(17);

        // Act
        var seq = sut.Addx(15);

        // Assert
        Assert.Equal(2, seq.Count());
        Assert.True(seq.All(a => a == 17));
    }

    [Fact]
    public void GivenCpuInGivenState_WhenRunAddx_CpuStateChangesByValueSpecified()
    {
        // Arrange
        var sut = new CPU(17);

        // Act
        _ = sut.Addx(15);

        // Assert
        Assert.Equal(32, sut.State);
    }

    [Fact]
    public void GivenCpuInGivenState_WhenParseNoop_RunsNoop()
    {
        // Arrange
        var sut = new CPU(17);

        // Act
        var seq = sut.Parse("noop");

        // Assert
        Assert.Equal(17, sut.State);
        Assert.Single(seq);
        Assert.Equal(17, seq.First());
    }

    [Fact]
    public void GivenCpuInGivenState_WhenParseAddx_RunsAddx()
    {
        // Arrange
        var sut = new CPU(17);

        // Act
        var seq = sut.Parse("addx 15");

        // Assert
        Assert.Equal(32, sut.State);
        Assert.Equal(2, seq.Count());
        Assert.True(seq.All(a => a == 17));
    }

    [Fact]
    public void GivenExampleInput_WhenRunProgram_ReturnedSequenceContainsExpectedElements()
    {
        // Arrange
        var sut = new CPU();

        // Act
        var seq = sut.RunProgram("day10-example-input.txt");

        // Assert
        Assert.Equal(21, seq[20]);
        Assert.Equal(19, seq[60]);
        Assert.Equal(18, seq[100]);
        Assert.Equal(21, seq[140]);
        Assert.Equal(16, seq[180]);
        Assert.Equal(18, seq[220]);
    }



    [Theory]
    [InlineData("day10-example-input.txt", 13140)]
    public void GivenInputData_WhenFindSignalStrength_ReturnsExpectedResult(string filename, int expectedSignalStrength)
    {
        // Arrange
        var sut = new CPU();

        // Act
        var signalStrength = sut.FindSignalStrength(filename);

        // Assert
        Assert.Equal(expectedSignalStrength, signalStrength);
    }
}
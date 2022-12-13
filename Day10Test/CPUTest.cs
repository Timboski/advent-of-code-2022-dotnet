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
        var seq = sut.Noop();

        // Assert
        Assert.Equal(17, sut.State);
    }
}
using System.Numerics;

namespace Day11;

public class WorryLevelWithRelief : IWorryLevel
{
    public WorryLevelWithRelief(int level) => Level = level;

    public BigInteger Level { get; private set; }

    public bool IsDivisibleBy(int divisor) => Level.IsDivisibleBy(divisor);

    public void Add(int value) => Level += value;

    public void Multiply(int value) => Level *= value;

    public void Square() => Level *= Level;

    public void ComputeRelief() => Level /= 3;
}

using System.Numerics;

namespace Day11
{
    public interface IWorryLevel
    {
        BigInteger Level { get; }

        void Add(int value);
        void ComputeRelief();
        bool IsDivisibleBy(int divisor);
        void Multiply(int value);
        void Square();
    }
}
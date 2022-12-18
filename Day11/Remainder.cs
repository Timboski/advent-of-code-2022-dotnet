namespace Day11;

public class Remainder
{
	private readonly int _divisor;
	private int _remainder;

	public Remainder(int number, int divisor)
	{
		_divisor = divisor;
        SetRemainder(number);
	}

    public bool IsDivisible => _remainder == 0;

    public void Add(int value) => SetRemainder(_remainder + value);

    public void Multiply(int value) => SetRemainder(_remainder * value);

    public void Square() => SetRemainder(_remainder * _remainder);

    private void SetRemainder(int number) 
		=> _remainder = checked(number % _divisor);
}

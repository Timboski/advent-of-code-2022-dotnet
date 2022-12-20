namespace Day13;

public class IntegerElement
{
	private readonly int _value;

    public IntegerElement(int value) => _value = value;

    public bool IsBefore(IntegerElement other) 
        => _value < other._value;
}

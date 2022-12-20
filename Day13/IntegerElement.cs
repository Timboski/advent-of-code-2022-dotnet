namespace Day13;

public class IntegerElement
{
	private readonly int _value;

    public IntegerElement(int value) => _value = value;

    public Order CheckOrder(IntegerElement other)
    {
        if (_value == other._value) return Order.Equal;
        if (_value > other._value) return Order.Wrong;
        return Order.Correct;
    }
}

namespace Day13;

public class IntegerElement : IElement
{
	private readonly int _value;

    public IntegerElement(int value) => _value = value;

    public Order CheckOrder(IElement other)
    {
        if (other.GetType() == typeof(IntegerElement))
        {
            var otherValue = ((IntegerElement)other)._value;
            if (_value == otherValue) return Order.Equal;
            if (_value > otherValue) return Order.Wrong;
            return Order.Correct;
        }

        throw new NotImplementedException("Only support same type");
    }
}

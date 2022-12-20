namespace Day13;

public class ArrayElement
{
	private readonly List<IntegerElement> _elements;

    public ArrayElement(string arrayDescription) 
        => _elements = arrayDescription
                        .Trim('[', ']')
                        .Split(',')
                        .Select(int.Parse)
                        .Select(a => new IntegerElement(a))
                        .ToList();

    public Order CheckOrder(ArrayElement other)
    {
        for (int i = 0; i < _elements.Count; ++i) 
        {
            Order order = _elements[i].CheckOrder(other._elements[i]);
            if (order != Order.Equal) return order;
        }

        if (other._elements.Count > _elements.Count) return Order.Correct;

        return Order.Equal;
    }
}

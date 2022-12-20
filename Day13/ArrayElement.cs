using System.Linq;

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
        var smallestArraySize = Math.Min(_elements.Count, other._elements.Count);
        for (int i = 0; i < smallestArraySize; ++i) 
        {
            Order order = _elements[i].CheckOrder(other._elements[i]);
            if (order != Order.Equal) return order;
        }

        if (other._elements.Count > _elements.Count) return Order.Correct;
        if (other._elements.Count < _elements.Count) return Order.Wrong;

        return Order.Equal;
    }
}

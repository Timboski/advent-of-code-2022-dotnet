using System.Linq;

namespace Day13;

public class ArrayElement : IElement
{
    private readonly List<IElement> _elements;

    public ArrayElement(string arrayDescription)
        => _elements = arrayDescription
                        .Trim('[', ']')
                        .Split(',')
                        .Select(CreateElement)
                        .ToList();

    private IElement CreateElement(string description)
    {
        // Check if it is an integer
        if (int.TryParse(description, out int result))
            return new IntegerElement(result);

        // Must be a nested array
        return new ArrayElement(description);
    }

    public Order CheckOrder(IElement other)
    {
        if (other.GetType() == typeof(ArrayElement))
        {
            var otherElements = ((ArrayElement)other)._elements;
            var smallestArraySize = Math.Min(_elements.Count, otherElements.Count);
            for (int i = 0; i < smallestArraySize; ++i)
            {
                Order order = _elements[i].CheckOrder(otherElements[i]);
                if (order != Order.Equal) return order;
            }

            if (otherElements.Count > _elements.Count) return Order.Correct;
            if (otherElements.Count < _elements.Count) return Order.Wrong;

            return Order.Equal;
        }

        throw new NotImplementedException("Only support same type");
    }
}

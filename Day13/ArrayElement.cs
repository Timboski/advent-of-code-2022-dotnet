using System.Text;

namespace Day13;

public class ArrayElement : IElement
{
    private readonly List<IElement> _elements = new();

    public ArrayElement(string arrayDescription)
        : this(StartStream(arrayDescription))
    {
    }

    private ArrayElement(CharEnumerator descriptionStream)
    {
        CheckAndSkipChar(descriptionStream, '[');
        while (true)
        {
            if (descriptionStream.Current == ',') 
                descriptionStream.MoveNext();

            var curr = descriptionStream.Current;
            if (curr == ']') break;

            _elements.Add(
                curr == '[' ?
                new ArrayElement(descriptionStream) :
                new IntegerElement(ReadInteger(descriptionStream))
             );
        }

        CheckAndSkipChar(descriptionStream, ']');
    }

    private static CharEnumerator StartStream(string arrayDescription)
    {
        var descriptionStream = arrayDescription.GetEnumerator();
        descriptionStream.MoveNext();
        return descriptionStream;
    }

    private static void CheckAndSkipChar(CharEnumerator ds, char expectedChar)
    {
        if (ds.Current != expectedChar)
            throw new InvalidOperationException("Array start expected");
        ds.MoveNext();
    }

    private static int ReadInteger(CharEnumerator ds)
    {
        var sb = new StringBuilder();
        while (char.IsDigit(ds.Current))
        {
            sb.Append(ds.Current);
            ds.MoveNext();
        }
        return int.Parse(sb.ToString());
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

        // Other is an integer - promote it to an array
        return CheckOrder(((IntegerElement)other).PromoteToArray());
    }
}

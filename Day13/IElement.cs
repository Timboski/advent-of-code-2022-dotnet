namespace Day13
{
    public interface IElement
    {
        Order CheckOrder(IElement other);
    }
}
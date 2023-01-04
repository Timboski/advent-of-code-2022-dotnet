namespace Day17;

public class ShapeFactory
{
    public HorizontalShape Create(int bottomPosition) 
        => new HorizontalShape(bottomPosition);
}

namespace Day17;

public class ShapeFactory
{
    private int _shapeNumber = 0;
    private const int NumShapes = 2;

    public IRockShape Create(int bottomPosition)
        => (_shapeNumber++ % NumShapes) switch
                {
                    0 => new HorizontalShape(bottomPosition),
                    1 => new PlusShape(bottomPosition),
                    _ => throw new InvalidOperationException()
                };
}

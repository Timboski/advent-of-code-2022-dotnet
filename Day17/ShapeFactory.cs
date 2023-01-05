namespace Day17;

public class ShapeFactory
{
    private int _shapeNumber = 0;
    private const int NumShapes = 3;

    public IRockShape Create(int bottomPosition)
        => (_shapeNumber++ % NumShapes) switch
                {
                    0 => new HorizontalShape(bottomPosition),
                    1 => new PlusShape(bottomPosition),
                    2 => new AngleShape(bottomPosition),
                    _ => throw new InvalidOperationException()
                };
}

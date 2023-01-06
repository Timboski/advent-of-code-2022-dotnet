namespace Day17;

public class ShapeFactory
{
    private int _shapeNumber = 0;

    public IRockShape Create(long bottomPosition)
        => _shapeNumber++ switch
                {
                    0 => new HorizontalShape(bottomPosition),
                    1 => new PlusShape(bottomPosition),
                    2 => new AngleShape(bottomPosition),
                    3 => new VerticalShape(bottomPosition),
                    4 => new SquareShape(bottomPosition),
                    _ => Restart(bottomPosition)
                };

    private IRockShape Restart(long bottomPosition)
    {
        _shapeNumber = 0;
        return Create(bottomPosition);
    }
}

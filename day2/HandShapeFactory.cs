namespace day2;

public static class HandShapeFactory
{
    public static HandShape Create(this HandShape.Shape shape)
    {
        switch (shape)
        {
            case HandShape.Shape.Rock: return new Rock();
            case HandShape.Shape.Paper: return new Paper();
            case HandShape.Shape.Scissors: return new Scissors();
        }
        throw new ArgumentOutOfRangeException(nameof(shape));
    }
}

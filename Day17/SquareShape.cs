namespace Day17;

public class SquareShape : ShapeBase
{
    public SquareShape(int bottomPosition) : base(bottomPosition)
    {
    }

    public override int Height => 2;

    public override string GetLine(int pos, string background, char rockPixel = '@')
    {
        // Two pixels on both lines
        if (pos >= Bottom && pos < Top)
            return SetPixels(background, _left, 2, rockPixel);

        // Not in shape
        return background;
    }

    public override bool IsCollision(int pos, IEnumerable<string> background) 
        => background
            .Select(line => CheckCollisionOnLine(line, pos, 2))
            .Any(c => c);  
}

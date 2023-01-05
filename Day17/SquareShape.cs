namespace Day17;

public class SquareShape : ShapeBase
{
    public SquareShape(long bottomPosition) : base(bottomPosition)
    {
    }

    public override int Height => 2;

    public override string GetLine(long vPos, string background, char rockPixel = '@')
    {
        // Two pixels on both lines
        if (vPos >= Bottom && vPos < Top)
            return SetPixels(background, _left, 2, rockPixel);

        // Not in shape
        return background;
    }

    public override bool IsCollision(int hPos, IEnumerable<string> background) 
        => background
            .Select(line => CheckCollisionOnLine(line, hPos, 2))
            .Any(c => c);  
}

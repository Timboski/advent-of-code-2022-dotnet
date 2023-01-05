namespace Day17;

public class VerticalShape : ShapeBase
{
    public VerticalShape(long bottomPosition) : base(bottomPosition)
    {
    }

    public override int Height => 4;

    public override string GetLine(long vPos, string background, char rockPixel = '@')
    {
        // Single pixel on all 4 lines
        if (vPos >= Bottom && vPos < Top)
            return SetPixels(background, _left, 1, rockPixel);

        // Not in shape
        return background;
    }

    public override bool IsCollision(int hPos, IEnumerable<string> background) 
        => background
            .Select(line => CheckCollisionOnLine(line, hPos, 1))
            .Any(c => c);  
}

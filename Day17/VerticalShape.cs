namespace Day17;

public class VerticalShape : ShapeBase
{
    public VerticalShape(int bottomPosition) : base(bottomPosition)
    {
    }

    public override int Height => 4;

    public override string GetLine(int pos, string background, char rockPixel = '@')
    {
        // Single pixel on all 4 lines
        if (pos >= Bottom && pos < Top)
            return SetPixels(background, _left, 1, rockPixel);

        // Not in shape
        return background;
    }

    public override bool IsCollision(int pos, IEnumerable<string> background) 
        => background
            .Select(line => CheckCollisionOnLine(line, pos, 1))
            .Any(c => c);  
}

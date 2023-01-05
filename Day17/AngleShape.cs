namespace Day17;

public class AngleShape : ShapeBase
{
    public AngleShape(long bottomPosition) : base(bottomPosition)
    {
    }

    public override int Height => 3;

    public override string GetLine(long vPos, string background, char rockPixel = '@')
    {
        // Bottom is 3 pixels
        if (vPos == Bottom)
            return SetPixels(background, _left, 3, rockPixel);

        // Middle and top have one right most pixel
        if (vPos == Bottom + 1 || vPos == Bottom + 2) 
            return SetPixels(background, _left + 2, 1, rockPixel);

        // Not in shape
        return background;
    }

    public override bool IsCollision(int hPos, IEnumerable<string> background)
    {
        var line = background.ToArray();
        if (CheckCollisionOnLine(line[0], hPos, 3)) return true;
        if (CheckCollisionOnLine(line[1], hPos + 2, 1)) return true;
        if (CheckCollisionOnLine(line[2], hPos + 2, 1)) return true;
        return false;
    }
}

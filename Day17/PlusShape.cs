namespace Day17;

public class PlusShape : ShapeBase
{
    public PlusShape(long bottomPosition) : base(bottomPosition)
    {
    }

    public override int Height => 3;

    public override string GetLine(long vPos, string background, char rockPixel = '@')
    {
        // Top and bottom have one centre pixel
        if (vPos == Bottom || vPos == Bottom + 2) 
            return SetPixels(background, _left + 1, 1, rockPixel);

        // Middle is 3 pixels
        if (vPos == Bottom + 1)
            return SetPixels(background, _left, 3, rockPixel);

        // Not in shape
        return background;
    }

    public override bool IsCollision(int hPos, IEnumerable<string> background)
    {
        var line = background.ToArray();
        if (CheckCollisionOnLine(line[0], hPos + 1, 1)) return true;
        if (CheckCollisionOnLine(line[1], hPos, 3)) return true;
        if (CheckCollisionOnLine(line[2], hPos + 1, 1)) return true;
        return false;
    }
}

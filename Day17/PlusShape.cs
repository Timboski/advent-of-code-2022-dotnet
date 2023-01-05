namespace Day17;

public class PlusShape : ShapeBase
{
    public PlusShape(int bottomPosition) : base(bottomPosition)
    {
    }

    public override int Height => 3;

    public override string GetLine(int pos, string background, char rockPixel = '@')
    {
        // Top and bottom have one centre pixel
        if (pos == Bottom || pos == Bottom + 2) 
            return SetPixels(background, _left + 1, 1, rockPixel);

        // Middle is 3 pixels
        if (pos == Bottom + 1)
            return SetPixels(background, _left, 3, rockPixel);

        // Not in shape
        return background;
    }

    public override bool IsCollision(int pos, IEnumerable<string> background)
    {
        var line = background.ToArray();
        if (CheckCollisionOnLine(line[0], pos + 1, 1)) return true;
        if (CheckCollisionOnLine(line[1], pos, 3)) return true;
        if (CheckCollisionOnLine(line[2], pos + 1, 1)) return true;
        return false;
    }
}

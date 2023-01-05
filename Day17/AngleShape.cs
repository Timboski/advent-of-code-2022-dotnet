namespace Day17;

public class AngleShape : ShapeBase
{
    public AngleShape(int bottomPosition) : base(bottomPosition)
    {
    }

    public override int Height => 3;

    public override string GetLine(int pos, string background, char rockPixel = '@')
    {
        // Bottom is 3 pixels
        if (pos == Bottom)
            return SetPixels(background, _left, 3, rockPixel);

        // Middle and top have one right most pixel
        if (pos == Bottom + 1 || pos == Bottom + 2) 
            return SetPixels(background, _left + 2, 1, rockPixel);

        // Not in shape
        return background;
    }

    public override bool IsCollision(int pos, IEnumerable<string> background)
    {
        var line = background.ToArray();
        if (CheckCollisionOnLine(line[0], pos, 3)) return true;
        if (CheckCollisionOnLine(line[1], pos + 2, 1)) return true;
        if (CheckCollisionOnLine(line[2], pos + 2, 1)) return true;
        return false;
    }
}

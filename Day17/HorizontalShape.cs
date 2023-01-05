namespace Day17;

public class HorizontalShape : ShapeBase
{
    public HorizontalShape(int bottomPosition) : base(bottomPosition)
    {
    }

    public override int Height => 1;

    public override string GetLine(int pos, string background, char rockPixel = '@')
    {
        if (pos != Bottom) return background;
        return SetPixels(background, _left, 4, rockPixel);
    }

    public override bool IsCollision(int pos, IEnumerable<string> background)
        => CheckCollisionOnLine(background.First(), pos, 4);
}

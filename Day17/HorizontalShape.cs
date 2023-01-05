namespace Day17;

public class HorizontalShape : ShapeBase
{
    public HorizontalShape(long bottomPosition) : base(bottomPosition)
    {
    }

    public override int Height => 1;

    public override string GetLine(long vPos, string background, char rockPixel = '@')
    {
        if (vPos != Bottom) return background;
        return SetPixels(background, _left, 4, rockPixel);
    }

    public override bool IsCollision(int hPos, IEnumerable<string> background)
        => CheckCollisionOnLine(background.First(), hPos, 4);
}

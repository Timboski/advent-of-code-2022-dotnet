using System.Drawing;
using System.Text;

namespace Day14;

public class Cave
{
    private readonly BoundingBox _box;
    private readonly Dictionary<(int, int), char> _grid = new();

    public Cave(BoundingBox box, Point sandEntry)
    {
        _box = box;
        _grid[(sandEntry.X, sandEntry.Y)] = '+';
    }

    public void AddPath(IEnumerable<Point> points)
    {
        var current = points.First();
        foreach (var point in points.Skip(1))
        {
            AddLine(current, point);
            current = point;
        }
    }

    private void AddLine(Point first, Point second)
    {
        var startX = Math.Min(first.X, second.X);
        var endX = Math.Max(first.X, second.X);
        var startY = Math.Min(first.Y, second.Y);
        var endY = Math.Max(first.Y, second.Y);

        for (int x = startX; x <= endX; x++)
            for (int y = startY; y <= endY; y++)
                _grid[(x, y)] = '#';
    }

    public override string ToString()
    {
        var lineSize = _box.MaxX - _box.MinX;
        var lines = new List<string>(_box.MaxY - _box.MinY);

        for (int y = _box.MinY; y < _box.MaxY; y++)
        {
            var sb = new StringBuilder(lineSize);
            for (int x = _box.MinX; x < _box.MaxX; x++)
                if (_grid.ContainsKey((x, y))) sb.Append(_grid[(x, y)]);
                else sb.Append('.');

            lines.Add(sb.ToString());
        }

        return string.Join(Environment.NewLine, lines);
    }
}

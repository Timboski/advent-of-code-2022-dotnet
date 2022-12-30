using System.Drawing;
using System.Text;

namespace Day14;

public class Cave
{
    private readonly BoundingBox _box;
    private readonly Dictionary<Point, char> _grid = new();

    public Cave(BoundingBox box, Point sandEntry)
    {
        _box = box;
        _grid[sandEntry] = '+';
    }

    public void AddPath(IEnumerable<Point> points)
    {
        var start = points.First();
        var end = points.Last();
        for (int y = start.Y; y <= end.Y; y++)
            _grid[new Point(start.X, y)] = '#';
    }

    public override string ToString()
    {
        var lineSize = _box.MaxX - _box.MinX;
        var lines = new List<string>(_box.MaxY - _box.MinY);

        for (int y = _box.MinY; y < _box.MaxY; y++)
        {
            var sb = new StringBuilder(lineSize);
            for (int x = _box.MinX; x < _box.MaxX; x++)
                if (_grid.ContainsKey(new Point(x, y))) sb.Append(_grid[new Point(x, y)]);
                else sb.Append('.');

            lines.Add(sb.ToString());
        }

        return string.Join(Environment.NewLine, lines);
    }
}

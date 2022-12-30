using System.Drawing;
using System.Text;

namespace Day14;

public class Cave
{
    private readonly BoundingBox _box;
    private readonly Point _sandEntry;

	public Cave(BoundingBox box, Point sandEntry)
	{
        _box = box;
        _sandEntry = sandEntry;
	}

    public override string ToString()
    {
        var lineSize = _box.MaxX - _box.MinX;
        var lines = new List<string>(_box.MaxY - _box.MinY);

        for (int y = _box.MinY; y < _box.MaxY; y++)
        {
            var sb = new StringBuilder(lineSize);
            for (int x = _box.MinX; x < _box.MaxX; x++)
                if (new Point(x, y) == _sandEntry) sb.Append('+');
                else sb.Append('.');

            lines.Add(sb.ToString());
        }

        return string.Join(Environment.NewLine, lines);
    }
}

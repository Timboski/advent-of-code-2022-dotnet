using System.Drawing;

namespace Day12;

public class HillClimb
{
	private readonly Queue<HeightMap> _heightMap = new();

	public HillClimb(string filename)
	{
		var lines = File.ReadAllLines(filename);
		_heightMap.Enqueue(new HeightMap(lines));
	}

    public int FindHikingTrail()
    {
        _heightMap.Enqueue(_heightMap.Dequeue().Invert());
        return FindPath();
    }

    public int FindPath()
    {
        var visited = new HashSet<Point>();
		while (_heightMap.TryDequeue(out HeightMap heightMap))
        {
            var stepStart = heightMap.Start;
            if (!visited.Contains(stepStart))
            {
                visited.Add(stepStart);

                if (heightMap.IsComplete) return heightMap.PathLength;

                foreach (var step in heightMap.FindSteps())
                    _heightMap.Enqueue(step);
            }
		}

        throw new PathNotFoundException();
    }
}

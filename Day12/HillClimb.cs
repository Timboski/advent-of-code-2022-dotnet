using System.Drawing;

namespace Day12;

public class HillClimb
{
	private readonly Queue<HeightMap> _heightMap = new();
	private readonly Dictionary<Point, int> _visited = new();

	public HillClimb(string filename)
	{
		var lines = File.ReadAllLines(filename);
		_heightMap.Enqueue(new HeightMap(lines));
	}

    public int FindPath()
    {
		while (_heightMap.TryDequeue(out HeightMap heightMap))
        {
            var pathLength = heightMap.PathLength;
            var stepStart = heightMap.Start;
            if (!_visited.ContainsKey(stepStart))
            {
                _visited[stepStart] = pathLength;

                if (heightMap.IsComplete) return heightMap.PathLength;

                foreach (var step in heightMap.FindSteps())
                    _heightMap.Enqueue(step);
            }
		}

        throw new PathNotFoundException();
    }
}

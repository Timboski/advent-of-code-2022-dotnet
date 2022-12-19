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
        var start = _heightMap.Peek();

		var processedMaps = 0;
		var throttle = 0;
		while (_heightMap.TryDequeue(out HeightMap heightMap))
        {
            var pathLength = heightMap.PathLength;
            var stepStart = heightMap.Start;
            if (!_visited.ContainsKey(stepStart))
            {
                _visited[stepStart] = pathLength;

                ++processedMaps;
                ++throttle;
                if (throttle >= 100)
                {
                    throttle = 0;
                    DisplayState(processedMaps, heightMap);
                }

                if (heightMap.IsComplete)
                {
                    Console.WriteLine("COMPLETED");
                    DisplayState(processedMaps, heightMap);
                    return heightMap.PathLength;
                }

                foreach (var step in heightMap.FindSteps())
                    _heightMap.Enqueue(step);
            }
		}

		Console.WriteLine("FAILED");
		Console.WriteLine(processedMaps);
        Console.WriteLine($"Queue Length: {_heightMap.Count}");
        Console.WriteLine(start.GetVisitedMap(_visited));
        throw new PathNotFoundException();

        void DisplayState(int processedMaps, HeightMap heightMap)
        {
            Console.WriteLine(heightMap.ToString());
            Console.WriteLine($"Iteration: {processedMaps}");
            Console.WriteLine($"Path Length: {heightMap.PathLength}");
            Console.WriteLine($"Queue Length: {_heightMap.Count}");
            Console.WriteLine();
        }
    }
}

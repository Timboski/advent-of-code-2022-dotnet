namespace Day12;

public class HillClimb
{
	private Queue<HeightMap> _heightMap = new();

	public HillClimb(string filename)
	{
		var lines = File.ReadAllLines(filename);
		_heightMap.Enqueue(new HeightMap(lines));
	}

    public int FindPath()
    {
		var processedMaps = 0;
		var throttle = 0;
		while (_heightMap.TryDequeue(out HeightMap heightMap)) 
		{
			++processedMaps;
			++throttle;
			if (throttle >= 100000)
			{
				throttle = 0;
                Console.WriteLine($"Iteration: {processedMaps}");
                Console.WriteLine($"Path Length: {heightMap.PathLength}");
                Console.WriteLine($"Queue Length: {_heightMap.Count}");
                Console.WriteLine(heightMap.ToString());
				Console.WriteLine();
			}

			if (heightMap.IsComplete) return heightMap.PathLength;

			foreach (var step in heightMap.FindSteps()) _heightMap.Enqueue(step);
		}

		throw new PathNotFoundException();
    }
}

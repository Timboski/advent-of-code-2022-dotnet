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
		while (_heightMap.TryDequeue(out HeightMap heightMap)) 
		{
			if (heightMap.IsComplete) return heightMap.PathLength;

			foreach (var step in heightMap.FindSteps()) _heightMap.Enqueue(step);
		}

		throw new PathNotFoundException();
    }
}

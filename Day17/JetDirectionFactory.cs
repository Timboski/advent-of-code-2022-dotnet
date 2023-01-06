namespace Day17;

public class JetDirectionFactory
{
    private readonly CharEnumerator _enumerator;

    public JetDirectionFactory(string filename) 
		=> _enumerator = File.ReadAllText(filename).GetEnumerator();

	public int NextIndex { get; private set; }

	public char NextJetDirection()
	{
		NextIndex++;
		if (!_enumerator.MoveNext())
		{
			// Reached end
			_enumerator.Reset();
			_enumerator.MoveNext();
			NextIndex = 0;
		}

		return _enumerator.Current;
	}
}

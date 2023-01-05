namespace Day17;

public class JetDirectionFactory
{
    private readonly CharEnumerator _enumerator;

    public JetDirectionFactory(string filename) 
		=> _enumerator = File.ReadAllText(filename).GetEnumerator();

    public char NextJetDirection()
	{
		if (!_enumerator.MoveNext())
		{
			// Reached end
			_enumerator.Reset();
			_enumerator.MoveNext();
		}

		return _enumerator.Current;
	}
}

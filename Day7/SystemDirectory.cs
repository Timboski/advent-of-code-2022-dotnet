namespace Day7;

public class SystemDirectory
{
    private int _size = 0;

    public int Size => _size;

    public void AddFile(int size) => _size += size;

    public void MoveIn(string subDirectoryName)
    {
        throw new InvalidOperationException($"Directory not found: {subDirectoryName}");
    }

    public void MoveOut()
    {
        throw new InvalidOperationException($"No parent directory");
    }
}

namespace Day7;

public class SystemDirectory
{
    private int _size = 0;

    public int Size => _size;

    public void AddFile(int size) => _size += size;
}

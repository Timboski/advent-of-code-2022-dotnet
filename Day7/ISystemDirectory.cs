namespace Day7;

public interface ISystemDirectory
{
    void AddFile(int size);
    SystemDirectory MoveIn(string subDirectoryName);
    SystemDirectory MoveOut();
}
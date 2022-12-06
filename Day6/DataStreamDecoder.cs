namespace Day6;

public static class DataStreamDecoder
{
    public static int FindStartOfPacket(string data)
        => FindNonRepeatingBlock(data, 4);

    public static object FindStartOfMessage(string data)
        => FindNonRepeatingBlock(data, 14);

    public static int FindNonRepeatingBlock(string data, int blockLength)
    {
        for (var index = blockLength;  index <= data.Length; ++index)
        {
            if (IsNonRepeatingBlock(data[(index - blockLength)..index])) return index;
        }
        throw new IndexOutOfRangeException("Packet start not found");
    }

    private static bool IsNonRepeatingBlock(string dataBlock) 
        => new HashSet<char>(dataBlock).Count == dataBlock.Length;
}

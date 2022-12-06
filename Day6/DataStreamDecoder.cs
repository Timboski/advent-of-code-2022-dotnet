namespace Day6;

public static class DataStreamDecoder
{
    public static int FindStartOfPacket(string data) 
        => FindNonRepeatingBlock(data, 4);

    public static object FindStartOfMessage(string data)
    {
        throw new NotImplementedException();
    }

    public static int FindNonRepeatingBlock(string data, int blockLength)
    {
        for (var index = blockLength;  index <= data.Length; ++index)
        {
            if (IsNonRepeatingBlock(data[(index - blockLength)..index])) return index;
        }
        throw new IndexOutOfRangeException("Packet start not found");
    }

    private static bool IsNonRepeatingBlock(string packetStart)
    {
        if (packetStart[0] == packetStart[1]) return false;
        if (packetStart[0] == packetStart[2]) return false;
        if (packetStart[0] == packetStart[3]) return false;
        if (packetStart[1] == packetStart[2]) return false;
        if (packetStart[1] == packetStart[3]) return false;
        if (packetStart[2] == packetStart[3]) return false;
        return true;
    }
}

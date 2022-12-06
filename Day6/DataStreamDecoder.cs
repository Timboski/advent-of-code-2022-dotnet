namespace Day6;

public static class DataStreamDecoder
{
    public static int FindStartOfPacket(string data)
    {
        for (var index = 4;  index <= data.Length; ++index)
        {
            if (IsValidPacketStart(data[(index - 4)..index])) return index;
        }
        throw new IndexOutOfRangeException("Packet start not found");
    }

    private static bool IsValidPacketStart(string packetStart)
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

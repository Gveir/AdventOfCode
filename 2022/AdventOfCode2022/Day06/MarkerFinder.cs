namespace AdventOfCode2022.Day06
{
    public class MarkerFinder
    {
        public static int FindFirstStartOfPacket(string input) =>
            FindFirstMarker(input, 4);

        public static int FindFirstStartOfMessage(string input) =>
            FindFirstMarker(input, 14);

        private static int FindFirstMarker(string input, int packetLength)
        {
            for (int i = packetLength - 1; i < input.Length; i++)
            {
                char[] chunk = input.AsSpan(i - (packetLength - 1), packetLength).ToArray();
                if (chunk.GroupBy(ch => ch).Count() == packetLength)
                {
                    return i + 1;
                }
            }
            return -1;
        }
    }
}

namespace AdventOfCode2022.Day06
{
    public class StartOfPacketMarkerFinder
    {
        public static int FindFirst(string input)
        {
            for (int i = 3; i < input.Length; i++)
            {
                char[] chunk = input.AsSpan(i - 3, 4).ToArray();
                if( chunk.GroupBy(ch => ch).Count() == 4)
                {
                    return i + 1;
                }
            }
            return -1;
        }
    }
}

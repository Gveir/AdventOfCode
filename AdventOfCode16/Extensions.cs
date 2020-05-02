using System.Linq;

namespace AdventOfCode16
{
    internal static class Extensions
    {
        public static string ConvertToString(this int[] array) => string.Join(string.Empty, array.Select(b => b.ToString()));

        public static int[] ConvertFromString(this string @string, int repeatCounter = 1) => 
            Enumerable.Repeat(@string.Select(ch => int.Parse(ch.ToString())), repeatCounter).SelectMany(x => x).ToArray();
    }
}

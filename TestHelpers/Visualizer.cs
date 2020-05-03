using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit.Abstractions;

namespace TestHelpers
{
    public static class Visualizer
    {
        public static void Visualize<T>(this IReadOnlyDictionary<(int X, int Y), T> map, ITestOutputHelper output, IReadOnlyDictionary<T, char> valueMap, char defaultChar = ' ')
        {
            var lineBuilder = new StringBuilder();

            for (int i = map.Keys.Max(pos => pos.Y); i >= map.Keys.Min(pos => pos.Y); i--)
            {
                for (int j = map.Keys.Min(pos => pos.X); j <= map.Keys.Max(pos => pos.X); j++)
                {
                    lineBuilder.Append(map.TryGetValue((j, i), out var color) ? valueMap[color] : defaultChar);
                }

                output.WriteLine(lineBuilder.ToString());
                lineBuilder.Clear();
            }
        }

        public static void Visualize(this IReadOnlyDictionary<(int X, int Y), char> map, ITestOutputHelper output)
        {
            var lineBuilder = new StringBuilder();

            for (int i = map.Keys.Min(pos => pos.Y); i <= map.Keys.Max(pos => pos.Y); i++)
            {
                for (int j = map.Keys.Min(pos => pos.X); j <= map.Keys.Max(pos => pos.X); j++)
                {
                    lineBuilder.Append(map.GetValueOrDefault((j, i), ' '));
                }

                output.WriteLine(lineBuilder.ToString());
                lineBuilder.Clear();
            }
        }
    }
}

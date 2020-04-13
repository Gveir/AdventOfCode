using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode15
{
    public static class OxygenFillSimulator
    {
        public static int Simulate(IReadOnlyDictionary<(int X, int Y), TileType> map)
        {
            int maxLength = 0;
            var mapInternal = map.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            Queue<(int X, int Y, int Length)> paths = new Queue<(int, int, int)>(
                mapInternal.Where(x => x.Value == TileType.OxygenSystem)
                .Select(kvp => (kvp.Key.X, kvp.Key.Y, 0)));

            while(paths.Count > 0)
            {
                var (x, y, length) = paths.Dequeue();
                mapInternal[(x, y)] = TileType.Oxygen;

                var neightbours = GetEmptyNeighbours(mapInternal, (x, y)).ToList();

                if (neightbours.Count == 0)
                {
                    maxLength = Math.Max(maxLength, length);
                }

                foreach (var neightbour in neightbours)
                {
                    paths.Enqueue((neightbour.X, neightbour.Y, length + 1));
                }
            }

            return maxLength;
        }

        private static IEnumerable<(int X, int Y)> GetEmptyNeighbours(IReadOnlyDictionary<(int X, int Y), TileType> map, (int X, int Y) position) =>
            map.Where(
                kvp => kvp.Value == TileType.Empty &&
                kvp.Key != position &&
                (kvp.Key.Y == position.Y && (kvp.Key.X == position.X - 1 || kvp.Key.X == position.X + 1) ||
                kvp.Key.X == position.X && (kvp.Key.Y == position.Y - 1 || kvp.Key.Y == position.Y + 1)))
            .Select(kvp => kvp.Key);
    }
}

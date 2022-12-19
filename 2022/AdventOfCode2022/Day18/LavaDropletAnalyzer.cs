using System.Diagnostics;

namespace AdventOfCode2022.Day18
{
    public class LavaDropletAnalyzer
    {
        public static readonly List<Cube> Neighbours = new List<Cube>
        {
            new Cube(-1, 0, 0),
            new Cube(1, 0, 0),
            new Cube(0, -1, 0),
            new Cube(0, 1, 0),
            new Cube(0, 0, -1),
            new Cube(0, 0, 1)
        };

        public static int CalculateSurfaceArea(string[] input)
        {
            var cubes = ParseInput(input).ToHashSet();

            return CalculateSurfaceArea(cubes);
        }


        public static int CalculateExteriorSurfaceArea(string[] input)
        {
            var cubes = ParseInput(input).ToHashSet();

            var surfaceArea = CalculateSurfaceArea(cubes);

            var (minX, maxX) = cubes.MinAndMax(cube => cube.X);
            var (minY, maxY) = cubes.MinAndMax(cube => cube.Y);
            var (minZ, maxZ) = cubes.MinAndMax(cube => cube.Z);

            for (int x = minX; x <= maxX; x++)
            {
                for (int y = minY; y <= maxY; y++)
                {
                    for (int z = minZ; z < maxZ; z++)
                    {
                        var cube = new Cube(x, y, z);

                        if(!cubes.Contains(cube) && IsSurrounded(cube, cubes))
                        {
                            surfaceArea -= CountNeighbours(cube, cubes);
                        }
                    }
                }
            }

            return surfaceArea;
        }

        private static bool IsSurrounded(Cube cube, HashSet<Cube> cubes)
        {
            var x = cubes.Any(c => c.X < cube.X && c.Y == cube.Y && c.Z == cube.Z) &&
                cubes.Any(c => c.X > cube.X && c.Y == cube.Y && c.Z == cube.Z);
            var y = cubes.Any(c => c.X == cube.X && c.Y < cube.Y && c.Z == cube.Z) &&
                cubes.Any(c => c.X == cube.X && c.Y > cube.Y && c.Z == cube.Z);
            var z = cubes.Any(c => c.X == cube.X && c.Y == cube.Y && c.Z < cube.Z) &&
                cubes.Any(c => c.X == cube.X && c.Y == cube.Y && c.Z > cube.Z);

            return x && y && z;
        }

        private static int CountNeighbours(Cube cube, HashSet<Cube> cubes) =>
            Neighbours.Select(n => cube + n).Where(n => cubes.Contains(n)).Count();

        private static int CalculateSurfaceArea(HashSet<Cube> cubes) =>
            cubes.Select(cube => CalculateSurfaceArea(cube, cubes)).Sum();

        private static int CalculateSurfaceArea(Cube cube, HashSet<Cube> cubes) =>
            Neighbours.Select(n => cube + n).Where(n => !cubes.Contains(n)).Count();

        private static IEnumerable<Cube> ParseInput(string[] input)
        {
            foreach (var inputLine in input)
            {
                var position = inputLine.Split(',').Select(c => int.Parse(c)).ToList();
                yield return new Cube(position[0], position[1], position[2]);
            }
        }
    }

    [DebuggerDisplay("{X} {Y} {Z}")]
    public record Cube(int X, int Y, int Z)
    {
        public static Cube operator+(Cube a, Cube b) => new Cube(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    }

    internal static class EnumerableExtensions
    {
        public static (int min, int max) MinAndMax<T>(this IEnumerable<T> objects, Func<T, int> selector) => 
            objects.Aggregate((MinValue: int.MaxValue, MaxValue: int.MinValue), (acc, o) => (Math.Min(acc.MinValue, selector(o)), Math.Max(acc.MaxValue, selector(o))));
    }
}

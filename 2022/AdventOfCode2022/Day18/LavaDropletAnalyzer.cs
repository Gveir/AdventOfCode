namespace AdventOfCode2022.Day18
{
    public class LavaDropletAnalyzer
    {
        private static readonly List<Cube> Neighbours = new List<Cube>
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

            return cubes.Select(cube => CalculateSurfaceArea(cube, cubes)).Sum();
        }

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

    internal record Cube(int X, int Y, int Z)
    {
        public static Cube operator+(Cube a, Cube b) => new Cube(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    }
}

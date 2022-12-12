namespace AdventOfCode2022.Day12
{
    public class PathFinder
    {
        public static int FindShortestPathLength(string[] input) => FindShortestPath(ParseMap(input)).Count;

        private static Map ParseMap(string[] input)
        {
            var map = new Map();

            for (int y = 0; y < input.Length; y++)
            {
                for (int x = 0; x < input[y].Length; x++)
                {
                    map.AddGridSquare(new GridSquare(new Coordinate(x, y), input[y][x]));
                }
            }

            return map;
        }

        private static IReadOnlyList<GridSquare> FindShortestPath(Map map)
        {
            var queue = new Queue<GridSquare>();
            map.StartingPosition.Visited = true;
            queue.Enqueue(map.StartingPosition);

            while(queue.Count > 0)
            {
                var currentPosition = queue.Dequeue();

                if(currentPosition == map.BestSignalPosition)
                {
                    return BuildPath(currentPosition).Reverse().ToList();
                }

                var moveCandidates = map.GetMoveCandidates(currentPosition);

                foreach (var moveCandidate in moveCandidates)
                {
                    moveCandidate.Visited = true;
                    moveCandidate.Parent = currentPosition;
                    queue.Enqueue(moveCandidate);
                }
            }

            return Enumerable.Empty<GridSquare>().ToList();
        }

        private static IEnumerable<GridSquare> BuildPath(GridSquare position)
        {
            while(position.Parent != null)
            {
                yield return position.Parent;
                position = position.Parent;
            }
        }
    }

    internal class Map
    {
        private static readonly IList<Vector> MoveVectors = new List<Vector>
        {
            new Vector(1, 0),
            new Vector(-1, 0),
            new Vector(0, 1),
            new Vector(0, -1)
        };

        private readonly List<GridSquare> _gridSquares = new List<GridSquare>();

        public IReadOnlyList<GridSquare> GridSquares => _gridSquares;
        public GridSquare StartingPosition => _gridSquares.Single(gs => gs.Elevation == 'S');
        public GridSquare BestSignalPosition => _gridSquares.Single(gs => gs.Elevation == 'E');

        public void AddGridSquare(GridSquare gridSquare) => _gridSquares.Add(gridSquare);

        public IEnumerable<GridSquare> GetMoveCandidates(GridSquare position) {
            return MoveVectors
                .Join(_gridSquares, v => position.Coordinate + v, gs => gs.Coordinate, (_, gs) => gs)
                .Where(gs => !gs.Visited && gs.NormalizedElevation <= position.NormalizedElevation + 1)
                .OrderByDescending(gs => gs.Elevation)
                .ToList();
        }
    }

    internal record GridSquare(Coordinate Coordinate, char Elevation)
    {
        public bool Visited { get; set; } = false;
        public GridSquare Parent { get; set; } = null;
        public char NormalizedElevation => Elevation == 'S' ? 'a' : Elevation == 'E' ? 'z' : Elevation;
    }

    internal record Coordinate(int X, int Y)
    {
        public static Coordinate operator +(Coordinate c, Vector v) => new Coordinate(c.X + v.X, c.Y + v.Y);
    }

    internal record Vector(int X, int Y);
}

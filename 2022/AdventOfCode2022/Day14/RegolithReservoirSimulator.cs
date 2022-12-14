namespace AdventOfCode2022.Day14
{
    public class RegolithReservoirSimulator
    {
        private static readonly List<Vector> FallingDirections = new List<Vector>
        {
            new Vector(0, 1),
            new Vector(-1, 1),
            new Vector(1, 1)
        };

        public static int CountUnitsOfSandAtRest(string input, bool infiniteFloor = false)
        {
            var simulationResult = SimulateSandPouring(input, infiniteFloor);

            return simulationResult.Count;
        }

        private static IReadOnlyList<Position> SimulateSandPouring(string input, bool infiniteFloor)
        {
            var rocks = ParseRocksSetup(input);
            var sandUnits = new HashSet<Position>();

            var pouringPoint = new Position(500, 0);
            var bottom = rocks.Max(p => p.Y);
            var fallingSandUnit = pouringPoint;

            while (true)
            {
                var (newPosition, isAtRest) = SetNewUnitPosition(fallingSandUnit, rocks, sandUnits, infiniteFloor, bottom);
                fallingSandUnit = newPosition;

                if (infiniteFloor && fallingSandUnit == pouringPoint)
                {
                    break;
                }
                if (!infiniteFloor && fallingSandUnit.Y >= bottom)
                {
                    sandUnits.Remove(fallingSandUnit);
                    break;
                }

                if (!isAtRest) continue;

                sandUnits.Add(fallingSandUnit);
                fallingSandUnit = pouringPoint;
            }

            return sandUnits.ToList().AsReadOnly();
        }

        private static (Position, bool) SetNewUnitPosition(Position pouringSandUnit, HashSet<Position> rocks, HashSet<Position> sandUnits, bool infiniteFloor, int bottom)
        {
            var fallingPositions = FallingDirections.Select(d => pouringSandUnit + d);

            foreach (var newPosition in fallingPositions)
            {
                if (infiniteFloor && newPosition.Y == bottom + 2) break;

                if(sandUnits.Contains(newPosition) || rocks.Contains(newPosition))
                {
                    continue;
                }
                
                return (newPosition, false);
            }

            sandUnits.Add(pouringSandUnit);
            return (pouringSandUnit, true);
        }

        private static HashSet<Position> ParseRocksSetup(string input)
        {
            var rockPaths = input.Split(Environment.NewLine);
            var rocks = new HashSet<Position>();

            foreach (var rockPath in rockPaths)
            {
                var points = rockPath.Split(" -> ")
                    .Select(p => p.Split(','))
                    .Select(p => new Position(int.Parse(p[0]), int.Parse(p[1])))
                    .ToList();

                rocks.Add(points[0]);
                var currentPoint = points[0];

                for (var i = 1; i < points.Count; i++)
                {
                    rocks.AddRange(GetPositionsBetween(currentPoint, points[i]));
                    currentPoint = points[i];
                }
            }

            return rocks;
        }

        private static IEnumerable<Position> GetPositionsBetween(Position from, Position to)
        {
            if (from.X == to.X)
            {
                var diff = to.Y - from.Y;
                var direction = diff / Math.Abs(diff);

                for (var i = 1; i <= Math.Abs(diff); i++)
                {
                    yield return new Position(from.X, from.Y + i * direction);
                }
            }

            if (from.Y == to.Y)
            {
                var diff = to.X - from.X;
                var direction = diff / Math.Abs(diff);

                for (var i = 1; i <= Math.Abs(diff); i++)
                {
                    yield return new Position(from.X + i * direction, from.Y);
                }
            }
        }
    }

    internal record Position(int X, int Y)
    {
        public static Position operator +(Position p, Vector v) =>
            new Position(p.X + v.X, p.Y + v.Y);
    }

    internal record Vector(int X, int Y);
}

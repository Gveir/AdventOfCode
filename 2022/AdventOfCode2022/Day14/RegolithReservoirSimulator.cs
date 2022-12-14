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

            return simulationResult.Count(unit => unit.Kind == UnitKind.Sand);
        }

        private static IReadOnlyList<Unit> SimulateSandPouring(string input, bool infiniteFloor)
        {
            var cave = ParseInitialCaveSetup(input);

            var pouringPoint = new Position(500, 0);
            var bottom = cave.Where(u => u.Kind == UnitKind.Rock).Max(u => u.Position.Y);
            var fallingSandUnit = new Unit(pouringPoint, UnitKind.Sand);
            cave.Add(fallingSandUnit);

            while (true)
            {
                SetNewUnitPosition(fallingSandUnit, cave, infiniteFloor, bottom);

                if (infiniteFloor && fallingSandUnit.Position == pouringPoint)
                {
                    break;
                }
                if (!infiniteFloor && fallingSandUnit.Position.Y >= bottom)
                {
                    cave.Remove(fallingSandUnit);
                    break;
                }

                if (!fallingSandUnit.IsAtRest) continue;

                fallingSandUnit = new Unit(pouringPoint, UnitKind.Sand);
                cave.Add(fallingSandUnit);
            }

            return cave.AsReadOnly();
        }

        private static void SetNewUnitPosition(Unit pouringSandUnit, List<Unit> cave, bool infiniteFloor, int bottom)
        {
            var fallingPositions = FallingDirections.Select(d => pouringSandUnit.Position + d);

            foreach (var newPosition in fallingPositions)
            {
                if (infiniteFloor && newPosition.Y == bottom + 2) break;

                if ((cave.FirstOrDefault(unit => unit.Position == newPosition)?.Kind ?? UnitKind.Air) > UnitKind.Air)
                    continue;

                pouringSandUnit.Position = newPosition;
                return;
            }

            pouringSandUnit.IsAtRest = true;
        }

        private static List<Unit> ParseInitialCaveSetup(string input)
        {
            var rockPaths = input.Split(Environment.NewLine);
            var initialCave = new List<Unit>();

            foreach (var rockPath in rockPaths)
            {
                var points = rockPath.Split(" -> ")
                    .Select(p => p.Split(','))
                    .Select(p => new Position(int.Parse(p[0]), int.Parse(p[1])))
                    .ToList();

                initialCave.Add(new Unit(points[0], UnitKind.Rock));
                var currentPoint = points[0];

                for (var i = 1; i < points.Count; i++)
                {
                    initialCave.AddRange(GetPositionsBetween(currentPoint, points[i]).Select(p => new Unit(p, UnitKind.Rock)));
                    currentPoint = points[i];
                }
            }

            return initialCave;
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

    internal record Unit(Position Position, UnitKind Kind, bool IsAtRest = false)
    {
        public Position Position { get; set; } = Position;
        public bool IsAtRest { get; set; } = IsAtRest;
    }

    internal record Position(int X, int Y)
    {
        public static Position operator +(Position p, Vector v) =>
            new Position(p.X + v.X, p.Y + v.Y);
    }

    internal record Vector(int X, int Y);

    internal enum UnitKind
    {
        Air,
        Rock,
        Sand
    }
}

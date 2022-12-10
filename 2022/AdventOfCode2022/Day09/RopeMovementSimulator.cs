namespace AdventOfCode2022.Day09
{
    public class RopeMovementSimulator
    {
        private static IDictionary<char, (int X, int Y)> MovementVectors = new Dictionary<char, (int X, int Y)>
            {
                { 'R', (1, 0) },
                { 'L', (-1, 0) },
                { 'U', (0, 1) },
                { 'D', (0, -1) }
            };

        public static int CountPositionsVisitedByTail(string[] input, int ropeLength)
        {
            var visitedPositionsPerKnot = SimulateMovements(input, ropeLength);

            return visitedPositionsPerKnot.Last().Count;
        }

        private static IReadOnlyList<IReadOnlyList<Coordinate>> SimulateMovements(string[] movements, int ropeLength)
        {
            var knotsPositions = Enumerable.Repeat(new Coordinate(0, 0), ropeLength).ToList();
            var visitedPositionsPerKnot = knotsPositions.Select(k => new HashSet<Coordinate> { k }).ToList();

            foreach (var movement in movements.Select(Movement.FromString))
            {
                var steps = movement.StepsCount;
                while (steps-- > 0)
                {
                    ApplyMovement(movement.Direction, knotsPositions, visitedPositionsPerKnot);
                }
            }

            return visitedPositionsPerKnot.Select(k => k.ToList()).ToList();
        }

        private static void ApplyMovement(char movementDirection, List<Coordinate> knotsPositions, IList<HashSet<Coordinate>> visitedPositionsPerKnot)
        {
            var movementVector = MovementVectors[movementDirection];

            knotsPositions[0] = new Coordinate(knotsPositions[0].Row + movementVector.Y, knotsPositions[0].Column + movementVector.X);
            visitedPositionsPerKnot[0].Add(knotsPositions[0]);

            for (int knotIndex = 1; knotIndex < knotsPositions.Count; knotIndex++)
            {
                var knotBefore = knotsPositions[knotIndex - 1];
                var thisKnot = knotsPositions[knotIndex];
                if (AreTouching(knotBefore, thisKnot))
                {
                    break;
                }

                movementVector = CalculateDeltas(knotBefore, thisKnot);
                knotsPositions[knotIndex] = new Coordinate(thisKnot.Row + movementVector.Y, thisKnot.Column + movementVector.X);
                visitedPositionsPerKnot[knotIndex].Add(knotsPositions[knotIndex]);
            }
        }

        private static bool AreTouching(Coordinate knot1, Coordinate knot2)
        {
            return knot1.Row - 1 <= knot2.Row && knot2.Row <= knot1.Row + 1 &&
                knot1.Column - 1 <= knot2.Column && knot2.Column <= knot1.Column + 1;
        }

        private static (int X, int Y) CalculateDeltas(Coordinate knot1, Coordinate knot2) =>
            (CalculateDelta(knot1.Column, knot2.Column), CalculateDelta(knot1.Row, knot2.Row));

        private static int CalculateDelta(int A, int B)
        {
            var delta = A - B;
            return delta == 0 ? 0 : (delta / Math.Abs(delta));
        }

        private record Coordinate (int Row, int Column);

        private record Movement (char Direction, int StepsCount)
        {
            public static Movement FromString(string movement)
            {
                var parts = movement.Split(' ');
                return new Movement(parts[0][0], int.Parse(parts[1]));
            }
        }
    }
}

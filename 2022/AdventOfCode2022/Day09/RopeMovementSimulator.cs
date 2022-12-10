using System.Data;

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

        public static int CountTailPositions(string[] input, int ropeLength)
        {

            var visitedPositions = SimulateMovements(input, ropeLength);

            return visitedPositions.Last().Count;
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
                    continue;
                }

                movementVector = (CalculateDelta(knotBefore.Column, thisKnot.Column), CalculateDelta(knotBefore.Row, thisKnot.Row));
                knotsPositions[knotIndex] = new Coordinate(thisKnot.Row + movementVector.Y, thisKnot.Column + movementVector.X);
                visitedPositionsPerKnot[knotIndex].Add(knotsPositions[knotIndex]);
            }
        }

        private static bool AreTouching(Coordinate headPosition, Coordinate tailPosition)
        {
            return headPosition.Row - 1 <= tailPosition.Row && tailPosition.Row <= headPosition.Row + 1 &&
                headPosition.Column - 1 <= tailPosition.Column && tailPosition.Column <= headPosition.Column + 1;
        }

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

using System.Security.Cryptography.X509Certificates;

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

        public static int CountTailPositions(string[] input)
        {
            
            var (_, tailPositions) = SimulateMovements(input);

            return tailPositions.Count;
        }

        private static (IReadOnlyList<Coordinate> HeadPositions, IReadOnlyList<Coordinate> TailPositions) SimulateMovements(string[] movements)
        {
            var headPosition = new Coordinate(0, 0);
            var tailPosition = new Coordinate(0, 0);
            var headVisitedPositions = new HashSet<Coordinate> { headPosition };
            var tailVisitedPositions = new HashSet<Coordinate> { tailPosition };

            foreach (var movement in movements.Select(Movement.FromString))
            {
                var steps = movement.StepsCount;
                while (steps-- > 0)
                {
                    var (newHeadPosition, newTailPosition) = ApplyMovement(movement, headPosition, tailPosition);
                    headVisitedPositions.Add(headPosition = newHeadPosition);
                    tailVisitedPositions.Add(tailPosition = newTailPosition);
                }
            }

            return (headVisitedPositions.ToList(), tailVisitedPositions.ToList());
        }

        private static (Coordinate HeadPosition, Coordinate TailPosition) ApplyMovement(Movement movement, Coordinate headPosition, Coordinate tailPosition)
        {
            var movementVector = MovementVectors[movement.Direction];
            Coordinate newHeadPosition = new Coordinate(headPosition.Row + movementVector.Y, headPosition.Column + movementVector.X);

            if(AreTouching(newHeadPosition, tailPosition))
            {
                return (newHeadPosition, tailPosition);
            }

            Coordinate newTailPosition;

            if (tailPosition.Row == newHeadPosition.Row || tailPosition.Column == newHeadPosition.Column)
            {
                newTailPosition = new Coordinate(tailPosition.Row + movementVector.Y, tailPosition.Column + movementVector.X);
            }
            else
            {
                switch (movement.Direction) {
                    case 'R':
                    case 'L':
                        var deltaRow = newHeadPosition.Row - tailPosition.Row;
                        newTailPosition = new Coordinate(tailPosition.Row + movementVector.Y + deltaRow, tailPosition.Column + movementVector.X);
                        break;
                    case 'U':
                    case 'D':
                        var deltaColumn = newHeadPosition.Column - tailPosition.Column;
                        newTailPosition = new Coordinate(tailPosition.Row + movementVector.Y, tailPosition.Column + movementVector.X + deltaColumn);
                        break;
                    default:
                        throw new InvalidOperationException($"Unrecognized movement direction {movement.Direction}");
                }
                
            }

            return (newHeadPosition, newTailPosition);
        }

        private static bool AreTouching(Coordinate headPosition, Coordinate tailPosition)
        {
            return headPosition.Row - 1 <= tailPosition.Row && tailPosition.Row <= headPosition.Row + 1 &&
                headPosition.Column - 1 <= tailPosition.Column && tailPosition.Column <= headPosition.Column + 1;
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

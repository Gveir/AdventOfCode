using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode03
{

    public class IntersectionFinder
    {
        public static int FindClosestIntersectionDistance(string path1, string path2)
        {
            var pathPoints1 = GetPathPoints(path1);
            var pathPoints2 = GetPathPoints(path2);

            var commonPoints = pathPoints1.Intersect(pathPoints2);

            return commonPoints.Select(p => Math.Abs(p.X) + Math.Abs(p.Y)).Min();
        }

        public static int FindFewestCombinedSteps(string path1, string path2)
        {
            var pathPoints1 = GetPathPoints(path1);
            var pathPoints2 = GetPathPoints(path2);

            var commonPoints = pathPoints1.Intersect(pathPoints2);

            List<int> combinedStepsLenghts = new List<int>();

            foreach (var commonPoint in commonPoints)
            {
                combinedStepsLenghts.Add(pathPoints1.CalculatePathLenghtToPoint(commonPoint) + pathPoints2.CalculatePathLenghtToPoint(commonPoint));
            }

            return combinedStepsLenghts.Min();
        }

        private static int CalculatePathLenghtToPoint(IEnumerable<Point> pathPoints1, Point commonPoint)
        {
            int i = 1;
            foreach (var pathPoint in pathPoints1)
            {
                if (pathPoint.Equals(commonPoint)) break;
                i++;
            }

            return i;
        }

        private static IEnumerable<Point> GetPathPoints(string path)
        {
            var operations = path.Split(',');

            List<Point> pathPoints = new List<Point>();

            Point currentPosition = new Point(0, 0);


            foreach (var op in operations)
            {
                var direction = op[0];
                var distance = Convert.ToInt32(op[1..]);

                IEnumerable<Point> pathSegment;

                switch (direction)
                {
                    case 'U':
                        pathSegment = Enumerable.Range(1, distance).Select(delta => new Point(currentPosition.X, currentPosition.Y + delta));
                        break;
                    case 'D':
                        pathSegment = Enumerable.Range(1, distance).Select(delta => new Point(currentPosition.X, currentPosition.Y - delta));
                        break;
                    case 'L':
                        pathSegment = Enumerable.Range(1, distance).Select(delta => new Point(currentPosition.X - delta, currentPosition.Y));
                        break;
                    case 'R':
                        pathSegment = Enumerable.Range(1, distance).Select(delta => new Point(currentPosition.X + delta, currentPosition.Y));
                        break;
                    default:
                        throw new InvalidOperationException($"Unrecongized direction: {direction}");
                }

                pathPoints.AddRange(pathSegment);
                currentPosition = pathSegment.Last();
            }

            return pathPoints;
        }
    }
}

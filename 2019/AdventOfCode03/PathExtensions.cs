using System.Collections.Generic;

namespace AdventOfCode03
{
    internal static class PathExtensions
    {
        public static int CalculatePathLenghtToPoint(this IEnumerable<Point> pathPoints, Point commonPoint)
        {
            int i = 1;
            foreach (var pathPoint in pathPoints)
            {
                if (pathPoint.Equals(commonPoint)) break;
                i++;
            }

            return i;
        }
    }
}

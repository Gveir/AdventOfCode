using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode03
{
    internal class PointsComparer : IEqualityComparer<Point>
    {
        public bool Equals([AllowNull] Point x, [AllowNull] Point y)
        {
            return x.X == y.X && x.Y == y.Y;
        }

        public int GetHashCode([DisallowNull] Point obj)
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + obj.X.GetHashCode();
            hashCode = hashCode * -1521134295 + obj.Y.GetHashCode();
            return hashCode;
        }
    }
}

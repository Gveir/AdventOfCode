using System;
using System.Collections.Generic;

namespace AdventOfCode11
{
    internal class Position
    {
        public static Position Start = new Position(0, 0);

        private static Dictionary<Direction, Func<Position, Position>> nextPositonMap = new Dictionary<Direction, Func<Position, Position>>
        {
            { Direction.Up, (pos) => new Position(pos.X, pos.Y + 1) },
            { Direction.Down, (pos) => new Position(pos.X, pos.Y - 1) },
            { Direction.Left, (pos) => new Position(pos.X - 1, pos.Y) },
            { Direction.Right, (pos) => new Position(pos.X + 1, pos.Y) }
        };

        public int X { get; private set; }
        public int Y { get; private set; }

        private Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{X}:{Y}";
        }

        public override bool Equals(object obj)
        {
            return obj is Position point &&
                   X == point.X &&
                   Y == point.Y;
        }

        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }

        public Position Next(Direction direction) => nextPositonMap[direction](this);
    }
}

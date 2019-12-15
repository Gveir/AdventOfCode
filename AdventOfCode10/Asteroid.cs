using System;

namespace AdventOfCode10
{
    public class Asteroid
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public bool IsDestroyed { get; private set; }

        public Asteroid(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"X:{X}/Y:{Y}";
        }

        public float CalculateSlope(Asteroid a)
        {
            int dx = X - a.X;
            int dy = Y - a.Y;
            return dx != 0 ? (float)dy / dx : dy < 0 ? float.MaxValue : float.MinValue;
        }

        public int Distance(Asteroid a) => Math.Abs(X - a.X) + Math.Abs(Y - a.Y);

        public void Vaporize()
        {
            IsDestroyed = true;
        }
    }
}

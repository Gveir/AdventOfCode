using System;

namespace AdventOfCode12
{
    public class Moon
    {
        public (int X, int Y, int Z) Position { get; private set; }
        public (int X, int Y, int Z) Velocity { get; set; }
        public int TotalEnergy => PotentialEnergy * KineticEnergy;
        public int PotentialEnergy => Math.Abs(Position.X) + Math.Abs(Position.Y) + Math.Abs(Position.Z);
        public int KineticEnergy => Math.Abs(Velocity.X) + Math.Abs(Velocity.Y) + Math.Abs(Velocity.Z);

        public Moon((int, int, int) position)
        {
            Position = position;
            Velocity = (0, 0, 0);
        }

        public void UpdatePosition()
        {
            Position = (Position.X + Velocity.X, Position.Y + Velocity.Y, Position.Z + Velocity.Z);
        }

        public override bool Equals(object obj)
        {
            return obj is Moon moon &&
                Position.Equals(moon.Position) &&
                Velocity.Equals(moon.Velocity);
        }

        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + Position.GetHashCode();
            hashCode = hashCode * -1521134295 + Velocity.GetHashCode();
            return hashCode;
        }
    }
}

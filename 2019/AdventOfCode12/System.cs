using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode12
{
    public class System
    {
        private List<Moon> _moons;
        private IEnumerable<(Moon, Moon)> _moonPairs;

        public IReadOnlyList<Moon> Moons => _moons;
        public int TotalEnergy => _moons.Sum(m => m.TotalEnergy);

        public System(IEnumerable<(int, int, int)> moonsPositions)
        {
            _moons = moonsPositions.Select(m => new Moon(m)).ToList();

            _moonPairs = from firstIndex in Enumerable.Range(0, _moons.Count())
                         from secondIndex in Enumerable.Range(firstIndex + 1, _moons.Count() - firstIndex - 1)
                         select (_moons[firstIndex], _moons[secondIndex]);
        }

        public void Simulate(int numberOfSteps)
        {
            for (int i = 0; i < numberOfSteps; i++)
            {
                Simulate();
            }
        }

        public void Simulate()
        {
            foreach (var moonPair in _moonPairs)
            {
                var (moon1, moon2) = moonPair;

                var newVelocity1 = CalculateNewVelocity(moon1, moon2);
                var newVelocity2 = CalculateNewVelocity(moon2, moon1);

                moon1.Velocity = newVelocity1;
                moon2.Velocity = newVelocity2;
            }

            foreach (var moon in _moons)
            {
                moon.UpdatePosition();
            }
        }

        private (int, int, int) CalculateNewVelocity(Moon moon1, Moon moon2)
        {
            var nvx = CalculateNewVelocity(moon1.Velocity.X, moon1.Position.X, moon2.Position.X);
            var nvy = CalculateNewVelocity(moon1.Velocity.Y, moon1.Position.Y, moon2.Position.Y);
            var nvz = CalculateNewVelocity(moon1.Velocity.Z, moon1.Position.Z, moon2.Position.Z);

            return (nvx, nvy, nvz);
        }

        private int CalculateNewVelocity(int v, int p1, int p2)
        {
            return v + (p1 < p2 ? 1 : p1 > p2 ? -1 : 0);
        }
    }
}

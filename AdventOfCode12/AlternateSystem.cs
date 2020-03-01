using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode12
{
    public class AlternateSystem
    {
        private const int MOON_DATA_LENGTH = 6;
        private int[] _state;
        private IEnumerable<(int First, int Second)> _moonPairs;

        public IReadOnlyCollection<int> State => Array.AsReadOnly(_state);
        public int TotalEnergy => Enumerable.Range(0, _state.Length / MOON_DATA_LENGTH).Sum(i => MoonsTotalEnergy(i));
        
        public AlternateSystem(IEnumerable<(int X, int Y, int Z)> moonsPositions)
        {
            _state = moonsPositions.Select(m => new int[] { m.X, m.Y, m.Z, 0, 0, 0 }).SelectMany(x => x).ToArray();

            _moonPairs = from firstIndex in Enumerable.Range(0, moonsPositions.Count())
                         from secondIndex in Enumerable.Range(firstIndex + 1, moonsPositions.Count() - firstIndex - 1)
                         select (firstIndex * MOON_DATA_LENGTH, secondIndex * MOON_DATA_LENGTH);
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
                for (int i = 3; i < MOON_DATA_LENGTH; i++)
                {
                    var firstPosition = _state[moonPair.First + i - 3];
                    var secondPosition = _state[moonPair.Second + i - 3];

                    var a = (firstPosition < secondPosition ? 1 : firstPosition > secondPosition ? -1 : 0);

                    _state[moonPair.First + i] += a;
                    _state[moonPair.Second + i] -= a;
                }
            }

            for (int i = 0; i < _state.Length; i += MOON_DATA_LENGTH)
            {
                for (int j = 0; j < 3; j++)
                {
                    _state[i + j] += _state[i + j + 3];
                }
            }
        }

        private int MoonsTotalEnergy(int moonIndex) => MoonsPotentialEnergy(moonIndex) * MoonsKineticEnergy(moonIndex);
        private int MoonsPotentialEnergy(int moonIndex) => new ArraySegment<int>(_state, moonIndex * 6, 3).Sum(Math.Abs);
        private int MoonsKineticEnergy(int moonIndex) => new ArraySegment<int>(_state, moonIndex * 6 + 3, 3).Sum(Math.Abs);
    }
}

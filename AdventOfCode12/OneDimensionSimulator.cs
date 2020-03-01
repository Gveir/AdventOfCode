using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode12
{
    public class OneDimensionSimulator
    {
        private const int MOON_DATA_LENGTH = 2;
        private int[] _state;
        private IEnumerable<(int First, int Second)> _moonPairs;
        
        public IReadOnlyCollection<int> State => Array.AsReadOnly(_state);

        public OneDimensionSimulator(IEnumerable<int> moonsPositions)
        {
            _state = moonsPositions.Select(pos => new int[] { pos, 0 }).SelectMany(x => x).ToArray();

            _moonPairs = from firstIndex in Enumerable.Range(0, moonsPositions.Count())
                         from secondIndex in Enumerable.Range(firstIndex + 1, moonsPositions.Count() - firstIndex - 1)
                         select (firstIndex * MOON_DATA_LENGTH, secondIndex * MOON_DATA_LENGTH);
        }

        public void Simulate()
        {
            foreach (var moonPair in _moonPairs)
            {
                    var firstPosition = _state[moonPair.First];
                    var secondPosition = _state[moonPair.Second];

                    var a = (firstPosition < secondPosition ? 1 : firstPosition > secondPosition ? -1 : 0);

                    _state[moonPair.First + 1] += a;
                    _state[moonPair.Second + 1] -= a;
            }

            for (int i = 0; i < _state.Length; i += MOON_DATA_LENGTH)
            {
                _state[i] += _state[i + 1];
            }
        }
    }
}

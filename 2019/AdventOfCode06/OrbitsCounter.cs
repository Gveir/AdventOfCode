using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode06
{
    public class OrbitsCounter
    {
        private readonly Dictionary<string, string> _map;
        private readonly Dictionary<string, int> _distances;

        public OrbitsCounter(string map)
        {
            _map = LoadMap(map);
            _distances = new Dictionary<string, int>();
        }

        public int CountTotal()
        {
            return _map.Sum(CalculateDistanceToCentreOfMass);
        }

        public int CountOrbitalTransfers(string from, string to)
        {
            var fromToCoMPath = DeterminePathToCentreOfMass(from).ToArray();
            var toToCoMPath = DeterminePathToCentreOfMass(to).ToArray();

            return fromToCoMPath.Except(toToCoMPath).Count() + toToCoMPath.Except(fromToCoMPath).Count();
        }

        private IEnumerable<string> DeterminePathToCentreOfMass(string from)
        {
            var orbit = _map.Single(o => o.Key == from);

            while (orbit.Value != "COM")
            {
                yield return orbit.Value;
                orbit = _map.Single(o => o.Key == orbit.Value);
            }
        }

        private int CalculateDistanceToCentreOfMass(KeyValuePair<string, string> orbit)
        {
            int distance;

            if (_distances.TryGetValue(orbit.Key, out distance))
            {
                return distance;
            }

            if (orbit.Value == "COM")
            {
                _distances.Add(orbit.Key, 1);
                return 1;
            }

            if (_distances.TryGetValue(orbit.Value, out distance))
            {
                _distances.Add(orbit.Key, distance + 1);
                return distance + 1;
            }

            distance = CalculateDistanceToCentreOfMass(_map.Single(o => o.Key == orbit.Value));
            _distances.Add(orbit.Key, distance + 1);
            return distance + 1;
        }

        private Dictionary<string, string> LoadMap(string map)
        {
            return map.Split(Environment.NewLine)
                .Select(orbit => orbit.Split(')'))
                .ToDictionary(orbit => orbit[1], orbit => orbit[0]);
        }
    }
}

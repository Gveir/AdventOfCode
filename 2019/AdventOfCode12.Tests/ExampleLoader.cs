using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode12.Tests
{
    internal class ExampleLoader
    {
        public System System { get; private set; }
        public IDictionary<int, List<Moon>> ExpectedSystemStateOnStep => _expectedSystemStateOnStep;

        private Dictionary<int, List<Moon>> _expectedSystemStateOnStep;

        public ExampleLoader(string fileName)
        {
            var example = File.ReadAllText(fileName).Split(Environment.NewLine);

            var moonsPositions = new List<(int, int, int)>();

            for (int i = 0; i < 4; i++)
            {
                var matches = Regex.Matches(example[i], @"-?\d+").Select(m => int.Parse(m.Value)).ToArray();
                moonsPositions.Add((matches[0], matches[1], matches[2]));
            }

            System = new System(moonsPositions);

            _expectedSystemStateOnStep = new Dictionary<int, List<Moon>>();

            for (int i = 4; i < example.Length; i += 5)
            {
                int step = int.Parse(Regex.Match(example[i], @"-?\d+").Value);

                var moons = new List<Moon>();

                for (int j = i + 1; j < i + 5; j++)
                {
                    var matches = Regex.Matches(example[j], @"-?\d+").Select(m => int.Parse(m.Value)).ToArray();
                    moons.Add(
                        new Moon((matches[0], matches[1], matches[2]))
                            {
                                Velocity = (matches[3], matches[4], matches[5])
                            }
                    );
                }

                _expectedSystemStateOnStep.Add(step, moons);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode12.Tests
{
    internal class AlternateExampleLoader
    {
        public AlternateSystem System { get; private set; }
        public Dictionary<int, IReadOnlyCollection<int>> ExpectedSystemStateOnStep { get; private set; }

        public AlternateExampleLoader(string fileName)
        {
            var example = File.ReadAllText(fileName).Split(Environment.NewLine);

            var moonsPositions = new List<(int, int, int)>();

            for (int i = 0; i < 4; i++)
            {
                var matches = Regex.Matches(example[i], @"-?\d+").Select(m => int.Parse(m.Value)).ToArray();
                moonsPositions.Add((matches[0], matches[1], matches[2]));
            }

            System = new AlternateSystem(moonsPositions);

            ExpectedSystemStateOnStep = new Dictionary<int, IReadOnlyCollection<int>>();

            for (int i = 4; i < example.Length; i += 5)
            {
                int step = int.Parse(Regex.Match(example[i], @"-?\d+").Value);

                IList<IList<int>> values = new List<IList<int>>();

                for (int j = i + 1; j < i + 5; j++)
                {
                    var matches = Regex.Matches(example[j], @"-?\d+").Select(m => int.Parse(m.Value)).ToList();
                    values.Add(matches);
                }

                ExpectedSystemStateOnStep.Add(step, Array.AsReadOnly(values.SelectMany(x => x).ToArray()));
            }
        }
    }
}

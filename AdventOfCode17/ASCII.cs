using AdventOfCode02;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode17
{
    public class ASCII
    {
        private readonly Intcode _processor;

        private Dictionary<(int X, int Y), char> _map;
        private List<(int X, int Y)> _intersections;
        private Dictionary<(int X, int Y), int> _alignmentParameters;

        private List<Func<(int X, int Y), (int X, int Y)>> _neighbours = new List<Func<(int X, int Y), (int X, int Y)>>
        {
            ((int X, int Y) pos) => (pos.X + 1, pos.Y),
            ((int X, int Y) pos) => (pos.X - 1, pos.Y),
            ((int X, int Y) pos) => (pos.X, pos.Y + 1),
            ((int X, int Y) pos) => (pos.X, pos.Y - 1),
        };

        public IReadOnlyDictionary<(int X, int Y), char> Map => _map;
        public int AlignmentParametersSum => _alignmentParameters.Sum(kvp => kvp.Value);

        public ASCII(string program)
        {
            _processor = new Intcode(program);
        }

        public void ProcessFrame()
        {
            PrepareMap();
            FindIntersections();
            CalculateAlignmentParameters();
        }

        private void PrepareMap()
        {
            _map = new Dictionary<(int X, int Y), char>();
            int x = 0;
            int y = 0;
            while (!_processor.IsFinished)
            {
                _processor.Process();

                var output = (char)_processor.Output;
                if (output == 10)
                {
                    x = 0;
                    y++;
                }
                else
                {
                    _map.Add((x++, y), output);
                }
            }
        }

        private void FindIntersections()
        {
            _intersections = _map.Where(kvp => kvp.Value == '#')
                            .Select(kvp => kvp.Key)
                            .Where(p => _neighbours.Select(f => _map.GetValueOrDefault(f(p), (char)0)).Count(x => x == '#') == 4)
                            .ToList();
        }

        private void CalculateAlignmentParameters()
        {
            _alignmentParameters = _intersections.ToDictionary(p => p, p => p.X * p.Y);
        }
    }
}

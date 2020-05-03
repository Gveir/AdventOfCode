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

        public ASCII(string program) : this(program, false)
        {

        }

        public ASCII(string program, bool wakeUpVacuumRobot)
        {
            _processor = new Intcode(program);

            if (wakeUpVacuumRobot)
            {
                _processor.WriteMemory(0, 2);
            }
        }

        public void ProcessFrame()
        {
            PrepareMap();
            FindIntersections();
            CalculateAlignmentParameters();
        }

        public long ExploreScaffolds()
        {
            //Main movement routine and movement functions established by "manually"
            //analyzing the map and figuring out the correct patterns
            var mainMovementRoutine = "A,B,A,C,A,B,C,B,C,B" + (char)10;
            var movementFunctionA = "R,8,L,10,L,12,R,4" + (char)10;
            var movementFunctionB = "R,8,L,12,R,4,R,4" + (char)10;
            var movementFunctionC = "R,8,L,10,R,8" + (char)10;

            _processor.EnqueStringInput(mainMovementRoutine);
            _processor.EnqueStringInput(movementFunctionA);
            _processor.EnqueStringInput(movementFunctionB);
            _processor.EnqueStringInput(movementFunctionC);
            _processor.EnqueStringInput("n" + (char)10);

            while (!_processor.IsFinished)
            {
                _processor.Process();
            }

            return _processor.Output;
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

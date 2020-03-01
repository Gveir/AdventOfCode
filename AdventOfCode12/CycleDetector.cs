using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode12
{
    public class CycleDetector
    {
        private readonly IEnumerable<(int X, int Y, int Z)> _moonsPositions;

        public CycleDetector(IEnumerable<(int X, int Y, int Z)> moonsPositions)
        {
            _moonsPositions = moonsPositions;
        }

        public long FindCycleSteps()
        {
            var xCycleTask = FindCycle(_moonsPositions.Select(m => m.X));
            var yCycleTask = FindCycle(_moonsPositions.Select(m => m.Y));
            var zCycleTask = FindCycle(_moonsPositions.Select(m => m.Z));

            Task.WaitAll(xCycleTask, yCycleTask, zCycleTask);

            return LCM.Calculate(xCycleTask.Result, yCycleTask.Result, zCycleTask.Result);
        }

        private async Task<long> FindCycle(IEnumerable<int> moonsPositionsOneDimension)
        {
            var simulator = new OneDimensionSimulator(moonsPositionsOneDimension);

            var initialState = simulator.State.ToArray();

            
            long step = 0;

            await Task.Run(() =>
            {
                do
                {
                    step++;
                    simulator.Simulate();
                    if (initialState.SequenceEqual(simulator.State))
                    {
                        break;
                    }
                } while (true);
            });

            return step;
        }
    }
}

using System.Linq;
using System.Collections.Generic;
using AdventOfCode02;

namespace AdventOfCode07
{
    public class AmplifierController
    {
        private readonly string _program;

        public AmplifierController(string program)
        {
            _program = program;
        }

        public long DetermineMaxThrusterSignal()
        {
            long maxSignal = 0;

            var phaseSettings = new List<int> { 0, 1, 2, 3, 4 }.GetPermutations(5).ToArray();

            foreach (var phaseSettingSequence in phaseSettings)
            {
                var signal = CalculateSignal(phaseSettingSequence);

                maxSignal = signal > maxSignal ? signal : maxSignal;
            }

            return maxSignal;
        }

        private long CalculateSignal(IEnumerable<int> phaseSettingSequence)
        {
            long input = 0;

            foreach (var phaseSetting in phaseSettingSequence)
            {
                var processor = new Intcode(_program, new List<long> { phaseSetting, input });

                processor.Process();

                input = processor.Output;
            }

            return input;
        }
    }
}

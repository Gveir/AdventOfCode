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
            List<Intcode> amplifiers = phaseSettingSequence.Select(phaseSetting => new Intcode(_program, phaseSetting)).ToList();

            long input = 0;

            foreach (var amplifier in amplifiers)
            {
                amplifier.EnqueueInput(input);

                amplifier.Process();

                input = amplifier.Output;
            }

            return input;
        }
    }
}

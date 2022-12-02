using AdventOfCode02;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode07
{
    public class FeedbackLoopedAmplifierController
    {
        private readonly string _program;

        public FeedbackLoopedAmplifierController(string program)
        {
            _program = program;
        }

        public long DetermineMaxThrusterSignal()
        {
            long maxSignal = 0;

            var phaseSettings = new List<int> { 5, 6, 7, 8, 9 }.GetPermutations(5).ToArray();

            foreach (var phaseSettingSequence in phaseSettings)
            {
                var signal = CalculateSignal(phaseSettingSequence);

                maxSignal = signal > maxSignal ? signal : maxSignal;
            }

            return maxSignal;
        }

        private long CalculateSignal(IEnumerable<int> phaseSettingSequence)
        {
            Intcode[] amplifiers = phaseSettingSequence.Select(phaseSetting => new Intcode(_program, phaseSetting)).ToArray();
            Intcode ampE = amplifiers.Last();

            int ampIndex = 0;
            long input = 0;

            while (!ampE.IsFinished)
            {
                var amplifier = amplifiers[ampIndex];

                amplifier.EnqueueInput(input);

                amplifier.Process();

                input = amplifier.Output;

                ampIndex = (ampIndex + 1) % amplifiers.Length;
            }

            return input;
        }
    }
}

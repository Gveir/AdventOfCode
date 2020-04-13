using System;
using System.Linq;

namespace AdventOfCode16
{
    public class Signal
    {
        private readonly int[] _signal;

        private Signal(int[] signal)
        {
            _signal = signal;
        }

        internal Signal ApplyPattern(int[] basePattern)
        {
            int[] newSignal = new int[_signal.Length];

            for (int i = 0; i < _signal.Length; i++)
            {
                int[] possitionPattern = basePattern.Select(x => Enumerable.Repeat(x, i + 1)).SelectMany(x => x).ToArray();
                newSignal[i] = Math.Abs(_signal.Select((x, index) => x * possitionPattern[(index + 1) % possitionPattern.Length]).Sum()) % 10;
            }

            return new Signal(newSignal);
        }

        public override string ToString() => string.Join(string.Empty, _signal.Select(b => b.ToString()));

        public static implicit operator string(Signal signal) => signal.ToString();
        public static explicit operator Signal(string signal) => new Signal(signal.Select(ch => int.Parse(ch.ToString())).ToArray());
    }
}

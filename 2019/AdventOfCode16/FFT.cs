using System;
using System.Linq;

namespace AdventOfCode16
{
    public static class FFT
    {
        public static string Calculate(string input, int phase)
        {
            return Calculate(input, 1, phase);
        }

        public static string Calculate(string input, int repeatCounter, int phase, bool skipFirstHalf = false)
        {
            int[] signal = input.ConvertFromString(repeatCounter);

            return Enumerable.Range(0, phase).Aggregate(signal, (output, _) => ApplyPattern(output, skipFirstHalf)).ToArray().ConvertToString();
        }

        private static int[] ApplyPattern(int[] signal, bool skipFirstHalf)
        {
            if (!skipFirstHalf)
            {
                for (int i = 0; i < signal.Length / 2; i++)
                {
                    int sum = 0;
                    for (int j = i; j < signal.Length; j += (i + 1) * 4)
                    {
                        for (int k = j; k <= Math.Min(j + i, signal.Length - 1); k++)
                        {
                            sum += signal[k];
                        }
                    }

                    int subs = 0;
                    for (int j = 2 + i * 3; j < signal.Length; j += (i + 1) * 4)
                    {
                        for (int k = j; k <= Math.Min(j + i, signal.Length - 1); k++)
                        {
                            subs += signal[k];
                        }
                    }

                    signal[i] = Math.Abs(sum - subs) % 10;
                }
            }

            for (int i = signal.Length - 2; i >= signal.Length / 2; i--)
            {
                signal[i] = (signal[i] + signal[i + 1]) % 10;
            }

            return signal;
        }
    }
}

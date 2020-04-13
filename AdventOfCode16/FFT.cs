using System.Linq;

namespace AdventOfCode16
{
    public static class FFT
    {
        private static int[] _basePattern = new[] { 0, 1, 0, -1 };

        public static Signal Calculate(Signal input, int phase)
        {
            return Enumerable.Range(0, phase).Aggregate(input, (output, _) => output.ApplyPattern(_basePattern));
        }
    }
}

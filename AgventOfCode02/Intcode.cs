using System;
using System.Linq;

namespace AdventOfCode02
{
    public class Intcode
    {
        private const int FinishOpcode = 99;

        public static string Calculate(string input)
        {
            var inputs = input.Split(',').Select(i => Convert.ToInt64(i)).ToArray();

            int index = 0;

            while (inputs[index] != FinishOpcode)
            {
                var opcode = inputs[index];
                long result;
                switch (opcode)
                {
                    case 1:
                        result = inputs[inputs[index + 1]] + inputs[inputs[index + 2]];
                        break;
                    case 2:
                        result = inputs[inputs[index + 1]] * inputs[inputs[index + 2]];
                        break;
                    default:
                        throw new InvalidOperationException($"Unrecognized operation opcode: {opcode}");
                }

                inputs[inputs[index + 3]] = result;

                index += 4;
            }

            return string.Join(',', inputs);
        }
    }
}

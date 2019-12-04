using System;
using System.Linq;

namespace AdventOfCode02
{
    public class Intcode
    {
        private const int FinishOpcode = 99;

        private long[] _memory;

        public long Result => _memory[0];

        public Intcode(string memoryDump)
        {
            LoadMemory(memoryDump);
        }

        public void LoadMemory(string memoryDump)
        {
            _memory = memoryDump.Split(',').Select(i => Convert.ToInt64(i)).ToArray();
        }

        public void AdjustMemory(Action<long[]> adjuster)
        {
            adjuster(_memory);
        }

        public string GetMemoryDump() => string.Join(',', _memory);

        public void Process()
        {
            int index = 0;

            while (_memory[index] != FinishOpcode)
            {
                var opcode = _memory[index];
                var operand1 = _memory[_memory[index + 1]];
                var operand2 = _memory[_memory[index + 2]];
                var outputStoreIndex = _memory[index + 3];
                long result;
                switch (opcode)
                {
                    case 1:
                        result = operand1 + operand2;
                        break;
                    case 2:
                        result = operand1 * operand2;
                        break;
                    default:
                        throw new InvalidOperationException($"Unrecognized operation opcode: {opcode}");
                }

                _memory[outputStoreIndex] = result;

                index += 4;
            }
        }
    }
}

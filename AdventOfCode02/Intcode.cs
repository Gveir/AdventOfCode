using AdventOfCode02.Operations;
using System;
using System.Linq;

namespace AdventOfCode02
{
    public class Intcode
    {
        private long[] _memory;

        public long Result => _memory[0];

        public Intcode(string program)
        {
            LoadProgram(program);
        }

        public void LoadProgram(string program)
        {
            _memory = program.Split(',').Select(i => Convert.ToInt64(i)).ToArray();
        }

        public void AdjustMemory(Action<long[]> adjuster)
        {
            adjuster(_memory);
        }

        public string GetMemoryDump() => string.Join(',', _memory);

        public void Process()
        {
            var operationsStream = OperationsFactory.CreateOperationsStream(_memory);

            foreach (var op in operationsStream)
            {
                op.Apply(_memory);
            }
        }
    }
}

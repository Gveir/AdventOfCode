using AdventOfCode02.Operations;
using System;
using System.Linq;

namespace AdventOfCode02
{
    public class Intcode : IProcessor
    {
        private long[] _memory;

        public long Result => _memory[0];
        public long Input { get; private set; }
        public long Output { get; set; }

        public Intcode(string program) : this(program, 0)
        {
        }

        public Intcode(string program, long input)
        {
            LoadProgram(program);
            Input = input;
        }

        public long ReadMemory(long index) => _memory[index];
        public long ReadMemory(IParameter index) => ReadMemory(index.RetrieveValue(this));

        public void WriteMemory(long index, long value) => _memory[index] = value;
        public void WriteMemory(IParameter index, long value) => WriteMemory(index.RetrieveValue(this), value);

        public void Process()
        {
            var operationsStream = OperationsFactory.CreateOperationsStream(this);

            foreach (var op in operationsStream)
            {
                op.Apply(this);
            }
        }

        public string GetMemoryDump() => string.Join(',', _memory);

        private void LoadProgram(string program)
        {
            _memory = program.Split(',').Select(i => Convert.ToInt64(i)).ToArray();
        }
    }
}

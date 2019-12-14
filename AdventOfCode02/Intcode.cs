using AdventOfCode02.Operations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode02
{
    public class Intcode : IProcessor
    {
        private long[] _memory;
        private long _index = 0;
        private readonly Queue<long> _inputs;

        public long Result => _memory[0];
        public long Input => GetNextInput();
        public long Output { get; set; }
        public bool IsFinished { get; set; }

        public Intcode(string program) : this(program, new List<long>())
        {
        }

        public Intcode(string program, long input) : this(program, new List<long> { input })
        {
        }

        public Intcode(string program, IEnumerable<long> inputs)
        {
            LoadProgram(program);
            _inputs = new Queue<long>(inputs);
        }

        public long ReadMemory(long index) => _memory[index];
        public long ReadMemory(int offset) => _memory[_index + offset];
        public long ReadMemory(IParameter index) => ReadMemory(index.RetrieveValue(this));

        public void WriteMemory(long index, long value) => _memory[index] = value;
        public void WriteMemory(IParameter index, long value) => WriteMemory(index.RetrieveValue(this), value);

        public long ReadIndex() => _index;
        public void MoveIndex(int offset) => _index += offset;
        public void SetIndex(long index) => _index = index;

        public long GetNextInput()
        {
            if (_inputs.TryDequeue(out long result))
            {
                return result;
            }

            throw new InvalidOperationException("No more inputs provided. Ensure your program is correct.");
        }

        public void EnqueueInput(long input)
        {
            _inputs.Enqueue(input);
        }

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

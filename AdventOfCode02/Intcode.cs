using AdventOfCode02.Operations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode02
{
    public class Intcode : IProcessor
    {
        private long[] _memory;
        private long _opPointer = 0;
        private long _relativeBase = 0;
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

        private Intcode(IEnumerable<long> memory, long opPointer, long relativeBase, IEnumerable<long> inputs)
        {
            _memory = memory.ToArray();
            _opPointer = opPointer;
            _relativeBase = relativeBase;
            _inputs = new Queue<long>(inputs);
        }

        public long ReadMemory(int offset) => _memory[_opPointer + offset];

        public long ReadMemory(IParameter index)
        {
            switch (index.Mode)
            {
                case ParameterMode.Position:
                    return _memory[index.Value];
                case ParameterMode.Immediate:
                    return index.Value;
                case ParameterMode.Relative:
                    return _memory[index.Value + _relativeBase];
                default:
                    throw new InvalidOperationException($"Unknow parameter mode: {index.Mode}");
            }
        }

        public void WriteMemory(long index, long value) => _memory[index] = value;
        public void WriteMemory(IParameter index, long value)
        {
            switch (index.Mode)
            {
                case ParameterMode.Position:
                    WriteMemory(index.Value, value);
                    break;
                case ParameterMode.Relative:
                    WriteMemory(index.Value + _relativeBase, value);
                    break;
                case ParameterMode.Immediate:
                    throw new InvalidOperationException("Can not write to the memory using a parameter in Immediate mode.");
                default:
                    throw new InvalidOperationException($"Unknow parameter mode: {index.Mode}");
            }
            
        }

        public void AdjustOpPointer(int offset) => _opPointer += offset;
        public void SetOpPointer(long opPointer) => _opPointer = opPointer;

        public void AdjustRelativeBase(long offset) => _relativeBase += offset;

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

        public void EnqueStringInput(string input)
        {
            foreach (var ch in input)
            {
                EnqueueInput(ch);
            }
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
            var tempMemory = program.Split(',').Select(i => Convert.ToInt64(i)).ToArray();
            _memory = new long[tempMemory.Length * 20]; //arbitrarily chosen memory size to alocate as the requirements are vague 
            Array.Copy(tempMemory, 0, _memory, 0, tempMemory.Length);
        }

        public Intcode Clone()
        {
            return new Intcode(_memory, _opPointer, _relativeBase, _inputs);
        }
    }
}

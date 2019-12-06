using System;

namespace AdventOfCode02.Operations
{
    internal enum ParameterMode
    {
        Position = 0,
        Immediate = 1
    }

    internal class Parameter
    {
        private long _value;
        private ParameterMode _mode;

        public Parameter(long value) : this(value, ParameterMode.Position)
        {
        }

        public Parameter(long value, ParameterMode mode)
        {
            _value = value;
            _mode = mode;
        }

        public long RetrieveValue(long[] memory)
        {
            switch (_mode)
            {
                case ParameterMode.Position:
                    return memory[_value];
                case ParameterMode.Immediate:
                    return _value;
                default:
                    throw new InvalidOperationException($"Unrecognized parameter mode: {_mode}");
            }
        }
    }
}

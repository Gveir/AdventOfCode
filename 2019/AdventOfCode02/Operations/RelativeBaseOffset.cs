using System;

namespace AdventOfCode02.Operations
{
    internal class RelativeBaseOffset : IOperation
    {
        private readonly Parameter _relativeBaseOffset;

        public RelativeBaseOffset(Parameter relativeBaseOffset)
        {
            _relativeBaseOffset = relativeBaseOffset;
        }
        public void Apply(IProcessor processor)
        {
            processor.AdjustRelativeBase(processor.ReadMemory(_relativeBaseOffset));
            processor.AdjustOpPointer(2);
        }
    }
}

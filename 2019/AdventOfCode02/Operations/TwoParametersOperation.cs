namespace AdventOfCode02.Operations
{
    internal abstract class TwoParametersOperation : IOperation
    {
        private readonly Parameter _operand1;
        private readonly Parameter _operand2;
        private readonly Parameter _storeIndex;

        public TwoParametersOperation(Parameter operand1, Parameter operand2, Parameter storeIndex)
        {
            _operand1 = operand1;
            _operand2 = operand2;
            _storeIndex = storeIndex;
        }

        public void Apply(IProcessor processor)
        {
            processor.WriteMemory(
                _storeIndex,
                PerformOperation(processor.ReadMemory(_operand1), processor.ReadMemory(_operand2))
            );
            processor.AdjustOpPointer(4);
        }

        protected abstract long PerformOperation(long operand1Value, long operand2Value);
    }
}

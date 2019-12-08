namespace AdventOfCode02.Operations
{
    internal abstract class TwoParametersOperation : IOperation
    {
        private readonly Parameter _operand1;
        private readonly Parameter _operand2;
        private readonly StoreIndex _storeIndex;

        public TwoParametersOperation(Parameter operand1, Parameter operand2, StoreIndex storeIndex)
        {
            _operand1 = operand1;
            _operand2 = operand2;
            _storeIndex = storeIndex;
        }

        public void Apply(IProcessor processor)
        {
            processor.WriteMemory(
                _storeIndex,
                PerformOperation(_operand1.RetrieveValue(processor), _operand2.RetrieveValue(processor))
            );
        }

        protected abstract long PerformOperation(long operand1Value, long operand2Value);
    }
}

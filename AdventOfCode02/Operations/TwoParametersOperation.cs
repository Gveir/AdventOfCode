namespace AdventOfCode02.Operations
{
    internal abstract class TwoParametersOperation : IOperation
    {
        private readonly Parameter _operand1;
        private readonly Parameter _operand2;
        private readonly Parameter _outputStoreIndex;

        public TwoParametersOperation(Parameter operand1, Parameter operand2, Parameter outputStoreIndex)
        {
            _operand1 = operand1;
            _operand2 = operand2;
            _outputStoreIndex = outputStoreIndex;
        }

        public void Apply(long[] memory)
        {
            memory[_outputStoreIndex.RetrieveValue(memory)] = PerformOperation(_operand1.RetrieveValue(memory), _operand2.RetrieveValue(memory));
        }

        protected abstract long PerformOperation(long operand1Value, long operand2Value);
    }
}

namespace AdventOfCode02.Operations
{
    internal class Addition : TwoParametersOperation
    {
        public Addition(Parameter operand1, Parameter operand2, StoreIndex outputStoreIndex) : base(operand1, operand2, outputStoreIndex)
        {
        }

        protected override long PerformOperation(long operand1Value, long operand2Value)
        {
            return operand1Value + operand2Value;
        }
    }
}

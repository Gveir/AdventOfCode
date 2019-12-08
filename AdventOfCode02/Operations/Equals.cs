namespace AdventOfCode02.Operations
{
    internal class Equals : IOperation
    {
        private readonly Parameter _operand1;
        private readonly Parameter _operand2;
        private readonly StoreIndex _storeIndex;

        public Equals(Parameter operand1, Parameter operand2, StoreIndex storeIndex)
        {
            _operand1 = operand1;
            _operand2 = operand2;
            _storeIndex = storeIndex;
        }
        public void Apply(IProcessor processor)
        {
            processor.WriteMemory(_storeIndex, _operand1.RetrieveValue(processor) == _operand2.RetrieveValue(processor) ? 1 : 0);
            processor.MoveIndex(4);
        }
    }
}

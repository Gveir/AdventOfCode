namespace AdventOfCode02.Operations
{
    internal class Equals : IOperation
    {
        private readonly Parameter _operand1;
        private readonly Parameter _operand2;
        private readonly Parameter _storeIndex;

        public Equals(Parameter operand1, Parameter operand2, Parameter storeIndex)
        {
            _operand1 = operand1;
            _operand2 = operand2;
            _storeIndex = storeIndex;
        }
        public void Apply(IProcessor processor)
        {
            processor.WriteMemory(_storeIndex, processor.ReadMemory(_operand1) == processor.ReadMemory(_operand2) ? 1 : 0);
            processor.AdjustOpPointer(4);
        }
    }
}

namespace AdventOfCode02.Operations
{
    internal class JumpIfFalse : IOperation
    {
        private readonly Parameter _operand1;
        private readonly Parameter _operand2;

        public JumpIfFalse(Parameter operand1, Parameter operand2)
        {
            _operand1 = operand1;
            _operand2 = operand2;
        }
        public void Apply(IProcessor processor)
        {
            if (_operand1.RetrieveValue(processor) == 0)
            {
                processor.SetIndex(_operand2.RetrieveValue(processor));
            }
            else
            {
                processor.MoveIndex(3);
            }
        }
    }
}

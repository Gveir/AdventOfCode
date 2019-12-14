namespace AdventOfCode02.Operations
{
    internal class JumpIfTrue : IOperation
    {
        private readonly Parameter _operand1;
        private readonly Parameter _operand2;

        public JumpIfTrue(Parameter operand1, Parameter operand2)
        {
            _operand1 = operand1;
            _operand2 = operand2;
        }
        public void Apply(IProcessor processor)
        {
            if (processor.ReadMemory(_operand1) != 0)
            {
                processor.SetOpPointer(processor.ReadMemory(_operand2));
            }
            else
            {
                processor.AdjustOpPointer(3);
            }
        }
    }
}

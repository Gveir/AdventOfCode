namespace AdventOfCode02.Operations
{
    internal class Input : IOperation
    {
        private readonly Parameter _storeIndex;

        public Input(Parameter storeIndex)
        {
            _storeIndex = storeIndex;
        }

        public void Apply(IProcessor processor)
        {
            processor.WriteMemory(_storeIndex, processor.Input);
            processor.AdjustOpPointer(2);
        }
    }
}

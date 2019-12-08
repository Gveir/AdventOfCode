namespace AdventOfCode02.Operations
{
    internal class Input : IOperation
    {
        private readonly StoreIndex _storeIndex;

        public Input(StoreIndex storeIndex)
        {
            _storeIndex = storeIndex;
        }

        public void Apply(IProcessor processor)
        {
            processor.WriteMemory(_storeIndex, processor.Input);
            processor.MoveIndex(2);
        }
    }
}

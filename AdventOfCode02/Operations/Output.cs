namespace AdventOfCode02.Operations
{
    internal class Output : IOperation
    {
        private readonly StoreIndex _index;

        public Output(StoreIndex index)
        {
            _index = index;
        }

        public void Apply(IProcessor processor)
        {
            processor.Output = processor.ReadMemory(_index);
        }
    }
}

namespace AdventOfCode02.Operations
{
    internal class Output : IOperation
    {
        private readonly Parameter _index;

        public Output(Parameter index)
        {
            _index = index;
        }

        public void Apply(IProcessor processor)
        {
            processor.Output = processor.ReadMemory(_index);
            processor.AdjustOpPointer(2);
        }
    }
}

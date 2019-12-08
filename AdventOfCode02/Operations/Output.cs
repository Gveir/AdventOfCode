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
            processor.Output = _index.RetrieveValue(processor);
            processor.MoveIndex(2);
        }
    }
}

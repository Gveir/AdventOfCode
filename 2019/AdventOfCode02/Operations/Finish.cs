namespace AdventOfCode02.Operations
{
    internal class Finish : IOperation
    {
        public void Apply(IProcessor processor)
        {
            processor.IsFinished = true;
        }
    }
}

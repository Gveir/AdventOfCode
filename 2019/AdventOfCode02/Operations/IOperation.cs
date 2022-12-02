namespace AdventOfCode02.Operations
{
    internal interface IOperation
    {
        void Apply(IProcessor processor);
    }
}

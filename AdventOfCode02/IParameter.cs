namespace AdventOfCode02
{
    public interface IParameter
    {
        long RetrieveValue(IReadOnlyProcessor processor);
    }
}

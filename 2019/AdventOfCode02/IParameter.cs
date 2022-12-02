using AdventOfCode02.Operations;

namespace AdventOfCode02
{
    public interface IParameter
    {
        ParameterMode Mode { get; }
        long Value { get; }
    }
}

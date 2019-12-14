namespace AdventOfCode02.Operations
{
    public enum ParameterMode
    {
        Position = 0,
        Immediate = 1,
        Relative = 2
    }

    internal class Parameter : IParameter
    {
        public ParameterMode Mode { get; private set; }
        public long Value { get; private set; }

        public Parameter(long value, ParameterMode mode)
        {
            Value = value;
            Mode = mode;
        }
    }
}

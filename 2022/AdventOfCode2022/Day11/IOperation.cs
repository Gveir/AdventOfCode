namespace AdventOfCode2022.Day11
{
    internal interface IOperation
    {
        ulong CalculateNew(ulong old);
    }

    internal record Add(uint Operand) : IOperation
    {
        public ulong CalculateNew(ulong old) => old + Operand;
    }

    internal record Multiply(uint Operand) : IOperation
    {
        public ulong CalculateNew(ulong old) => old * Operand;
    }

    internal record MultiplyByItself() : IOperation
    {
        public ulong CalculateNew(ulong old) => old * old;
    }
}

namespace AdventOfCode02
{
    public interface IReadOnlyProcessor
    {
        long Input { get; }
        long ReadMemory(int offset);
        long ReadMemory(IParameter index);
    }

    public interface IProcessor : IReadOnlyProcessor
    {
        long Output { get; set; }
        bool IsFinished { get; set; }
        void WriteMemory(IParameter index, long value);

        void AdjustOpPointer(int offset);
        void SetOpPointer(long opPointer);

        void AdjustRelativeBase(long reltiveBaseOffset);
    }
}

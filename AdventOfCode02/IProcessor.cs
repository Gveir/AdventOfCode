namespace AdventOfCode02
{
    public interface IReadOnlyProcessor
    {
        long Input { get; }
        long ReadMemory(long index);
        long ReadMemory(int offset);
        long ReadMemory(IParameter index);
        long ReadIndex();
    }

    public interface IProcessor : IReadOnlyProcessor
    {
        long Output { get; set; }
        void WriteMemory(IParameter index, long value);
        void MoveIndex(int offset);
        void SetIndex(long index);
    }
}

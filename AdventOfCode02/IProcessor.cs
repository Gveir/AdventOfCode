namespace AdventOfCode02
{
    public interface IProcessor
    {
        long Input { get; }
        long Output { get; set; }
        long ReadMemory(long index);
        long ReadMemory(IParameter index);
        void WriteMemory(IParameter index, long value);
    }
}

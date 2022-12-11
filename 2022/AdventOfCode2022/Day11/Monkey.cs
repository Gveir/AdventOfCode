namespace AdventOfCode2022.Day11
{
    internal class Monkey
    {
        public IList<ulong> Items { get; private set; }
        public IOperation Operation { get; private set; }
        public Test Test { get; private set; }
        public uint InspectionsCount { get; set; } = 0;

        public Monkey(List<ulong> items, IOperation operation, Test test)
        {
            Items = items;
            Operation = operation;
            Test = test;
        }
    }
}

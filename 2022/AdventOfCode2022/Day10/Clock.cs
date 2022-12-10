namespace AdventOfCode2022.Day10
{
    internal class Clock
    {
        private Cpu _cpu;
        private Crt _crt;

        public Clock(Cpu cpu, Crt crt)
        {
            _cpu = cpu;
            _crt = crt;
        }

        public void Tick()
        {
            _cpu.BeginExecutingInstruction();
            _crt.Tick();
            _cpu.FinishExecutingInstruction();
        }
    }
}

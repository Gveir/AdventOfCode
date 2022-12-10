namespace AdventOfCode2022.Day10
{
    public class Crt
    {
        private const int LineLength = 40;
        private Cpu _cpu;
        private string _imageFrame = string.Empty;
        private int _currentPosition = 0;

        public string[] ImageFrame => _imageFrame.Split(LineLength).ToArray();

        public Crt(Cpu cpu)
        {
            _cpu = cpu;
        }

        internal void Tick()
        {
            char pixel = (_currentPosition >= _cpu.RegisterX - 1 && _currentPosition <= _cpu.RegisterX + 1) ? '#' : '.';

            _imageFrame += pixel;
            _currentPosition = ++_currentPosition % LineLength;
        }
    }
}

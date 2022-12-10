namespace AdventOfCode2022.Day10
{
    public class Device
    {
        private Clock _clock;
        private Crt _crt;

        public Crt Crt => _crt;

        public Device(string[] inputProgram)
        {
            var cpu = new Cpu(inputProgram);
            _crt = new Crt(cpu);
            _clock = new Clock(cpu, _crt);
        }

        public void ProduceImageFrame()
        {
            int pixelsInFrame = 240;

            while (pixelsInFrame-- > 0)
            {
                _clock.Tick();
            }
        }
    }
}

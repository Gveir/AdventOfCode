namespace AdventOfCode2022.Day10
{
    public class Cpu
    {
        private string[] _program;
        private IList<int> _registerHistory = new List<int>();
        private int _currentInstruction = 0;
        private bool _keepProcessingOnNextTick = false;
        private int _registerXNewValueToApplyOnFinish;

        public int RegisterX { get; private set; } = 1;

        public static int CalculateSignalsStrengthsSum(string[] input, int[] cyclesToSum)
        {
            var cpu = new Cpu(input);

            cpu.ProcessInstructions();

            return cyclesToSum.Select(c => cpu._registerHistory[c - 1] * c).Sum();
        }
        public Cpu(string[] program)
        {
            _program = program;
        }

        internal void BeginExecutingInstruction()
        {
            var instruction = _program[_currentInstruction];
            _registerXNewValueToApplyOnFinish = RegisterX;

            if (instruction == "noop")
            {
                _currentInstruction++;
                _registerHistory.Add(RegisterX);
                _keepProcessingOnNextTick = false;
                return;
            }

            if (!_keepProcessingOnNextTick)
            {
                _registerHistory.Add(RegisterX);
                _keepProcessingOnNextTick = true;
                return;
            }

            _currentInstruction++;
            _keepProcessingOnNextTick = false;
            _registerHistory.Add(RegisterX);
            var addValue = int.Parse(instruction.Split(' ')[1]);
            _registerXNewValueToApplyOnFinish += addValue;
        }

        internal void FinishExecutingInstruction()
        {
            RegisterX = _registerXNewValueToApplyOnFinish;
        }

        internal void ProcessInstructions()
        {
            while (_currentInstruction < _program.Length)
            {
                BeginExecutingInstruction();
                FinishExecutingInstruction();
            }
        }
    }
}

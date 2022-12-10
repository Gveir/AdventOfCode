namespace AdventOfCode2022.Day10
{
    public class Cpu
    {
        private int _x = 1;
        private IList<int> _registerHistory = new List<int>();

        public static int CalculateSignalsStrengthsSum(string[] input, int[] cyclesToSum)
        {
            var cpu = new Cpu();

            cpu.ProcessInstructions(input);

            return cyclesToSum.Select(c => cpu._registerHistory[c - 1] * c).Sum();
        }

        private void ProcessInstructions(string[] input)
        {
            foreach (var instruction in input)
            {
                _registerHistory.Add(_x);
                if (instruction == "noop")
                {
                    continue;
                }

                _registerHistory.Add(_x);
                var addValue = int.Parse(instruction.Split(' ')[1]);
                _x += addValue;
            }
        }
    }
}

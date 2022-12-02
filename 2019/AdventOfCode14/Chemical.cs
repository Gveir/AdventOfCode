namespace AdventOfCode14
{
    public class Chemical
    {
        public static readonly Chemical Fuel = new Chemical("FUEL");
        public static readonly Chemical Ore = new Chemical("ORE");

        private string _name;

        public Chemical(string name)
        {
            _name = name;
        }

        public override string ToString() => _name;

        public override bool Equals(object obj) => obj is Chemical chemical && _name.Equals(chemical._name);

        public override int GetHashCode() => _name.GetHashCode();
    }
}

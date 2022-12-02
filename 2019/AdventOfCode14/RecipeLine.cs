using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode14
{
    public class RecipeLine
    {
        public IEnumerable<Ingredient> Inputs { get; }
        public Ingredient Output { get; }

        public RecipeLine(IEnumerable<Ingredient> inputs, Ingredient output)
        {
            Inputs = inputs;
            Output = output;
        }

        public override string ToString() => $"{string.Join(", ", Inputs)} => {Output}";

        public static RecipeLine Create(string line)
        {
            var lineParts = line.Split(" => ");

            return new RecipeLine(lineParts[0].Split(',').Select(Ingredient.Create), Ingredient.Create(lineParts[1]));
        }
    }
}

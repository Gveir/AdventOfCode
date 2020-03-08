namespace AdventOfCode14
{
    public class Ingredient
    {
        public Chemical Chemical { get; }
        public int Amount { get; }

        private Ingredient(int amount, Chemical chemical)
        {
            Amount = amount;
            Chemical = chemical;
        }

        public override string ToString() => $"{Amount} {Chemical}";

        public static Ingredient Create(string ingredient)
        {
            var ingredientParts = ingredient.Trim().Split(' ');

            return new Ingredient(int.Parse(ingredientParts[0]), new Chemical(ingredientParts[1]));
        }
    }
}

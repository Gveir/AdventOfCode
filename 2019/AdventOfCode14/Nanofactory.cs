using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode14
{
    public class Nanofactory
    {
        private IEnumerable<RecipeLine> _recipeLines;

        private RecipeLine FuelOuputLine => _recipeLines.GetForOutputChemical(Chemical.Fuel);

        public Nanofactory(string fileName)
        {
            var recipeFile = File.ReadAllText(fileName);

            _recipeLines = recipeFile.Split(Environment.NewLine).Select(RecipeLine.Create);
        }

        public long MinimumOreForOneFuel()
        {
            return MinimumOreForFuel(1);
        }

        public long MinimumOreForFuel(long requiredFuel)
        {
            var products = new Dictionary<Chemical, (long Required, long AmountToProduce, long Leftover)>();
            products.Add(Chemical.Fuel, (requiredFuel, requiredFuel, 0)); 
            products.Add(Chemical.Ore, (0, 0, 0));
            foreach (var line in _recipeLines.Where(l => !l.IsForOutputChemical(Chemical.Fuel)))
            {
                products.Add(line.Output.Chemical, (0, 0, 0));
            }

            var linesToProcess = new List<RecipeLine> { FuelOuputLine };

            while (linesToProcess.Any())
            {
                var linesToProcessInNextStep = new List<RecipeLine>();

                foreach (var line in linesToProcess)
                {
                    var (outputRequiredSoFar, outputAmountToProduce, outputLeftoverSoFar) = products[line.Output.Chemical];
                    var numberOfReactionsRequired = (long)Math.Ceiling((decimal)(outputAmountToProduce - outputLeftoverSoFar) / line.Output.Amount);
                    var producedOutput = numberOfReactionsRequired * line.Output.Amount;
                    products[line.Output.Chemical] = (outputRequiredSoFar, 0, producedOutput - outputAmountToProduce + outputLeftoverSoFar);

                    foreach (var ingredient in line.Inputs)
                    {
                        var (requiredSoFar, amountToProduce, leftoverSoFar) = products[ingredient.Chemical]; 
                        var requiredInputAmount = ingredient.Amount * numberOfReactionsRequired;
                        products[ingredient.Chemical] = (requiredSoFar + requiredInputAmount, amountToProduce + requiredInputAmount, leftoverSoFar);

                        if (!ingredient.Chemical.Equals(Chemical.Ore))
                        {
                            linesToProcessInNextStep.Add(_recipeLines.GetForOutputChemical(ingredient.Chemical));
                        }
                    }
                }
                linesToProcess = linesToProcessInNextStep;
            }

            return products[Chemical.Ore].Required;
        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode01
{
    public class FuelCalculator
    {
        public static long CalculateFuelRequirement(long mass)
        {
            return Convert.ToInt32(Math.Floor(mass / 3.0)) - 2;
        }

        public static long CalculateModuleFuelRequirementIncludingTheFuelMass(int mass)
        {
            long moduleFuelRequirement = CalculateFuelRequirement(mass);

            long fuelMassFuelRequirement = CalculateFuelRequirement(moduleFuelRequirement);
            long overallFuelMassFuelRequirement = 0;

            while (fuelMassFuelRequirement > 0)
            {
                overallFuelMassFuelRequirement += Math.Max(fuelMassFuelRequirement, 0);
                fuelMassFuelRequirement = CalculateFuelRequirement(fuelMassFuelRequirement);
            }


            return moduleFuelRequirement + overallFuelMassFuelRequirement;
        }

        public static long CalculateSpacecraftFuelRequirement(IEnumerable<int> modulesMasses)
        {
            return modulesMasses.Sum(moduleMass => CalculateFuelRequirement(moduleMass));
        }

        public static long CalculateSpacecraftFuelRequirementIncludingFuelMass(IEnumerable<int> modulesMasses)
        {
            return modulesMasses.Sum(moduleMass => CalculateModuleFuelRequirementIncludingTheFuelMass(moduleMass));
        }
    }
}

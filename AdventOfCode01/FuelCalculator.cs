using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode01
{
    public class FuelCalculator
    {
        public static long CalculateModuleFuelRequirement(int mass)
        {
            return Convert.ToInt32(Math.Floor(mass / 3.0)) - 2;
        }

        public static long CalculateSpacecraftFuelRequirement(IEnumerable<int> modulesMasses)
        {
            return modulesMasses.Sum(moduleMass => CalculateModuleFuelRequirement(moduleMass));
        }
    }
}

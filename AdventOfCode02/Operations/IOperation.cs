using System;
using System.Collections.Generic;

namespace AdventOfCode02.Operations
{
    internal interface IOperation
    {
        void Apply(long[] memory);
    }
}

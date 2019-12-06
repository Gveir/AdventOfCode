using System;
using System.Collections.Generic;

namespace AdventOfCode02.Operations
{
    internal enum Opcode
    {
        ADDITION = 1,
        MULTIPLICATION = 2,
        FINISH = 99,
    }
    internal static class OperationsFactory
    {
        public static IEnumerable<IOperation> CreateOperationsStream(long[] memory)
        {
            int index = 0;

            while (true)
            {
                var opcode = (Opcode)memory[index];
                
                switch (opcode)
                {
                    case Opcode.ADDITION:
                        yield return new Addition(
                            new Parameter(memory[index + 1]),
                            new Parameter(memory[index + 2]),
                            new Parameter(memory[index + 3], ParameterMode.Immediate)
                        );
                        index += 4;
                        break;
                    case Opcode.MULTIPLICATION:
                        yield return new Multiplication(
                            new Parameter(memory[index + 1]),
                            new Parameter(memory[index + 2]),
                            new Parameter(memory[index + 3], ParameterMode.Immediate)
                        );
                        index += 4;
                        break;
                    case Opcode.FINISH:
                        yield break;
                    default:
                        throw new InvalidOperationException($"Unrecognized operation opcode: {opcode}");
                }
            }
        }
    }
}

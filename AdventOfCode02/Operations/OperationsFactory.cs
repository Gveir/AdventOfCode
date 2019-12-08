using System;
using System.Collections.Generic;

namespace AdventOfCode02.Operations
{
    internal enum Opcode
    {
        ADDITION = 1,
        MULTIPLICATION = 2,
        INPUT = 3,
        OUTPUT = 4,
        FINISH = 99,
    }
    internal static class OperationsFactory
    {
        public static IEnumerable<IOperation> CreateOperationsStream(IProcessor processor)
        {
            int index = 0;

            while (true)
            {
                var opcode = (Opcode)processor.ReadMemory(index);
                
                switch (opcode)
                {
                    case Opcode.ADDITION:
                        yield return new Addition(
                            new Parameter(processor.ReadMemory(index + 1)),
                            new Parameter(processor.ReadMemory(index + 2)),
                            new StoreIndex(processor.ReadMemory(index + 3))
                        );
                        index += 4;
                        break;
                    case Opcode.MULTIPLICATION:
                        yield return new Multiplication(
                            new Parameter(processor.ReadMemory(index + 1)),
                            new Parameter(processor.ReadMemory(index + 2)),
                            new StoreIndex(processor.ReadMemory(index + 3))
                        );
                        index += 4;
                        break;
                    case Opcode.INPUT:
                        yield return new Input(
                            new StoreIndex(processor.ReadMemory(index + 1))
                        );
                        index += 2;
                        break;
                    case Opcode.OUTPUT:
                        yield return new Output(
                            new StoreIndex(processor.ReadMemory(index + 1))
                        );
                        index += 2;
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

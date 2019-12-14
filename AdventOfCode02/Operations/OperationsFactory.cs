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
        JUMP_IF_TRUE = 5,
        JUMP_IF_FALSE = 6,
        LESS_THAN = 7,
        EQUALS = 8,
        FINISH = 99,
    }

    internal static class OperationsFactory
    {
        private class ParamModes
        {
            private readonly IEnumerator<ParameterMode> _modesEnumerator;

            public ParamModes(long opcodeFull)
            {
                _modesEnumerator = GetParameterModes(opcodeFull).GetEnumerator();
            }

            private IEnumerable<ParameterMode> GetParameterModes(long opcodeFull)
            {
                var paramModes = opcodeFull / 100;

                while (true)
                {
                    yield return (ParameterMode)(paramModes % 10);
                    paramModes /= 10;
                }
            }

            public ParameterMode GetNext()
            {
                return _modesEnumerator.MoveNext() ? _modesEnumerator.Current : ParameterMode.Immediate;
            }
        }

        public static IEnumerable<IOperation> CreateOperationsStream(IReadOnlyProcessor processor)
        {
            while (true)
            {
                var opcodeFull = processor.ReadMemory(0);
                var opcode = (Opcode)(opcodeFull % 100);
                var paramModes = new ParamModes(opcodeFull);

                switch (opcode)
                {
                    case Opcode.ADDITION:
                        yield return new Addition(
                            new Parameter(processor.ReadMemory(1), paramModes.GetNext()),
                            new Parameter(processor.ReadMemory(2), paramModes.GetNext()),
                            new StoreIndex(processor.ReadMemory(3))
                        );
                        break;
                    case Opcode.MULTIPLICATION:
                        yield return new Multiplication(
                            new Parameter(processor.ReadMemory(1), paramModes.GetNext()),
                            new Parameter(processor.ReadMemory(2), paramModes.GetNext()),
                            new StoreIndex(processor.ReadMemory(3))
                        );
                        break;
                    case Opcode.INPUT:
                        yield return new Input(
                            new StoreIndex(processor.ReadMemory(1))
                        );
                        break;
                    case Opcode.OUTPUT:
                        yield return new Output(
                            new Parameter(processor.ReadMemory(1), paramModes.GetNext())
                        );
                        yield break;
                    case Opcode.JUMP_IF_TRUE:
                        yield return new JumpIfTrue(
                            new Parameter(processor.ReadMemory(1), paramModes.GetNext()),
                            new Parameter(processor.ReadMemory(2), paramModes.GetNext())
                        );
                        break;
                    case Opcode.JUMP_IF_FALSE:
                        yield return new JumpIfFalse(
                            new Parameter(processor.ReadMemory(1), paramModes.GetNext()),
                            new Parameter(processor.ReadMemory(2), paramModes.GetNext())
                        );
                        break;
                    case Opcode.LESS_THAN:
                        yield return new LessThan(
                            new Parameter(processor.ReadMemory(1), paramModes.GetNext()),
                            new Parameter(processor.ReadMemory(2), paramModes.GetNext()),
                            new StoreIndex(processor.ReadMemory(3))
                        );
                        break;
                    case Opcode.EQUALS:
                        yield return new Equals(
                            new Parameter(processor.ReadMemory(1), paramModes.GetNext()),
                            new Parameter(processor.ReadMemory(2), paramModes.GetNext()),
                            new StoreIndex(processor.ReadMemory(3))
                        );
                        break;
                    case Opcode.FINISH:
                        yield return new Finish();
                        yield break;
                    default:
                        throw new InvalidOperationException($"Unrecognized operation opcode: {opcode}");
                }
            }
        }

        
    }
}

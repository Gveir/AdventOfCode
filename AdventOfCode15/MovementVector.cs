using System;
using System.Collections.Generic;

namespace AdventOfCode15
{
    public static class MovementVector
    {
        private static Dictionary<MovementCommand, Func<(int X, int Y), (int X, int Y)>> _vectors = new Dictionary<MovementCommand, Func<(int X, int Y), (int X, int Y)>>
        {
            {MovementCommand.North, position => (position.X, position.Y + 1) },
            {MovementCommand.South, position => (position.X, position.Y - 1) },
            {MovementCommand.West, position => (position.X - 1, position.Y) },
            {MovementCommand.East, position => (position.X + 1, position.Y) }
        };

        public static IReadOnlyDictionary<(int X, int Y), MovementCommand> Directions = new Dictionary<(int, int), MovementCommand>
        {
            { (1, 0), MovementCommand.East },
            { (-1, 0), MovementCommand.West },
            { (0, 1), MovementCommand.North },
            { (0, -1), MovementCommand.South },
        };

        public static (int X, int Y) Calculate(this (int X, int Y) position, MovementCommand command) => _vectors[command](position);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode15
{
    public class MovementCommand
    {
        public static MovementCommand North { get; } = new MovementCommand(1, position => (position.X, position.Y + 1));
        public static MovementCommand South { get; } = new MovementCommand(2, position => (position.X, position.Y - 1));
        public static MovementCommand West { get; } = new MovementCommand(3, position => (position.X - 1, position.Y));
        public static MovementCommand East { get; } = new MovementCommand(4, position => (position.X + 1, position.Y));
        public static IEnumerable<MovementCommand> All { get; } = new[] { North, South, West, East };

        private static IDictionary<MovementCommand, MovementCommand> _opossiteCommands = new Dictionary<MovementCommand, MovementCommand>
        {
            { North, South }, { South, North }, { West, East }, { East, West }
        };

        private readonly Func<(int X, int Y), (int X, int Y)> _updateFunc;
        private readonly long _commandId;

        public MovementCommand Opposite => _opossiteCommands[this];

        private MovementCommand(long commandId, Func<(int X, int Y), (int X, int Y)> updateFunc)
        {
            _commandId = commandId;
            _updateFunc = updateFunc;
        }

        public (int X, int Y) Apply((int X, int Y) p) => _updateFunc(p);
        public static IEnumerable<MovementCommand> AllExcept(MovementCommand command) => All.Except(new[] { command });

        public static implicit operator long(MovementCommand c) => c._commandId;
        public static explicit operator MovementCommand(long id)
        {
            var command = All.SingleOrDefault(c => c._commandId == id);

            if (command == null)
            {
                throw new ArgumentOutOfRangeException($"{nameof(MovementCommand)} must be within range from 1 to 4.");
            }

            return command;
        }
    }
}

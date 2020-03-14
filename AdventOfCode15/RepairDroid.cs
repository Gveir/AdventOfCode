using AdventOfCode02;
using System;
using System.Collections.Generic;

namespace AdventOfCode15
{
    public class RepairDroid
    {
        private readonly Intcode _processor;
        
        public (int X, int Y) Position { get; private set; }

        public RepairDroid(string program)
        {
            _processor = new Intcode(program);
            Position = (0, 0);
        }

        public StatusCode Move(MovementCommand command)
        {
            _processor.EnqueueInput((long)command);
            _processor.Process();
            StatusCode status = (StatusCode)_processor.Output;
            if (status == StatusCode.Moved)
            {
                Position = Position.Calculate(command);
            }
            return status;
        }
    }
}

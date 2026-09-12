using System;

namespace TurnBasedRPG.Source.Core.InputHandlers
{
    public abstract class InputHandler
    {
        public abstract bool handle(ConsoleKey inputKey);
    }
}

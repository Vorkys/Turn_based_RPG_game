using System;

namespace tahova_RPG_hra.Source.Core.InputHandlers
{
    public abstract class InputHandler
    {
        public abstract bool handle(ConsoleKey inputKey);
    }
}

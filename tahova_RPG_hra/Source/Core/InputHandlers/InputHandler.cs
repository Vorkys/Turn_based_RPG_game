using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace tahova_RPG_hra.Source.Core.InputHandlers
{
    abstract class InputHandler
    {
        public abstract bool handle(ConsoleKey inputKey);
    }
}

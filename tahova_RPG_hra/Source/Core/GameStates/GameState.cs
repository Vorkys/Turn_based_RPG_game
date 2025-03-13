using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Core.InputHandlers;

namespace tahova_RPG_hra.Source.Core.GameStates
{
    abstract class GameState
    {
        //TODO
        private InputHandler inputHandler;

        internal InputHandler InputHandler { get => inputHandler; set => inputHandler = value; }

        public abstract void Render();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Core.InputHandlers;

namespace tahova_RPG_hra.Source.Core.GameStates
{
    class MenuState : GameState
    {
        public MenuState()
        {
            InputHandler = new MenuHandler();
        }

        public override void Render()
        {
            throw new NotImplementedException();
        }
    }

    class PauseState : GameState
    {
        public PauseState()
        {
            InputHandler = new MenuHandler();
        }

        public override void Render()
        {
            throw new NotImplementedException();
        }
    }

    class ExplorationState : GameState
    {
        public ExplorationState()
        {
            InputHandler = new MenuHandler();
        }

        public override void Render()
        {
            throw new NotImplementedException();
        }
    }

    class CombatState : GameState
    {
        public CombatState()
        {
            InputHandler = new MenuHandler();
        }

        public override void Render()
        {
            throw new NotImplementedException();
        }
    }

    class DialogState : GameState
    {
        public DialogState()
        {
            InputHandler = new MenuHandler();
        }

        public override void Render()
        {
            throw new NotImplementedException();
        }
    }

    class InventoryState : GameState
    {
        public InventoryState()
        {
            InputHandler = new MenuHandler();
        }

        public override void Render()
        {
            throw new NotImplementedException();
        }
    }
}

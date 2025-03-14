using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Core.InputHandlers;
using tahova_RPG_hra.Source.Entities;

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
        private Enemy enemy;

        public CombatState(Enemy enemy)
        {
            InputHandler = new MenuHandler();
            Enemy = enemy;
        }

        internal Enemy Enemy { get => enemy; set => enemy = value; }

        public override void Render()
        {
            throw new NotImplementedException();
        }
    }

    class DialogState : GameState
    {
        private List<string> dialog;

        public DialogState(List<string> dialog)
        {
            InputHandler = new MenuHandler();
            Dialog = dialog;
        }

        public List<string> Dialog { get => dialog; set => dialog = value; }

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

    class JournalState : GameState
    {
        public JournalState()
        {
            InputHandler = new JournalHandler();
        }

        public override void Render()
        {
            throw new NotImplementedException();
        }
    }

    class TownState : GameState
    {
        public TownState()
        {
            InputHandler = new TownHandler();
        }

        public override void Render()
        {
            throw new NotImplementedException();
        }
    }

    class TradingState : GameState
    {
        public TradingState()
        {
            InputHandler = new TradingHandler();
        }

        public override void Render()
        {
            throw new NotImplementedException();
        }
    }
}

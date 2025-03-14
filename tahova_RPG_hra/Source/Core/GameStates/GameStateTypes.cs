using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Core.InputHandlers;
using tahova_RPG_hra.Source.Utils;
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
            InputHandler = new PauseHandler();
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
            InputHandler = new ExplorationHandler();
        }

        public override void Render()
        {
            for (int x = 0; x < GlobalConstants.consoleSizeY; x++)
            {
                if (x == 0 || x + 1 == 35 || x + 1 == GlobalConstants.consoleSizeY)
                {
                    Console.Write(new string('=', GlobalConstants.consoleSizeX));
                    continue;
                }

                for (int y = 0; y < GlobalConstants.consoleSizeX; y++)
                {
                    //border
                    if (y == 0 || y + 1 == GlobalConstants.consoleSizeX)
                        Console.Write("H");
                    //player pos
                    else if (x == Game.Instance.Maps[Game.Instance.ActiveMap].PlayerX && y == Game.Instance.Maps[Game.Instance.ActiveMap].PlayerY)
                    {
                        Console.Write("P");
                    }
                    //print map node
                    else if ((Game.Instance.Maps[Game.Instance.ActiveMap].PlayerY - y) >= 0 || (Game.Instance.Maps[Game.Instance.ActiveMap].PlayerY + y) < Game.Instance.Maps[Game.Instance.ActiveMap].Map.GetLength(1))
                    {
                        Game.Instance.Maps[Game.Instance.ActiveMap].Map[x, y].Write();
                    }
                    else
                        Console.Write(" ");
                }
            }
        }
    }

    class CombatState : GameState
    {
        private Enemy enemy;

        public CombatState(Enemy enemy)
        {
            InputHandler = new CombatHandler();
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
            InputHandler = new DialogHandler();
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
            InputHandler = new InventoryHandler();
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

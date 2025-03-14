using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Core.InputHandlers;
using tahova_RPG_hra.Source.Utils;

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
        public CombatState()
        {
            InputHandler = new CombatHandler();
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
            InputHandler = new DialogHandler();
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
            InputHandler = new InventoryHandler();
        }

        public override void Render()
        {
            throw new NotImplementedException();
        }
    }
}

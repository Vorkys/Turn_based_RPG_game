using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Core.GameStates;

namespace tahova_RPG_hra.Source.Core.InputHandlers
{
    class MenuHandler : InputHandler
    {
        public override void handle(ConsoleKey inputKey)
        {
            switch (inputKey) 
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    break;
                case ConsoleKey.Spacebar:
                case ConsoleKey.Enter:
                    break;
            }
        }
    }

    class PauseHandler : InputHandler
    {
        public override void handle(ConsoleKey inputKey)
        {
            switch (inputKey)
            {
                case ConsoleKey.Escape:
                    Game.Instance.Pause();
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    break;
                case ConsoleKey.Spacebar:
                case ConsoleKey.Enter:
                    break;
            }
        }
    }

    class ExplorationHandler : InputHandler
    {
        public override void handle(ConsoleKey inputKey)
        {
            switch (inputKey)
            {
                case ConsoleKey.Escape:
                    Game.Instance.Pause();
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    break;
                case ConsoleKey.Spacebar:
                case ConsoleKey.Enter:
                    break;
            }
        }
    }

    class CombatHandler : InputHandler
    {
        public override void handle(ConsoleKey inputKey)
        {
            switch (inputKey)
            {
                case ConsoleKey.Escape:
                    Game.Instance.Pause();
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    break;
                case ConsoleKey.Spacebar:
                case ConsoleKey.Enter:
                    break;
            }
        }
    }

    class DialogHandler : InputHandler
    {
        public override void handle(ConsoleKey inputKey)
        {
            switch (inputKey)
            {
                case ConsoleKey.Spacebar:
                case ConsoleKey.Enter:
                    break;
            }
        }
    }

    class InventoryHandler : InputHandler
    {
        public override void handle(ConsoleKey inputKey)
        {
            switch (inputKey)
            {
                case ConsoleKey.Escape:
                    Game.Instance.ChangeState(GameStateType.Exploration);
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    break;
                case ConsoleKey.Spacebar:
                case ConsoleKey.Enter:
                    break;
            }
        }
    }
}

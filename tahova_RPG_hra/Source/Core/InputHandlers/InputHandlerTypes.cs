using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using tahova_RPG_hra.Source.Core.GameStates;
using tahova_RPG_hra.Source.Entities;
using tahova_RPG_hra.Source.Managers;

namespace tahova_RPG_hra.Source.Core.InputHandlers
{
    class MenuHandler : InputHandler
    {
        public override bool handle(ConsoleKey inputKey)
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
                default:
                    return false;
            }

            return true;
        }
    }

    class PauseHandler : InputHandler
    {
        public override bool handle(ConsoleKey inputKey)
        {
            switch (inputKey)
            {
                case ConsoleKey.Escape:
                    Game.Instance.Resume();
                        break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    break;
                case ConsoleKey.Spacebar:
                case ConsoleKey.Enter:
                    break;
                default:
                    return false;
            }

            return true;
        }
    }

    class ExplorationHandler : InputHandler
    {
        public override bool handle(ConsoleKey inputKey)
        {
            switch (inputKey)
            {
                case ConsoleKey.Escape:
                    Game.Instance.Pause();
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    Game.Instance.MovePlayerUp();
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    Game.Instance.MovePlayerDown();
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    Game.Instance.MovePlayerLeft();
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    Game.Instance.MovePlayerRight();
                    break;
                case ConsoleKey.Spacebar:
                case ConsoleKey.Enter:
                    Game.Instance.startCombat(EntityManager.SmallGoblin);
                    break;
                default:
                    return false;
            }

            return true;
        }
    }

    class CombatHandler : InputHandler
    {
        public override bool handle(ConsoleKey inputKey)
        {
            switch (inputKey)
            {
                case ConsoleKey.Escape:
                    if (Game.Instance.GameState is CombatState)
                    {
                        CombatState castGameState = (CombatState)Game.Instance.GameState;

                        if (!castGameState.ToConfirmAction)
                            Game.Instance.Pause();
                    }
                    break;
                //Enemy attack
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    if (Game.Instance.GameState is CombatState)
                    {
                        CombatState castGameState = (CombatState)Game.Instance.GameState;

                        if (castGameState.ToConfirmAction)
                            return false;
                        else
                        {
                            if (Game.Instance.Player.Target is Enemy)
                            {
                                Enemy castTarget = (Enemy)Game.Instance.Player.Target;
                                castTarget.ChooseMove();
                            }
                        }
                    }
                    break;
                //Player attack
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    if (Game.Instance.GameState is CombatState)
                    {
                        CombatState castGameState = (CombatState)Game.Instance.GameState;

                        if (castGameState.ToConfirmAction)
                            return false;
                        else
                        {
                            if (Game.Instance.Player.Target is Enemy)
                            {
                                Enemy castTarget = (Enemy)Game.Instance.Player.Target;
                                castTarget.ReduceHealth(1);

                                if (castTarget.Health <= 0)
                                    castTarget.Defeated();
                            }
                        }
                    }
                    break;
                case ConsoleKey.Spacebar:
                case ConsoleKey.Enter:
                    //if (Game.Instance.GameState is CombatState)
                    //{
                    //    CombatState castGameState = (CombatState)Game.Instance.GameState;

                    //    if (castGameState.ToConfirmAction)
                    //        return false;
                    //}
                    break;
                default:
                    return false;
            }

            return true;
        }
    }

    class DialogHandler : InputHandler
    {
        public override bool handle(ConsoleKey inputKey)
        {
            switch (inputKey)
            {
                case ConsoleKey.Escape:
                case ConsoleKey.Spacebar:
                case ConsoleKey.Enter:
                    break;
                default:
                    return false;
            }

            return true;
        }
    }

    class InventoryHandler : InputHandler
    {
        public override bool handle(ConsoleKey inputKey)
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
                default:
                    return false;
            }

            return true;
        }
    }

    class JournalHandler : InputHandler
    {
        public override bool handle(ConsoleKey inputKey)
        {
            switch (inputKey)
            {
                case ConsoleKey.Escape:
                    Game.Instance.ChangeState(GameStateType.Exploration);
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    break;
                case ConsoleKey.Spacebar:
                case ConsoleKey.Enter:
                    break;
                default:
                    return false;
            }

            return true;
        }
    }

    class TownHandler : InputHandler
    {
        public override bool handle(ConsoleKey inputKey)
        {
            switch (inputKey)
            {
                case ConsoleKey.Escape:
                    Game.Instance.ChangeState(GameStateType.Exploration);
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    break;
                case ConsoleKey.Spacebar:
                case ConsoleKey.Enter:
                    break;
                default:
                    return false;
            }

            return true;
        }
    }

    class TradingHandler : InputHandler
    {
        public override bool handle(ConsoleKey inputKey)
        {
            switch (inputKey)
            {
                case ConsoleKey.Escape:
                    Game.Instance.ChangeState(GameStateType.Exploration);
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    break;
                case ConsoleKey.Spacebar:
                case ConsoleKey.Enter:
                    break;
                default:
                    return false;
            }

            return true;
        }
    }
}

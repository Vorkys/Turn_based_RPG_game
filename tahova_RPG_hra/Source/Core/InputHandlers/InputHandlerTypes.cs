using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using tahova_RPG_hra.Source.Core.GameStates;
using tahova_RPG_hra.Source.Entities;
using tahova_RPG_hra.Source.GameObjects.Items.ItemTypes;
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
                case ConsoleKey.Q:
                    Game.Instance.Player.IncreaseLvl();
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

                        if (castGameState.ShowSpells)
                            castGameState.ShowSpells = false;
                        else if (castGameState.ShowItems)
                            castGameState.ShowItems = false;
                        else if (!castGameState.ToConfirmDialog)
                            Game.Instance.Pause();
                    }
                    break;
                //Normal attack from Player
                case ConsoleKey.Q:                    
                    if (Game.Instance.GameState is CombatState)
                    {
                        CombatState castGameState = (CombatState)Game.Instance.GameState;

                        if (!castGameState.ToConfirmDialog && !castGameState.ShowSpells && !castGameState.ShowItems)
                            Game.Instance.Player.AttackTarget(Game.Instance.Player.Damage);
                        else
                            return false;
                    }
                    break;
                //Open Spell menu
                case ConsoleKey.W:
                    if (Game.Instance.GameState is CombatState)
                    {
                        CombatState castGameState = (CombatState)Game.Instance.GameState;

                        if (!castGameState.ToConfirmDialog && !castGameState.ShowSpells && !castGameState.ShowItems)
                            castGameState.ShowSpells = true;
                        else
                            return false;
                    }
                    break;
                //Open Item menu
                case ConsoleKey.E:
                    if (Game.Instance.GameState is CombatState)
                    {
                        CombatState castGameState = (CombatState)Game.Instance.GameState;

                        if (!castGameState.ToConfirmDialog && !castGameState.ShowSpells && !castGameState.ShowItems)
                            castGameState.ShowItems = true;
                        else
                            return false;
                    }
                    break;
                //TODO - DEBUG enemy attack
                case ConsoleKey.UpArrow:
                    if (Game.Instance.GameState is CombatState)
                    {
                        CombatState castGameState = (CombatState)Game.Instance.GameState;

                        if (castGameState.ToConfirmDialog || castGameState.ShowSpells || castGameState.ShowItems)
                            return false;
                        else
                        {
                            if (Game.Instance.Player.Target is Enemy)
                            {
                                Enemy castTarget = (Enemy)Game.Instance.Player.Target;
                                castTarget.ChooseMove();
                                if (Game.Instance.Player.Health <= 0)
                                    Game.Instance.GameOver();
                            }
                        }
                    }
                    break;
                //TODO - DEBUG player attack
                case ConsoleKey.DownArrow:
                    if (Game.Instance.GameState is CombatState)
                    {
                        CombatState castGameState = (CombatState)Game.Instance.GameState;

                        if (castGameState.ToConfirmDialog || castGameState.ShowSpells || castGameState.ShowItems)
                            return false;
                        else
                        {
                            if (Game.Instance.Player.Target is Enemy)
                            {
                                Enemy castTarget = (Enemy)Game.Instance.Player.Target;
                                castTarget.AttackTarget(1);
                            }
                        }
                    }
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    if (Game.Instance.GameState is CombatState)
                    {
                        CombatState castGameState = (CombatState)Game.Instance.GameState;

                        if (!castGameState.ToConfirmDialog && castGameState.ShowSpells)
                            castGameState.PreviousElement();
                        else if (!castGameState.ToConfirmDialog && castGameState.ShowItems)
                            castGameState.PreviousElement();
                        else
                            return false;
                    }
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    if (Game.Instance.GameState is CombatState)
                    {
                        CombatState castGameState = (CombatState)Game.Instance.GameState;

                        if (!castGameState.ToConfirmDialog && castGameState.ShowSpells)
                            castGameState.NextElement();
                        else if (!castGameState.ToConfirmDialog && castGameState.ShowItems)
                            castGameState.NextElement();
                        else
                            return false;
                    }
                    break;
                case ConsoleKey.Spacebar:
                case ConsoleKey.Enter:
                    if (Game.Instance.GameState is CombatState)
                    {
                        CombatState castGameState = (CombatState)Game.Instance.GameState;

                        if (castGameState.ShowSpells && Game.Instance.Player.Spells.Count > 0)
                            Game.Instance.Player.Spells[castGameState.ListElementId].Cast();
                        else if (castGameState.ShowItems && Game.Instance.Player.Inventory[castGameState.ListElementId] is Consumable)
                            Game.Instance.Player.Inventory[castGameState.ListElementId].Use();
                        else if (!castGameState.ToConfirmDialog)
                            return false;
                    }
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

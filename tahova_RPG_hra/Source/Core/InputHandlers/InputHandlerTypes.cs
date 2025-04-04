﻿using System;
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
                //TODO - DEBUG add player lvl for spells
                //case ConsoleKey.Q:
                //    Game.Instance.Player.IncreaseLvl(2);
                //    break;
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
                //Close/Cancel action or menu
                case ConsoleKey.Escape:
                    if (Game.Instance.GameState is CombatState)
                    {
                        CombatState castGameState = (CombatState)Game.Instance.GameState;

                        if (castGameState.ShowSpells)
                        {
                            castGameState.ShowSpells = false;
                            castGameState.ListElementId = 0;
                        }
                        else if (castGameState.ShowItems)
                        {
                            castGameState.ShowItems = false;
                            castGameState.ListElementId = 0;
                        }
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
                        {
                            Game.Instance.Player.AttackTarget(Game.Instance.Player.Damage);

                            //Check if target is still alive
                            if (Game.Instance.Player.Target != null)
                            {
                                Enemy castEnemy = (Enemy)Game.Instance.Player.Target;
                                castEnemy.ChooseMove();
                            }
                        }
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
                ////TODO - DEBUG enemy attack
                //case ConsoleKey.UpArrow:
                //    if (Game.Instance.GameState is CombatState)
                //    {
                //        CombatState castGameState = (CombatState)Game.Instance.GameState;

                //        if (castGameState.ToConfirmDialog || castGameState.ShowSpells || castGameState.ShowItems)
                //            return false;
                //        else
                //        {
                //            Game.Instance.Player.ReduceHealth(1);

                //            if (Game.Instance.Player.Health <= 0)
                //                Game.Instance.GameOver();
                //        }
                //    }
                //    break;
                ////TODO - DEBUG player attack
                //case ConsoleKey.DownArrow:
                //    if (Game.Instance.GameState is CombatState)
                //    {
                //        CombatState castGameState = (CombatState)Game.Instance.GameState;

                //        if (castGameState.ToConfirmDialog || castGameState.ShowSpells || castGameState.ShowItems)
                //            return false;
                //        else
                //        {
                //            if (Game.Instance.Player.Target is Enemy)
                //            {
                //                Enemy castTarget = (Enemy)Game.Instance.Player.Target;
                //                castTarget.ReduceHealth(1);

                //                if (castTarget.Health <= 0)
                //                    castTarget.Defeated();
                //            }
                //        }
                //    }
                //    break;
                //Previous item of list when list is open
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    if (Game.Instance.GameState is CombatState)
                    {
                        CombatState castGameState = (CombatState)Game.Instance.GameState;

                        if (!castGameState.ToConfirmDialog && (castGameState.ShowSpells || castGameState.ShowItems))
                            castGameState.PreviousElement();
                        else
                            return false;
                    }
                    break;
                //Next item of list when list is open
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    if (Game.Instance.GameState is CombatState)
                    {
                        CombatState castGameState = (CombatState)Game.Instance.GameState;

                        if (!castGameState.ToConfirmDialog && (castGameState.ShowSpells || castGameState.ShowItems))
                            castGameState.NextElement();
                        else
                            return false;
                    }
                    break;
                //Confirm action
                case ConsoleKey.Spacebar:
                case ConsoleKey.Enter:
                    if (Game.Instance.GameState is CombatState)
                    {
                        CombatState castGameState = (CombatState)Game.Instance.GameState;

                        if (castGameState.ShowSpells && Game.Instance.Player.Spells.Count > 0)
                        {
                            Game.Instance.Player.Spells[castGameState.ListElementId].Cast();

                            //Check if target is still alive
                            if (Game.Instance.Player.Target != null)
                            {
                                Enemy castEnemy = (Enemy)Game.Instance.Player.Target;
                                castEnemy.ChooseMove();
                            }

                            //reset combat state
                            castGameState.ShowSpells = false;
                            castGameState.ShowItems = false;
                            castGameState.ListElementId = 0;
                            castGameState.CombatDialog = null;
                        }
                        else if (castGameState.ShowItems && Game.Instance.Player.Inventory[castGameState.ListElementId] is Consumable)
                        {
                            Game.Instance.Player.Inventory[castGameState.ListElementId].Use();

                            //Check if target is still alive
                            if (Game.Instance.Player.Target != null)
                            {
                                Enemy castEnemy = (Enemy)Game.Instance.Player.Target;
                                castEnemy.ChooseMove();
                            }

                            //reset combat state
                            castGameState.ShowSpells = false;
                            castGameState.ShowItems = false;
                            castGameState.ListElementId = 0;
                            castGameState.CombatDialog = null;
                        }
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
                //TODO - enemies are null when deserializing
                //case ConsoleKey.Q:
                //    EntityManager.Organisator.Talk();
                //    break;
                case ConsoleKey.W:
                    Game.Instance.Player.Health = Game.Instance.Player.MaxHealth;
                    Game.Instance.Player.Mana = Game.Instance.Player.MaxMana;
                    break;
                //TODO - not working
                //case ConsoleKey.E:
                //    Game.Instance.Save();
                //    break;
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

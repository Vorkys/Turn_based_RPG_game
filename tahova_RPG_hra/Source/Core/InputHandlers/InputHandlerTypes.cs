using System;
using tahova_RPG_hra.Source.Core.GameStates;
using tahova_RPG_hra.Source.Entities;
using tahova_RPG_hra.Source.GameObjects.Items.ItemTypes;
using tahova_RPG_hra.Source.Managers;
using static tahova_RPG_hra.Source.Core.GameStates.InventoryState;

namespace tahova_RPG_hra.Source.Core.InputHandlers
{
    class MenuHandler : InputHandler
    {
        public override bool handle(ConsoleKey inputKey)
        {
            MainMenuState castInstanceState = (MainMenuState)Game.Instance.GameState;

            switch (inputKey)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    return castInstanceState.PreviousSelection();
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    return castInstanceState.NextSelection();
                case ConsoleKey.Spacebar:
                case ConsoleKey.Enter:
                    switch (castInstanceState.CurrentState)
                    {
                        case (MainMenuState.MenuState.MainMenu):
                            switch (castInstanceState.SelectedOption)
                            {
                                case 0:
                                    Game.Instance.ChangeState(GameStateType.Exploration);
                                    break;
                                case 1:
                                    castInstanceState.CurrentState = MainMenuState.MenuState.ContinueMenu;
                                    castInstanceState.SelectedOption = 0;
                                    castInstanceState.RerenderMenu();
                                    break;
                                case 2:
                                    castInstanceState.CurrentState = MainMenuState.MenuState.HowToPlayMenu;
                                    castInstanceState.SelectedOption = 0;
                                    castInstanceState.RerenderMenu();
                                    break;
                                case 3:
                                    Environment.Exit(0);
                                    break;
                            }
                            break;
                        case (MainMenuState.MenuState.ContinueMenu):
                            //TODO - implement savefiles
                            throw new NotImplementedException();
                            break;
                        case (MainMenuState.MenuState.HowToPlayMenu):
                            return false;
                    }
                    break;
                case ConsoleKey.Escape:
                    switch (castInstanceState.CurrentState)
                    {
                        case (MainMenuState.MenuState.MainMenu):
                            return false;
                        case (MainMenuState.MenuState.ContinueMenu):
                            castInstanceState.CurrentState = MainMenuState.MenuState.MainMenu;
                            castInstanceState.SelectedOption = 0;
                            castInstanceState.RerenderMenu();
                            break;
                        case (MainMenuState.MenuState.HowToPlayMenu):
                            castInstanceState.CurrentState = MainMenuState.MenuState.MainMenu;
                            castInstanceState.SelectedOption = 0;
                            castInstanceState.RerenderMenu();
                            break;
                    }
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
                case ConsoleKey.I:
                    Game.Instance.ChangeState(GameStateType.Inventory);
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
            CombatState castInstanceState = (CombatState)Game.Instance.GameState;

            switch (inputKey)
            {
                //Close/Cancel action or menu
                case ConsoleKey.Escape:
                    switch (castInstanceState.CurrentState)
                    {
                        case CombatState.CombatDialogState.DefaultDialog:
                            Game.Instance.Pause();
                            break;
                        case CombatState.CombatDialogState.SpellDialog:
                            castInstanceState.CurrentState = CombatState.CombatDialogState.DefaultDialog;
                            castInstanceState.SelectedOption = 0;
                            castInstanceState.RerenderCombat();
                            break;
                        case CombatState.CombatDialogState.ItemDialog:
                            castInstanceState.CurrentState = CombatState.CombatDialogState.DefaultDialog;
                            castInstanceState.SelectedOption = 0;
                            castInstanceState.RerenderCombat();
                            break;
                        case CombatState.CombatDialogState.AwaitConfirmDialog:
                            return false;
                    }
                    break;
                //Normal attack from Player
                case ConsoleKey.Q:
                    switch (castInstanceState.CurrentState)
                    {
                        case CombatState.CombatDialogState.DefaultDialog:
                            Game.Instance.Player.AttackTarget(Game.Instance.Player.Damage);
                            castInstanceState.CurrentState = CombatState.CombatDialogState.AwaitConfirmDialog;
                            if (Game.Instance.Player.Target != null)
                                castInstanceState.RerenderCombat();
                            break;
                        case CombatState.CombatDialogState.SpellDialog:
                        case CombatState.CombatDialogState.ItemDialog:
                        case CombatState.CombatDialogState.AwaitConfirmDialog:
                            return false;
                    }
                    break;
                //Open Spell menu
                case ConsoleKey.W:
                    switch (castInstanceState.CurrentState)
                    {
                        case CombatState.CombatDialogState.DefaultDialog:
                            castInstanceState.CurrentState = CombatState.CombatDialogState.SpellDialog;
                            castInstanceState.SelectedOption = 0;
                            castInstanceState.RerenderCombat();
                            break;
                        case CombatState.CombatDialogState.SpellDialog:
                        case CombatState.CombatDialogState.ItemDialog:
                        case CombatState.CombatDialogState.AwaitConfirmDialog:
                            return false;
                    }
                    break;
                //Open Item menu
                case ConsoleKey.E:
                    switch (castInstanceState.CurrentState)
                    {
                        case CombatState.CombatDialogState.DefaultDialog:
                            castInstanceState.CurrentState = CombatState.CombatDialogState.ItemDialog;
                            castInstanceState.SelectedOption = 0;
                            castInstanceState.RerenderCombat();
                            break;
                        case CombatState.CombatDialogState.SpellDialog:
                        case CombatState.CombatDialogState.ItemDialog:
                        case CombatState.CombatDialogState.AwaitConfirmDialog:
                            return false;
                    }
                    break;
                //Previous item of list when list is open
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    switch (castInstanceState.CurrentState)
                    {
                        case CombatState.CombatDialogState.SpellDialog:
                        case CombatState.CombatDialogState.ItemDialog:
                            return castInstanceState.PreviousElement();
                        case CombatState.CombatDialogState.DefaultDialog:
                        case CombatState.CombatDialogState.AwaitConfirmDialog:
                            return false;
                    }
                    break;
                //Next item of list when list is open
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    switch (castInstanceState.CurrentState)
                    {
                        case CombatState.CombatDialogState.SpellDialog:
                        case CombatState.CombatDialogState.ItemDialog:
                            return castInstanceState.NextElement();
                    case CombatState.CombatDialogState.DefaultDialog:
                    case CombatState.CombatDialogState.AwaitConfirmDialog:
                            return false;
                    }
                    break;
                //Confirm action
                case ConsoleKey.Spacebar:
                case ConsoleKey.Enter:
                    switch (castInstanceState.CurrentState)
                    {
                        case CombatState.CombatDialogState.DefaultDialog:
                            return false;
                        case CombatState.CombatDialogState.SpellDialog:
                            if (Game.Instance.Player.Spells[castInstanceState.SelectedOption].Cost <= Game.Instance.Player.Mana)
                            {
                                Game.Instance.Player.Spells[castInstanceState.SelectedOption].Cast();
                                castInstanceState.CombatDialog = $"Player: casted {Game.Instance.Player.Spells[castInstanceState.SelectedOption].Name}";
                                castInstanceState.CurrentState = CombatState.CombatDialogState.AwaitConfirmDialog;
                                castInstanceState.SelectedOption = 0;
                                castInstanceState.RerenderCombat();
                            }
                            else
                                return false;
                            break;
                        case CombatState.CombatDialogState.ItemDialog:
                            if (Game.Instance.Player.Inventory[castInstanceState.SelectedOption] is Consumable)
                            {
                                Game.Instance.Player.Inventory[castInstanceState.SelectedOption].Use();
                                castInstanceState.CombatDialog = $"Player: used {Game.Instance.Player.Inventory[castInstanceState.SelectedOption].Name}";
                                castInstanceState.CurrentState = CombatState.CombatDialogState.AwaitConfirmDialog;
                                castInstanceState.SelectedOption = 0;
                                castInstanceState.RerenderCombat();
                            }
                            else
                                return false;
                            break;
                        case CombatState.CombatDialogState.AwaitConfirmDialog:
                            if (castInstanceState.CombatDialog.Contains("Player:"))
                            {
                                Enemy castEnemy = (Enemy)Game.Instance.Player.Target;
                                castEnemy.ChooseMove();
                                castInstanceState.RerenderCombat();
                            }
                            else
                            {
                                castInstanceState.CurrentState = CombatState.CombatDialogState.DefaultDialog;
                                castInstanceState.SelectedOption = 0;
                                castInstanceState.RerenderCombat();
                            }
                            break;
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
            InventoryState castInstanceState = (InventoryState)Game.Instance.GameState;

            switch (inputKey)
            {
                case ConsoleKey.Escape:
                    Game.Instance.ChangeState(GameStateType.Exploration);
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    return castInstanceState.NextElement();
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    if (castInstanceState.CurrentState == InventoryDialogState.SpellDialog)
                        castInstanceState.CurrentState = InventoryDialogState.ItemDialog;
                    else
                        castInstanceState.CurrentState = InventoryDialogState.SpellDialog;

                    castInstanceState.SelectedOption = 0;
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    return castInstanceState.PreviousElement();
                case ConsoleKey.Spacebar:
                case ConsoleKey.Enter:
                    if (Game.Instance.Player.Inventory[castInstanceState.SelectedOption] is Equippable)
                    {
                        Game.Instance.Player.Equip((Equippable)Game.Instance.Player.Inventory[castInstanceState.SelectedOption]);
                        castInstanceState.UpdateEquipment();
                        castInstanceState.UpdateStats();
                    }
                    else if (Game.Instance.Player.Inventory[castInstanceState.SelectedOption] is Consumable)
                    {
                        Game.Instance.Player.Inventory[castInstanceState.SelectedOption].Use();
                        castInstanceState.UpdateStats();
                    }
                    else
                        return false;
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

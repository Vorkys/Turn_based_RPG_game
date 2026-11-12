using System;
using TurnBasedRPG.Source.Core.GameStates;
using TurnBasedRPG.Source.Entities;
using TurnBasedRPG.Source.Entities.AllyRoles;
using TurnBasedRPG.Source.GameObjects.Items.ItemTypes;
using TurnBasedRPG.Source.Locations.Nodes;
using static TurnBasedRPG.Source.Core.GameStates.InventoryState;

namespace TurnBasedRPG.Source.Core.InputHandlers
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
                                    Game.Instance.NewGame();
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
                            if (castInstanceState.SaveFilesPath.Length == 0)
                                return false;
                            else
                                Game.Instance.Load(castInstanceState.SaveFilesPath[castInstanceState.SelectedOption]);
                            break;
                        case (MainMenuState.MenuState.HowToPlayMenu):
                            return false;
                    }
                    break;
                case ConsoleKey.Delete:
                    switch (castInstanceState.CurrentState)
                    {
                        case (MainMenuState.MenuState.ContinueMenu):
                            Game.Instance.Delete(castInstanceState.SaveFilesPath[castInstanceState.SelectedOption]);
                            break;
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
            PauseState castInstanceState = (PauseState)Game.Instance.GameState;

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
                    switch (castInstanceState.SelectedOption)
                    {
                        case 0:
                            Game.Instance.Resume();
                            break;
                        case 1:
                            Game.Instance.Save();
                            castInstanceState.GameSaved = true;
                            break;
                        case 2:
                            Game.Instance.ChangeState(GameStateType.Menu);
                            break;
                    }
                    break;
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
                case ConsoleKey.J:
                    Game.Instance.ChangeState(GameStateType.Journal);
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
                            return false;
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
                        case CombatState.CombatDialogState.DropDialog:
                            Game.Instance.ChangeState(GameStateType.Exploration);
                            break;
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
                        case CombatState.CombatDialogState.DropDialog:
                            castInstanceState.PreviousElement();
                            break;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    switch (castInstanceState.CurrentState)
                    {
                        case CombatState.CombatDialogState.DefaultDialog:
                        case CombatState.CombatDialogState.SpellDialog:
                        case CombatState.CombatDialogState.ItemDialog:
                        case CombatState.CombatDialogState.AwaitConfirmDialog:
                            return false;
                        case CombatState.CombatDialogState.DropDialog:
                            castInstanceState.PreviousElement();
                            break;
                    }
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    switch (castInstanceState.CurrentState)
                    {
                        case CombatState.CombatDialogState.DefaultDialog:
                        case CombatState.CombatDialogState.SpellDialog:
                        case CombatState.CombatDialogState.ItemDialog:
                        case CombatState.CombatDialogState.AwaitConfirmDialog:
                            return false;
                        case CombatState.CombatDialogState.DropDialog:
                            castInstanceState.NextElement();
                            break;
                    }
                    break;
                case ConsoleKey.Delete:
                    switch (castInstanceState.CurrentState)
                    {
                        case CombatState.CombatDialogState.DefaultDialog:
                        case CombatState.CombatDialogState.SpellDialog:
                        case CombatState.CombatDialogState.ItemDialog:
                        case CombatState.CombatDialogState.AwaitConfirmDialog:
                            return false;
                        case CombatState.CombatDialogState.DropDialog:
                            if (castInstanceState.InventorySelected && Game.Instance.Player.Inventory[castInstanceState.SelectedOption] != null)
                                Game.Instance.Player.RemoveItem(Game.Instance.Player.Inventory[castInstanceState.SelectedOption]);
                            break;
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
                        case CombatState.CombatDialogState.DropDialog:
                            castInstanceState.InventorySelected = true;
                            break;
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
                        case CombatState.CombatDialogState.DropDialog:
                            castInstanceState.InventorySelected = false;
                            break;
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
                            if (Game.Instance.Player.CastSpell(castInstanceState.SelectedOption))
                            {
                                castInstanceState.SelectedOption = 0;
                                castInstanceState.RerenderCombat();
                            }
                            else
                                return false;
                            break;
                        case CombatState.CombatDialogState.ItemDialog:
                            if (Game.Instance.Player.Inventory[castInstanceState.SelectedOption] is Consumable)
                            {
                                Game.Instance.Player.UseItem(castInstanceState.SelectedOption);
                                castInstanceState.SelectedOption = 0;
                                castInstanceState.RerenderCombat();
                            }
                            else
                                return false;
                            break;
                        case CombatState.CombatDialogState.AwaitConfirmDialog:
                            Enemy castEnemy = (Enemy)Game.Instance.Player.Target;

                            //last turn was player, let Enemy play
                            if (castInstanceState.LastTurnWasPlayer)
                            {
                                //if enemy/player dies
                                if (Game.Instance.Player.Health <= 0)
                                    Game.Instance.GameOver();
                                else if (Game.Instance.Player.Target.Health <= 0)
                                    castEnemy.Defeated();
                                else
                                    castEnemy.ChooseMove();

                                if (Game.Instance.GameState is CombatState)
                                    castInstanceState.RerenderCombat();
                            }
                            //Enemy played, Players turn
                            else
                            {
                                //if enemy/player dies
                                if (Game.Instance.Player.Health <= 0)
                                    Game.Instance.GameOver();
                                else if (Game.Instance.Player.Target.Health <= 0)
                                    castEnemy.Defeated();
                                else
                                {
                                    castInstanceState.CurrentState = CombatState.CombatDialogState.DefaultDialog;
                                    castInstanceState.SelectedOption = 0;
                                }

                                if (Game.Instance.GameState is CombatState)
                                    castInstanceState.RerenderCombat();
                            }
                            break;
                        case CombatState.CombatDialogState.DropDialog:
                            if (!castInstanceState.InventorySelected && Game.Instance.Player.FreeSpaceInInventory())
                            {
                                Game.Instance.Player.AddItem(castInstanceState.DropTable[castInstanceState.SelectedOption]);
                                castInstanceState.RemoveItemFromDropTable(castInstanceState.DropTable[castInstanceState.SelectedOption]);
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
                    castInstanceState.UpdateCurrentOpenedMenuLabel();
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
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Game.Instance.Player.Unequip(0);
                    castInstanceState.UpdateEquipment();
                    castInstanceState.UpdateStats();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Game.Instance.Player.Unequip(1);
                    castInstanceState.UpdateEquipment();
                    castInstanceState.UpdateStats();
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    Game.Instance.Player.Unequip(3);
                    castInstanceState.UpdateEquipment();
                    castInstanceState.UpdateStats();
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    Game.Instance.Player.Unequip(2);
                    castInstanceState.UpdateEquipment();
                    castInstanceState.UpdateStats();
                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    Game.Instance.Player.Unequip(4);
                    castInstanceState.UpdateEquipment();
                    castInstanceState.UpdateStats();
                    break;
                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
                    Game.Instance.Player.Unequip(5);
                    castInstanceState.UpdateEquipment();
                    castInstanceState.UpdateStats();
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
            JournalState castInstanceState = (JournalState)Game.Instance.GameState;

            switch (inputKey)
            {
                case ConsoleKey.Escape:
                    if (castInstanceState.IsFocused)
                        castInstanceState.IsFocused = false;
                    else
                        Game.Instance.ChangeState(GameStateType.Exploration);
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    castInstanceState.PreviousElement();
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    castInstanceState.NextElement();
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    castInstanceState.PreviousElement(true);
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    castInstanceState.NextElement(true);
                    break;
                case ConsoleKey.Spacebar:
                case ConsoleKey.Enter:
                    if (!castInstanceState.IsFocused)
                        castInstanceState.IsFocused = true;
                    else
                        return false;
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
            TownState castInstanceState = (TownState)Game.Instance.GameState;
            TownNode castCurrentNode = (TownNode)Game.Instance.Maps[Game.Instance.ActiveMap].Map[Game.Instance.Maps[Game.Instance.ActiveMap].PlayerX][Game.Instance.Maps[Game.Instance.ActiveMap].PlayerY];

            switch (inputKey)
            {
                case ConsoleKey.Q:
                    if (castCurrentNode.TownPeople == null)
                        return false;
                    foreach (Ally ally in castCurrentNode.TownPeople)
                        if (ally is TavernKeeper)
                        {
                            TavernKeeper castNpc = (TavernKeeper)ally;
                            castNpc.Talk();
                        }
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    return castInstanceState.PreviousElement();
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    return castInstanceState.NextElement();
                case ConsoleKey.E:
                    if (castCurrentNode.TownPeople == null)
                        return false;
                    foreach (Ally ally in castCurrentNode.TownPeople)
                        if (ally is Merchant)
                        {
                            castInstanceState.SelectedOption = 0;
                            castInstanceState.CurrentState = TownState.TownNodeState.MerchantSell;
                        }
                    break;
                case ConsoleKey.R:
                    if (castCurrentNode.TownPeople == null)
                        return false;
                    foreach (Ally ally in castCurrentNode.TownPeople)
                        if (ally is Merchant)
                        {
                            castInstanceState.SelectedOption = 0;
                            castInstanceState.CurrentState = TownState.TownNodeState.MerchantBuy;
                        }
                    break;
                //QuestGiver
                case ConsoleKey.T:
                    if (castCurrentNode.TownPeople == null)
                        return false;
                    foreach (Ally ally in castCurrentNode.TownPeople)
                        if (ally is QuestGiver)
                        {
                            QuestGiver castNpc = (QuestGiver)ally;
                            castNpc.Talk();
                        }
                    break;
                case ConsoleKey.Z:
                    if (castCurrentNode.TownPeople == null)
                        return false;
                    foreach (Ally ally in castCurrentNode.TownPeople)
                        if (ally is Transporter)
                        {
                            Transporter castNpc = (Transporter)ally;
                            castNpc.Talk();
                        }
                    break;
                case ConsoleKey.U:
                    if (castCurrentNode.TownPeople == null)
                        return false;
                    foreach (Ally ally in castCurrentNode.TownPeople)
                        if (ally is ArenaOrganisator)
                        {
                            ArenaOrganisator castNpc = (ArenaOrganisator)ally;
                            castNpc.Talk();
                        }
                    break;
                case ConsoleKey.Escape:
                    switch (castInstanceState.CurrentState)
                    {
                        case TownState.TownNodeState.TownInfo:
                            Game.Instance.ChangeState(GameStateType.Exploration);
                            break;
                        case TownState.TownNodeState.MerchantSell:
                            castInstanceState.CurrentState = TownState.TownNodeState.TownInfo;
                            break;
                        case TownState.TownNodeState.MerchantBuy:
                            castInstanceState.CurrentState = TownState.TownNodeState.TownInfo;
                            break;
                    }
                    break;
                case ConsoleKey.Spacebar:
                case ConsoleKey.Enter:
                    switch (castInstanceState.CurrentState)
                    {
                        case TownState.TownNodeState.MerchantSell:
                            Game.Instance.Player.Sell(castInstanceState.SelectedOption);
                            break;
                        case TownState.TownNodeState.MerchantBuy:
                            Merchant castMerchant = null;
                            foreach (Ally ally in castCurrentNode.TownPeople)
                                if (ally is Merchant)
                                {
                                    castMerchant = (Merchant)ally;
                                }

                            if (castMerchant == null)
                                return false;
                            else
                                Game.Instance.Player.Buy(castMerchant.Wares[castInstanceState.SelectedOption]);
                            break;
                    }
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

using System;
using System.Collections.Generic;
using tahova_RPG_hra.Source.Core.InputHandlers;
using tahova_RPG_hra.Source.Entities;
using tahova_RPG_hra.Source.GameObjects.Items;
using tahova_RPG_hra.Source.GameObjects.Items.ItemTypes;
using tahova_RPG_hra.Source.Locations.Nodes;
using tahova_RPG_hra.Source.Scenes;
using tahova_RPG_hra.Source.Utils;
using static tahova_RPG_hra.Source.Core.GameStates.CombatState;

namespace tahova_RPG_hra.Source.Core.GameStates
{
    class MainMenuState : GameState
    {
        public enum MenuState
        {
            MainMenu,
            ContinueMenu,
            HowToPlayMenu
        }
        private int menuStateLength = 3;
        private MenuState currentState = MenuState.MainMenu;
        private int selectedOption = 0;
        //TODO - add path of all save files in "Saves"
        private string[] saveFilesPath = [];
        private string[] menuSelections = ["New game", "Continue", "How to play?", "Exit"];
        private string[] manual = ["1. Explore the world", "2. Rest in camps, villages and towns", "3. Become stronger killing enemies", "4. Dont fight stronger enemies!", "5. Reach heaven"];

        public MainMenuState()
        {
            InputHandler = new MenuHandler();
        }

        public override void Render()
        {
            Console.Clear();

            //Print main border
            for (int row = 0; row < GlobalConstants.consoleRenderSizeHeight; row++)
            {
                //divider '='
                if (row == 0 || row == GlobalConstants.consoleRenderSizeHeight - 1)
                    Console.Write(new string('=', GlobalConstants.consoleSizeWidth));
                else
                    Console.Write('H' + new string(' ', GlobalConstants.consoleRenderSizeWidth) + 'H');

                Console.WriteLine();
            }

            //Print control box
            string[] keybinds = ["[W/S or ^/v arrows] - Move", "[Spacebar or Enter] - Confirm", "[ESC] - Back"];
            int tmpId = 0;

            for (int row = 0; row < 4; row++)
            {
                //divider
                if (row == 3)
                {
                    Console.Write(new string('=', GlobalConstants.consoleSizeWidth));
                    break;
                }

                for (int column = 0; column < GlobalConstants.consoleSizeWidth; column++)
                {
                    //border 'H'
                    if (column == 0 || column == GlobalConstants.consoleSizeWidth - 1)
                        Console.Write('H');

                    //print keybind if there is enough place
                    else if (tmpId < keybinds.Length && (keybinds[tmpId].Length < GlobalConstants.consoleRenderSizeWidth - column))
                    {
                        Console.Write($" {keybinds[tmpId]} ");
                        column += keybinds[tmpId].Length + 1;
                        tmpId++;
                    }
                    else
                        Console.Write(' ');
                }

                Console.WriteLine();
            }

            RerenderMenu();
        }

        public override void Update()
        {
            switch (currentState)
            {
                case (MenuState.MainMenu):
                    for (int selectionRow = 0; selectionRow < menuSelections.Length; selectionRow++)
                    {
                        Console.SetCursorPosition(GlobalConstants.consoleRenderSizeWidth / 15 - 3, GlobalConstants.consoleSizeHeight / 5 + (2 * selectionRow));
                        if (selectionRow == selectedOption)
                            Console.Write(">>");
                        else
                            Console.Write("  ");
                    }
                    break;
                case (MenuState.ContinueMenu):
                    if (saveFilesPath.Length > 0)
                    {
                        for (int selectionRow = 0; selectionRow < saveFilesPath.Length; selectionRow++)
                        {
                            Console.SetCursorPosition(GlobalConstants.consoleRenderSizeWidth / 15 - 3, GlobalConstants.consoleSizeHeight / 5 + (1 * selectionRow));
                            if (selectionRow == selectedOption)
                                Console.Write(">>");
                            else
                                Console.Write("  ");
                        }
                    }
                    break;
            }

            //move cursor back to end for better experience
            Console.SetCursorPosition(GlobalConstants.consoleSizeWidth - 1, GlobalConstants.consoleSizeHeight - 1);
        }

        public void RerenderMenu()
        {
            //Clear render box
            for (int row = 1; row < GlobalConstants.consoleRenderSizeHeight - 1; row++)
            {
                Console.SetCursorPosition(1, row);
                Console.Write(new string(' ', GlobalConstants.consoleRenderSizeWidth));
            }

            switch (currentState)
            {
                case (MenuState.MainMenu):
                    for (int i = 0; i < menuSelections.Length; i++)
                    {
                        //set starting position for selections
                        Console.SetCursorPosition(GlobalConstants.consoleRenderSizeWidth / 15, GlobalConstants.consoleSizeHeight / 5 + (i * 2));
                        Console.Write(menuSelections[i]);
                    }
                    break;
                case (MenuState.ContinueMenu):
                    Console.SetCursorPosition(GlobalConstants.consoleRenderSizeWidth / 15, GlobalConstants.consoleSizeHeight / 5);
                    Console.Write("Your saved files:");

                    if (saveFilesPath.Length == 0)
                    {
                        Console.SetCursorPosition(GlobalConstants.consoleRenderSizeWidth / 15, GlobalConstants.consoleSizeHeight / 5 + 2);
                        Console.Write("No saved files");
                    }    
                    for (int saveFileNumber = 0; saveFileNumber < saveFilesPath.Length; saveFileNumber++)
                    {
                        Console.SetCursorPosition(GlobalConstants.consoleRenderSizeWidth / 15, GlobalConstants.consoleSizeHeight / 5 + 2 + saveFileNumber);
                        Console.Write(saveFilesPath[saveFileNumber]);
                    }
                    break;
                case (MenuState.HowToPlayMenu):
                    Console.SetCursorPosition(GlobalConstants.consoleRenderSizeWidth / 15, GlobalConstants.consoleSizeHeight / 5);
                    Console.Write("How to play?");

                    for (int row = 0; row < manual.Length; row++)
                    {
                        Console.SetCursorPosition(GlobalConstants.consoleRenderSizeWidth / 15, GlobalConstants.consoleSizeHeight / 5 + 2 + row);
                        Console.Write(manual[row]);
                    }
                    break;
            }
        }

        public void NextSelection()
        {
            //selectedOption < MenuEnum.Count
            if (currentState == MenuState.MainMenu && selectedOption < menuStateLength)
                selectedOption++;
            else if (currentState == MenuState.ContinueMenu && selectedOption < saveFilesPath.Length - 1)
                selectedOption++;
        }

        public void PreviousSelection()
        {
            if (currentState == MenuState.MainMenu && selectedOption > 0)
                selectedOption--;
            else if (currentState == MenuState.ContinueMenu && selectedOption > 0)
                selectedOption--;
        }

        public int SelectedOption { get => selectedOption; set => selectedOption = value; }
        public MenuState CurrentState { get => currentState; set => currentState = value; }
    }

    class PauseState : GameState
    {
        public PauseState()
        {
            InputHandler = new PauseHandler();
        }

        public override void Render()
        {
            //Print pause in middle of screen
            Console.SetCursorPosition(GlobalConstants.consoleRenderSizeWidth / 2 - 5, GlobalConstants.consoleRenderSizeHeight / 2 - 1);
            Console.Write('o' + "---------" + 'o');
            Console.SetCursorPosition(GlobalConstants.consoleRenderSizeWidth / 2 - 5, GlobalConstants.consoleRenderSizeHeight / 2);
            Console.Write('|' + "  Pause  " + '|');
            Console.SetCursorPosition(GlobalConstants.consoleRenderSizeWidth / 2 - 5, GlobalConstants.consoleRenderSizeHeight / 2 + 1);
            Console.Write('o' + "---------" + 'o');

            //clear control box
            for (int row = 0; row < 4; row++)
            {
                Console.SetCursorPosition(0, GlobalConstants.consoleSizeHeight - 4 + row);
                Console.Write(new string(' ', GlobalConstants.consoleSizeWidth));
            }

            Console.SetCursorPosition(0, GlobalConstants.consoleSizeHeight - 4);
            //Print control box
            string[] keybinds = ["[ESC] - Resume"];
            int tmpId = 0;

            //print informations box
            for (int row = 0; row < 4; row++)
            {
                //divider
                if (row == 3)
                {
                    Console.Write(new string('=', GlobalConstants.consoleSizeWidth));
                    break;
                }

                for (int column = 0; column < GlobalConstants.consoleSizeWidth; column++)
                {
                    //border 'H'
                    if (column == 0 || column == GlobalConstants.consoleSizeWidth - 1)
                        Console.Write('H');

                    //print keybind if there is enough place
                    else if (tmpId < keybinds.Length && (keybinds[tmpId].Length + 2 < GlobalConstants.consoleRenderSizeWidth - column))
                    {
                        Console.Write($" {keybinds[tmpId]} ");
                        column += keybinds[tmpId].Length + 1;
                        tmpId++;
                    }
                    else
                        Console.Write(' ');
                }

                Console.WriteLine();
            }
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
            Console.Clear();

            //Print main border
            for (int i = 0; i < GlobalConstants.consoleRenderSizeHeight; i++)
            {
                //divider '='
                if (i == 0 || i == GlobalConstants.consoleRenderSizeHeight - 1)
                    Console.Write(new string('=', GlobalConstants.consoleSizeWidth));
                else
                    Console.Write('H' + new string(' ', GlobalConstants.consoleRenderSizeWidth) + 'H');

                Console.WriteLine();
            }

            //Print control box
            string[] keybinds = ["[W/S/A/D or arrows] - Move", "[ESC] - Pause"];
            int tmpId = 0;

            for (int row = 0; row < 4; row++)
            {
                //divider
                if (row == 3)
                {
                    Console.Write(new string('=', GlobalConstants.consoleSizeWidth));
                    break;
                }

                for (int column = 0; column < GlobalConstants.consoleSizeWidth; column++)
                {
                    //border 'H'
                    if (column == 0 || column == GlobalConstants.consoleSizeWidth - 1)
                        Console.Write('H');

                    //print keybind if there is enough place
                    else if (tmpId < keybinds.Length && (keybinds[tmpId].Length < GlobalConstants.consoleRenderSizeWidth - column))
                    {
                        Console.Write($" {keybinds[tmpId]} ");
                        column += keybinds[tmpId].Length + 1;
                        tmpId++;
                    }
                    else
                        Console.Write(' ');
                }

                Console.WriteLine();
            }

            //Map printed using Update()
        }

        //Keep in memory the player position when the map was last rendered
        private int playerRenderedPosX = GlobalConstants.consoleRenderSizeHeight;
        private int playerRenderedPosY = GlobalConstants.consoleRenderSizeWidth;

        public override void Update()
        {
            int playerPosX = Game.Instance.Maps[Game.Instance.ActiveMap].PlayerX;
            int playerPosY = Game.Instance.Maps[Game.Instance.ActiveMap].PlayerY;
            //% of rendering box considered "outside"
            float outsideX = (GlobalConstants.consoleRenderSizeHeight / 2) / 2;
            float outsideY = (GlobalConstants.consoleRenderSizeWidth / 2) / 3;

            //Update decides wether 1. re-render map where player is in center of screen OR 2. move player node
            if (Math.Abs(playerRenderedPosX - playerPosX) > outsideX || Math.Abs(playerRenderedPosY - playerPosY) > outsideY)
                RenderMap();
            else
                UpdatePlayerNode();

            //move cursor back to end for better experience
            Console.SetCursorPosition(GlobalConstants.consoleSizeWidth - 1, GlobalConstants.consoleSizeHeight - 1);
        }

        //Rerender map where player is in middle
        public void RenderMap()
        {
            //Clear render box
            for (int row = 1; row < GlobalConstants.consoleRenderSizeHeight - 1; row++)
            {
                Console.SetCursorPosition(1, row);
                Console.Write(new string(' ', GlobalConstants.consoleRenderSizeWidth));
            }

            int playerPosX = Game.Instance.Maps[Game.Instance.ActiveMap].PlayerX;
            int playerPosY = Game.Instance.Maps[Game.Instance.ActiveMap].PlayerY;
            //Update last palyer rendered positions
            playerRenderedPosX = playerPosX;
            playerRenderedPosY = playerPosY;

            //IF Player position (in middle of render screen) is far enough from a border then render from render border
            int mapHeightStart = playerPosX >= (GlobalConstants.consoleRenderSizeHeight / 2) ? 1 : (GlobalConstants.consoleRenderSizeHeight / 2) - playerPosX;
            int mapWidthStart = playerPosY >= (GlobalConstants.consoleRenderSizeWidth / 2) ? 1 : (GlobalConstants.consoleRenderSizeWidth / 2) - playerPosY;

            //FOR while row is inside render box AND is in bounds of map
            for (int mapCurrentHeight = 0; (mapHeightStart + mapCurrentHeight) < GlobalConstants.consoleRenderSizeHeight - 1 && (playerPosX - (GlobalConstants.consoleRenderSizeHeight / 2) + mapHeightStart + mapCurrentHeight) < Game.Instance.Maps[Game.Instance.ActiveMap].Map.Count; mapCurrentHeight++)
            {
                Console.SetCursorPosition(mapWidthStart, mapHeightStart + mapCurrentHeight);

                for (int mapCurrentWidth = 0; (mapWidthStart + mapCurrentWidth) < GlobalConstants.consoleRenderSizeWidth + 1 && (playerPosY - (GlobalConstants.consoleRenderSizeWidth / 2) + mapWidthStart + mapCurrentWidth) < Game.Instance.Maps[Game.Instance.ActiveMap].Map[0].Count; mapCurrentWidth++)
                {
                    int x = playerPosX - (GlobalConstants.consoleRenderSizeHeight / 2) + mapHeightStart + mapCurrentHeight;
                    int y = playerPosY - (GlobalConstants.consoleRenderSizeWidth / 2) + mapWidthStart + mapCurrentWidth;

                    //Normal node
                    if (x == playerPosX && y == playerPosY)
                        Game.Instance.Maps[Game.Instance.ActiveMap].Map[x][y].Write(true);
                    //Player node
                    else
                        Game.Instance.Maps[Game.Instance.ActiveMap].Map[x][y].Write();
                }
            }
        }

        //Move player node and update node around so there isnt any duplicate player node
        public void UpdatePlayerNode()
        {
            int playerPosX = Game.Instance.Maps[Game.Instance.ActiveMap].PlayerX;
            int playerPosY = Game.Instance.Maps[Game.Instance.ActiveMap].PlayerY;
            //Center of render box - oposite number of (distance of player from center)
            int playerCursorHeight = (GlobalConstants.consoleRenderSizeHeight / 2) - (playerRenderedPosX - playerPosX);
            int playerCursorWidth = (GlobalConstants.consoleRenderSizeWidth / 2) - (playerRenderedPosY - playerPosY);

            Console.SetCursorPosition(playerCursorWidth, playerCursorHeight);
            Game.Instance.Maps[Game.Instance.ActiveMap].Map[playerPosX][playerPosY].Write(true);

            //Clean side of player for playerNode duplicates (if in bounds of map)
            if (playerPosX - 1 >= 0)
            {
                Console.SetCursorPosition(playerCursorWidth, playerCursorHeight - 1);
                Game.Instance.Maps[Game.Instance.ActiveMap].Map[playerPosX - 1][playerPosY].Write();
            }
            if (playerPosX + 1 < Game.Instance.Maps[Game.Instance.ActiveMap].Map.Count)
            {
                Console.SetCursorPosition(playerCursorWidth, playerCursorHeight + 1);
                Game.Instance.Maps[Game.Instance.ActiveMap].Map[playerPosX + 1][playerPosY].Write();
            }
            if (playerPosY - 1 >= 0)
            {
                Console.SetCursorPosition(playerCursorWidth - 1, playerCursorHeight);
                Game.Instance.Maps[Game.Instance.ActiveMap].Map[playerPosX][playerPosY - 1].Write();
            }
            if (playerPosY + 1 < Game.Instance.Maps[Game.Instance.ActiveMap].Map[0].Count)
            {
                Console.SetCursorPosition(playerCursorWidth + 1, playerCursorHeight);
                Game.Instance.Maps[Game.Instance.ActiveMap].Map[playerPosX][playerPosY + 1].Write();
            }
        }
    }

    class CombatState : GameState
    {
        public enum CombatDialogState
        {
            DefaultDialog,
            SpellDialog,
            ItemDialog,
            AwaitConfirmDialog
        }
        private CombatDialogState currentState = CombatDialogState.DefaultDialog;
        //cant use Game.Instance since it is null when this class is created
        private static int spellNumber = 0;
        private string[][] dialogKeybinds =
        {
            ["[Q] - Attack enemy", $"[W] - Show spells ({spellNumber})", "[E] - Show items", "[ESC] - Pause"],
            ["[A/<] - Previous selection", "[D/>] - Next selection", "[Spacebar/Enter] - Use", "[ESC] - Back"],
            ["[Spacebar/Enter] - Confirm"]
        };
        private string combatDialog;
        private int selectedOption = 0;

        public CombatState()
        {
            InputHandler = new CombatHandler();
        }

        public override void Render()
        {
            dialogKeybinds[0][1] = $"[W] - Show spells ({Game.Instance.Player.Spells.Count})";
            Console.Clear();

            //Print main border
            for (int row = 0; row < GlobalConstants.consoleRenderSizeHeight; row++)
            {
                //divider '='
                if (row == 0 || row == GlobalConstants.consoleRenderSizeHeight - 1)
                    Console.Write(new string('=', GlobalConstants.consoleSizeWidth));
                else
                    Console.Write('H' + new string(' ', GlobalConstants.consoleRenderSizeWidth) + 'H');

                Console.WriteLine();
            }

            //Print info box
            for (int row = 0; row < 4; row++)
            {
                //divider
                if (row == 3)
                {
                    Console.Write(new string('=', GlobalConstants.consoleSizeWidth));
                    break;
                }
                else
                    Console.WriteLine('H' + new string(' ', GlobalConstants.consoleRenderSizeWidth) + 'H');
            }

            RerenderCombat();
        }

        public override void Update()
        {
            //Clear bonus info lines
            for (int row = 0; row < 2; row++)
            {
                Console.SetCursorPosition(1, GlobalConstants.consoleSizeHeight - 3 + row);
                Console.Write(new string(' ', GlobalConstants.consoleRenderSizeWidth));
            }

            switch (currentState)
            {
                case CombatDialogState.DefaultDialog:
                    //Update enemy HP
                    Console.SetCursorPosition(GlobalConstants.consoleSizeWidth - Game.Instance.Player.Target.Sprite[0].Length - 32, Game.Instance.Player.Target.Sprite.Length + 1);
                    int entityBarPercent = (Game.Instance.Player.Target.Health * 30) / Game.Instance.Player.Target.MaxHealth;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(new string('=', entityBarPercent));
                    Console.ResetColor();
                    Console.Write(new string('-', 30 - entityBarPercent));

                    //Update player HP & MP
                    Console.SetCursorPosition(2 + Game.Instance.Player.Sprite[0].Length, GlobalConstants.consoleRenderSizeHeight - 4);
                    entityBarPercent = (Game.Instance.Player.Health * 30) / Game.Instance.Player.MaxHealth;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(new string('=', entityBarPercent));
                    Console.ResetColor();
                    Console.Write(new string('-', 30 - entityBarPercent));
                    Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
                    Console.Write($" HP: {Game.Instance.Player.Health}/{Game.Instance.Player.MaxHealth}");
                    //Mana
                    Console.SetCursorPosition(2 + Game.Instance.Player.Sprite[0].Length, GlobalConstants.consoleRenderSizeHeight - 3);
                    entityBarPercent = (Game.Instance.Player.Mana * 30) / Game.Instance.Player.MaxMana;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(new string('~', entityBarPercent));
                    Console.ResetColor();
                    Console.Write(new string('-', 30 - entityBarPercent));
                    Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
                    Console.Write($" MP: {Game.Instance.Player.Mana}/{Game.Instance.Player.MaxMana}");
                    break;
                case CombatDialogState.SpellDialog:
                    if (Game.Instance.Player.Spells.Count == 0)
                    {
                        Console.SetCursorPosition(1, GlobalConstants.consoleSizeHeight - 3);
                        Console.Write(" You dont have any spells yet.");
                    }
                    else
                    {
                        string spellName = Game.Instance.Player.Spells[selectedOption].Name.Length < GlobalConstants.consoleRenderSizeWidth / 2 ? Game.Instance.Player.Spells[selectedOption].Name : Game.Instance.Player.Spells[selectedOption].Name.Substring(0, GlobalConstants.consoleRenderSizeWidth / 2 - 3) + "...";
                        string spellDescription = Game.Instance.Player.Spells[selectedOption].Description.Length + 2 <= GlobalConstants.consoleRenderSizeWidth ? Game.Instance.Player.Spells[selectedOption].Description : Game.Instance.Player.Spells[selectedOption].Description.Substring(0, GlobalConstants.consoleRenderSizeWidth - 5) + "...";

                        Console.SetCursorPosition(1, GlobalConstants.consoleSizeHeight - 3);
                        Console.Write($" << {selectedOption + 1}/{Game.Instance.Player.Spells.Count} {spellName} (");
                        Console.ForegroundColor = Game.Instance.Player.Spells[selectedOption].Cost <= Game.Instance.Player.Mana ? ConsoleColor.Green : ConsoleColor.Red;
                        Console.Write(Game.Instance.Player.Spells[selectedOption].Cost);
                        Console.ResetColor();
                        Console.Write(") >>");
                        Console.SetCursorPosition(1, GlobalConstants.consoleSizeHeight - 2);
                        Console.Write(' ' + spellDescription + ' ');
                    }
                    break;
                case CombatDialogState.ItemDialog:
                    string itemName;
                    string itemDescription;

                    if (Game.Instance.Player.Inventory[selectedOption] == null)
                    {
                        itemName = "-----";
                        itemDescription = "Empty space in your pocket";
                    }
                    else
                    {
                        itemName = Game.Instance.Player.Inventory[selectedOption].Name.Length < GlobalConstants.consoleRenderSizeWidth / 2 ? Game.Instance.Player.Inventory[selectedOption].Name : Game.Instance.Player.Inventory[selectedOption].Name.Substring(0, GlobalConstants.consoleRenderSizeWidth / 2 - 3) + "...";
                        itemDescription = Game.Instance.Player.Inventory[selectedOption].Description.Length + 2 <= GlobalConstants.consoleRenderSizeWidth ? Game.Instance.Player.Inventory[selectedOption].Description : Game.Instance.Player.Inventory[selectedOption].Description.Substring(0, GlobalConstants.consoleRenderSizeWidth - 5) + "...";
                    }

                    Console.SetCursorPosition(1, GlobalConstants.consoleSizeHeight - 3);
                    Console.Write($" << {selectedOption + 1}/{Game.Instance.Player.Inventory.Length} {itemName} ");
                    if (Game.Instance.Player.Inventory[selectedOption] != null)
                    {
                        Console.Write('(');
                        Console.ForegroundColor = Game.Instance.Player.Inventory[selectedOption] is Consumable ? ConsoleColor.Green : ConsoleColor.Red;
                        Console.Write(Game.Instance.Player.Inventory[selectedOption].Quantity);
                        Console.ResetColor();
                        Console.Write(')');
                    }
                    Console.Write(" >>");
                    Console.SetCursorPosition(1, GlobalConstants.consoleSizeHeight - 2);
                    Console.Write(' ' + itemDescription + ' ');
                    break;
                case CombatDialogState.AwaitConfirmDialog:
                    Console.SetCursorPosition(1, GlobalConstants.consoleSizeHeight - 2);
                    if (combatDialog.Length + 2 <= GlobalConstants.consoleRenderSizeWidth)
                        Console.Write(' ' + combatDialog + ' ');
                    else
                        Console.Write(string.Concat(" ", combatDialog.AsSpan(0, GlobalConstants.consoleRenderSizeWidth - 4), "... "));
                    break;
            }

            //move cursor back to end for better experience
            Console.SetCursorPosition(GlobalConstants.consoleSizeWidth - 1, GlobalConstants.consoleSizeHeight - 1);
        }

        public void RerenderCombat()
        {
            Game.Instance.Player.LoadSprite();
            Game.Instance.Player.Target.LoadSprite();

            //Print enemy sprite
            for (int row = 0; row < Game.Instance.Player.Target.Sprite.Length; row++)
            {
                Console.SetCursorPosition(GlobalConstants.consoleSizeWidth - 1 - Game.Instance.Player.Target.Sprite[row].Length, 1 + row);
                Console.Write(Game.Instance.Player.Target.Sprite[row]);
            }
            //Print player sprite
            for (int row = 0; row < Game.Instance.Player.Sprite.Length; row++)
            {
                Console.SetCursorPosition(1, GlobalConstants.consoleRenderSizeHeight - 1 - Game.Instance.Player.Sprite.Length + row);
                Console.Write(Game.Instance.Player.Sprite[row]);
            }

            int entityNameAllowedLength = 33 - (3 + Game.Instance.Player.MaxLevel.ToString().Length);
            int entityNameLength = Game.Instance.Player.Target.Name.Length;
            //Print ENEMY info
            Console.SetCursorPosition(GlobalConstants.consoleSizeWidth - Game.Instance.Player.Target.Sprite[0].Length - 33, Game.Instance.Player.Target.Sprite.Length);
            //Print enemy name (cut name if too long) and LVL
            Console.Write(entityNameLength < entityNameAllowedLength ? Game.Instance.Player.Target.Name : Game.Instance.Player.Target.Name.Substring(0, entityNameAllowedLength - 3) + "...");
            Console.SetCursorPosition(GlobalConstants.consoleSizeWidth - Game.Instance.Player.Target.Sprite[0].Length - 6 - Game.Instance.Player.MaxLevel.ToString().Length, Game.Instance.Player.Target.Sprite.Length);
            Console.Write("Lvl: " + Game.Instance.Player.Target.Level);
            //Print health
            Console.SetCursorPosition(GlobalConstants.consoleSizeWidth - Game.Instance.Player.Target.Sprite[0].Length - 33, Game.Instance.Player.Target.Sprite.Length + 1);
            int entityBarPercent = Game.Instance.Player.Target.Health > 0 ? (Game.Instance.Player.Target.Health * 30) / Game.Instance.Player.Target.MaxHealth : 0;
            Console.Write('<');
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(new string('=', entityBarPercent));
            Console.ResetColor();
            Console.Write(new string('-', 30 - entityBarPercent));
            Console.Write('>');

            //Print PLAYER info
            entityNameLength = Game.Instance.Player.Name.Length;
            //Name & LVL
            Console.SetCursorPosition(1 + Game.Instance.Player.Sprite[0].Length, GlobalConstants.consoleRenderSizeHeight - 5);
            Console.Write(entityNameLength < entityNameAllowedLength ? Game.Instance.Player.Name : Game.Instance.Player.Name.Substring(0, entityNameAllowedLength - 3) + "...");
            Console.SetCursorPosition(1 + Game.Instance.Player.Sprite[0].Length + 33 - 6 - Game.Instance.Player.MaxLevel.ToString().Length, GlobalConstants.consoleRenderSizeHeight - 5);
            Console.Write("Lvl: " + Game.Instance.Player.Level);
            //Health
            Console.SetCursorPosition(1 + Game.Instance.Player.Sprite[0].Length, GlobalConstants.consoleRenderSizeHeight - 4);
            entityBarPercent = Game.Instance.Player.Health > 0 ? (Game.Instance.Player.Health * 30) / Game.Instance.Player.MaxHealth : 0;
            Console.Write('<');
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(new string('=', entityBarPercent));
            Console.ResetColor();
            Console.Write(new string('-', 30 - entityBarPercent));
            Console.Write('>');
            Console.Write($" HP: {Game.Instance.Player.Health}/{Game.Instance.Player.MaxHealth}");
            //Mana
            Console.SetCursorPosition(1 + Game.Instance.Player.Sprite[0].Length, GlobalConstants.consoleRenderSizeHeight - 3);
            entityBarPercent = (Game.Instance.Player.Mana * 30) / Game.Instance.Player.MaxMana;
            Console.Write('<');
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(new string('~', entityBarPercent));
            Console.ResetColor();
            Console.Write(new string('-', 30 - entityBarPercent));
            Console.Write('>');
            Console.Write($" MP: {Game.Instance.Player.Mana}/{Game.Instance.Player.MaxMana}");
            //EXP
            Console.SetCursorPosition(1 + Game.Instance.Player.Sprite[0].Length, GlobalConstants.consoleRenderSizeHeight - 2);
            entityBarPercent = (Game.Instance.Player.EntityXP * 30) / Game.Instance.Player.XPtoLevelUp;
            Console.Write('|');
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(new string('=', entityBarPercent));
            Console.ResetColor();
            Console.Write(new string('-', 30 - entityBarPercent));
            Console.Write('|');
            Console.Write($" XP: {Game.Instance.Player.EntityXP}/{Game.Instance.Player.XPtoLevelUp}");

            //Fill info box
            int tmpId = 0;

            switch (currentState)
            {
                case CombatDialogState.DefaultDialog:
                    for (int row = 0; row < 3; row++)
                    {
                        for (int column = 1; column < GlobalConstants.consoleRenderSizeWidth && tmpId < dialogKeybinds[0].Length; column++)
                        {
                            if (dialogKeybinds[0][tmpId].Length + 2 < GlobalConstants.consoleRenderSizeWidth - column)
                            {
                                Console.SetCursorPosition(column, GlobalConstants.consoleSizeHeight - 4 + row);
                                Console.Write($" {dialogKeybinds[0][tmpId]} ");
                                column += dialogKeybinds[0][tmpId].Length + 1;
                                tmpId++;
                            }
                        }
                    }
                    break;
                case CombatDialogState.SpellDialog:
                    for (int row = 0; row < 3; row++)
                    {
                        for (int column = 1; column < GlobalConstants.consoleRenderSizeWidth && tmpId < dialogKeybinds[1].Length; column++)
                        {
                            if (dialogKeybinds[1][tmpId].Length + 2 < GlobalConstants.consoleRenderSizeWidth - column)
                            {
                                Console.SetCursorPosition(column, GlobalConstants.consoleSizeHeight - 4 + row);
                                Console.Write($" {dialogKeybinds[1][tmpId]} ");
                                column += dialogKeybinds[1][tmpId].Length + 1;
                                tmpId++;
                            }
                        }
                    }
                    break;
                case CombatDialogState.ItemDialog:
                    for (int row = 0; row < 3; row++)
                    {
                        for (int column = 1; column < GlobalConstants.consoleRenderSizeWidth && tmpId < dialogKeybinds[1].Length; column++)
                        {
                            if (dialogKeybinds[1][tmpId].Length + 2 < GlobalConstants.consoleRenderSizeWidth - column)
                            {
                                Console.SetCursorPosition(column, GlobalConstants.consoleSizeHeight - 4 + row);
                                Console.Write($" {dialogKeybinds[1][tmpId]} ");
                                column += dialogKeybinds[1][tmpId].Length + 1;
                                tmpId++;
                            }
                        }
                    }
                    break;
                case CombatDialogState.AwaitConfirmDialog:
                    for (int row = 0; row < 3; row++)
                    {
                        for (int column = 1; column < GlobalConstants.consoleRenderSizeWidth && tmpId < dialogKeybinds[2].Length; column++)
                        {
                            if (dialogKeybinds[2][tmpId].Length + 2 < GlobalConstants.consoleRenderSizeWidth - column)
                            {
                                Console.SetCursorPosition(column, GlobalConstants.consoleSizeHeight - 4 + row);
                                Console.Write($" {dialogKeybinds[2][tmpId]} ");
                                column += dialogKeybinds[2][tmpId].Length + 1;
                                tmpId++;
                            }
                        }
                    }
                    break;
            }
        }

        public void NextElement()
        {
            if (currentState == CombatDialogState.SpellDialog && selectedOption < Game.Instance.Player.Spells.Count - 1)
                selectedOption++;
            else if (currentState == CombatDialogState.ItemDialog && selectedOption < Game.Instance.Player.Inventory.Length - 1)
                selectedOption++;
        }

        public void PreviousElement()
        {
            if (currentState == CombatDialogState.SpellDialog && selectedOption > 0)
                selectedOption--;
            else if (currentState == CombatDialogState.ItemDialog && selectedOption > 0)
                selectedOption--;
        }

        public int SelectedOption { get => selectedOption; set => selectedOption = value; }
        public string CombatDialog { get => combatDialog ; set => combatDialog = value; }
        public CombatDialogState CurrentState { get => currentState; set => currentState = value; }
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
            int playerPosX = Game.Instance.Maps[Game.Instance.ActiveMap].PlayerX;
            int playerPosY = Game.Instance.Maps[Game.Instance.ActiveMap].PlayerY;
            int consoleRenderBoxHeight = GlobalConstants.consoleSizeHeight - 4;
            int consoleRenderBoxWidth = GlobalConstants.consoleSizeWidth - 2;

            Console.Clear();

            //Print dynamic render box
            for (int x = 0; x < consoleRenderBoxHeight; x++)
            {
                //divider '='
                if (x == 0 || x == (consoleRenderBoxHeight - 1))
                {
                    Console.Write(new string('=', GlobalConstants.consoleSizeWidth));

                    if (x != (GlobalConstants.consoleSizeHeight - 1))
                        Console.WriteLine();

                    continue;
                }

                for (int y = 0; y < GlobalConstants.consoleSizeWidth; y++)
                {
                    //border 'H'
                    if (y == 0 || y + 1 == GlobalConstants.consoleSizeWidth)
                        Console.Write('H');
                    else
                        Console.Write(' ');
                }

                Console.WriteLine();
            }

            string[] keybinds = ["[ESC/Spacebar/Enter] - Next dialog"];
            int tmpId = 0;

            //print informations box
            for (int x = 0; x < 4; x++)
            {
                //divider '='
                if (x == 3)
                {
                    Console.Write(new string('=', GlobalConstants.consoleSizeWidth));
                    continue;
                }

                for (int y = 0; y < GlobalConstants.consoleSizeWidth; y++)
                {
                    //border 'H'
                    if (y == 0 || y == GlobalConstants.consoleSizeWidth - 1)
                        Console.Write('H');
                    //print keybinds
                    else if (tmpId < keybinds.Length)
                    {
                        if (keybinds[tmpId].Length < (GlobalConstants.consoleSizeWidth - y))
                        {
                            Console.Write($" {keybinds[tmpId]} ");
                            y += keybinds[tmpId].Length + 1;
                            tmpId++;
                        }
                    }
                    //empty
                    else
                        Console.Write(' ');
                }

                Console.WriteLine();
            }
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
            int playerPosX = Game.Instance.Maps[Game.Instance.ActiveMap].PlayerX;
            int playerPosY = Game.Instance.Maps[Game.Instance.ActiveMap].PlayerY;
            int consoleRenderBoxHeight = GlobalConstants.consoleSizeHeight - 4;
            int consoleRenderBoxWidth = GlobalConstants.consoleSizeWidth - 2;

            Console.Clear();

            //Print dynamic render box
            for (int x = 0; x < consoleRenderBoxHeight; x++)
            {
                //divider '='
                if (x == 0 || x == (consoleRenderBoxHeight - 1))
                {
                    Console.Write(new string('=', GlobalConstants.consoleSizeWidth));

                    if (x != (GlobalConstants.consoleSizeHeight - 1))
                        Console.WriteLine();

                    continue;
                }

                for (int y = 0; y < GlobalConstants.consoleSizeWidth; y++)
                {
                    //border 'H'
                    if (y == 0 || y + 1 == GlobalConstants.consoleSizeWidth)
                        Console.Write('H');
                    else
                        Console.Write(' ');
                }

                Console.WriteLine();
            }

            string[] keybinds = ["[ESC] - Resume", "[Spacebar/Enter] - Confirm"];
            int tmpId = 0;

            //print informations box
            for (int x = 0; x < 4; x++)
            {
                //divider '='
                if (x == 3)
                {
                    Console.Write(new string('=', GlobalConstants.consoleSizeWidth));
                    continue;
                }

                for (int y = 0; y < GlobalConstants.consoleSizeWidth; y++)
                {
                    //border 'H'
                    if (y == 0 || y == GlobalConstants.consoleSizeWidth - 1)
                        Console.Write('H');
                    //print keybinds
                    else if (tmpId < keybinds.Length)
                    {
                        if (keybinds[tmpId].Length < (GlobalConstants.consoleSizeWidth - y))
                        {
                            Console.Write($" {keybinds[tmpId]} ");
                            y += keybinds[tmpId].Length + 1;
                            tmpId++;
                        }
                    }
                    //empty
                    else
                        Console.Write(' ');
                }

                Console.WriteLine();
            }
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
            int consoleRenderBoxHeight = GlobalConstants.consoleSizeHeight - 4;
            int consoleRenderBoxWidth = GlobalConstants.consoleSizeWidth - 2;

            Console.Clear();

            //Print dynamic render box
            for (int x = 0; x < consoleRenderBoxHeight; x++)
            {
                //divider '='
                if (x == 0 || x == (consoleRenderBoxHeight - 1))
                {
                    Console.Write(new string('=', GlobalConstants.consoleSizeWidth));

                    if (x != (GlobalConstants.consoleSizeHeight - 1))
                        Console.WriteLine();

                    continue;
                }

                for (int y = 0; y < GlobalConstants.consoleSizeWidth; y++)
                {
                    //border 'H'
                    if (y == 0 || y + 1 == GlobalConstants.consoleSizeWidth)
                        Console.Write('H');
                    else if ((x - 1) == consoleRenderBoxHeight / 2)
                    {
                        int playerPosX = Game.Instance.Maps[Game.Instance.ActiveMap].PlayerX;
                        int playerPosY = Game.Instance.Maps[Game.Instance.ActiveMap].PlayerY;
                        TownNode town = (TownNode)Game.Instance.Maps[Game.Instance.ActiveMap].Map[playerPosX][playerPosY];

                        string text = $"{town.Name} - {town.Description}";
                        string line = $"{new string(' ', (consoleRenderBoxWidth / 2) - (text.Length / 2))}{text}{new string(' ', (consoleRenderBoxWidth / 2) - (text.Length / 2) - 1)}";

                        if (line.Length == consoleRenderBoxWidth)
                            line.Substring(0, line.Length - 1);
                        else if (line.Length == consoleRenderBoxWidth - 1)
                            line += ' ';

                            Console.Write(line);
                        y += line.Length - 1;
                    }
                    else
                        Console.Write(' ');
                }

                Console.WriteLine();
            }

            //string[] keybinds = ["[Q] - Organised combat", $"[W] - Tavern (heal)", $"[E] - Save game", "[ESC] - Exit Town"];
            string[] keybinds = ["[W] - Tavern (heal)", "[ESC] - Exit Town"];
            int tmpId = 0;

            //print informations box
            for (int x = 0; x < 4; x++)
            {
                //divider '='
                if (x == 3)
                {
                    Console.Write(new string('=', GlobalConstants.consoleSizeWidth));
                    continue;
                }

                for (int y = 0; y < GlobalConstants.consoleSizeWidth; y++)
                {
                    //border 'H'
                    if (y == 0 || y == GlobalConstants.consoleSizeWidth - 1)
                        Console.Write('H');
                    //print keybinds
                    else if (tmpId < keybinds.Length)
                    {
                        if (keybinds[tmpId].Length < (GlobalConstants.consoleSizeWidth - y))
                        {
                            Console.Write($" {keybinds[tmpId]} ");
                            y += keybinds[tmpId].Length + 1;
                            tmpId++;
                        }
                    }
                    //empty
                    else
                        Console.Write(' ');
                }

                Console.WriteLine();
            }
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
            int playerPosX = Game.Instance.Maps[Game.Instance.ActiveMap].PlayerX;
            int playerPosY = Game.Instance.Maps[Game.Instance.ActiveMap].PlayerY;
            int consoleRenderBoxHeight = GlobalConstants.consoleSizeHeight - 4;
            int consoleRenderBoxWidth = GlobalConstants.consoleSizeWidth - 2;

            Console.Clear();

            //Print dynamic render box
            for (int x = 0; x < consoleRenderBoxHeight; x++)
            {
                //divider '='
                if (x == 0 || x == (consoleRenderBoxHeight - 1))
                {
                    Console.Write(new string('=', GlobalConstants.consoleSizeWidth));

                    if (x != (GlobalConstants.consoleSizeHeight - 1))
                        Console.WriteLine();

                    continue;
                }

                for (int y = 0; y < GlobalConstants.consoleSizeWidth; y++)
                {
                    //border 'H'
                    if (y == 0 || y + 1 == GlobalConstants.consoleSizeWidth)
                        Console.Write('H');
                    else
                        Console.Write(' ');
                }

                Console.WriteLine();
            }

            string[] keybinds = ["[ESC] - Resume", "[Spacebar/Enter] - Confirm"];
            int tmpId = 0;

            //print informations box
            for (int x = 0; x < 4; x++)
            {
                //divider '='
                if (x == 3)
                {
                    Console.Write(new string('=', GlobalConstants.consoleSizeWidth));
                    continue;
                }

                for (int y = 0; y < GlobalConstants.consoleSizeWidth; y++)
                {
                    //border 'H'
                    if (y == 0 || y == GlobalConstants.consoleSizeWidth - 1)
                        Console.Write('H');
                    //print keybinds
                    else if (tmpId < keybinds.Length)
                    {
                        if (keybinds[tmpId].Length < (GlobalConstants.consoleSizeWidth - y))
                        {
                            Console.Write($" {keybinds[tmpId]} ");
                            y += keybinds[tmpId].Length + 1;
                            tmpId++;
                        }
                    }
                    //empty
                    else
                        Console.Write(' ');
                }

                Console.WriteLine();
            }
        }
    }
}

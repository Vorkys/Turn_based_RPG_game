using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TurnBasedRPG.Source.Core.InputHandlers;
using TurnBasedRPG.Source.Entities;
using TurnBasedRPG.Source.Entities.AllyRoles;
using TurnBasedRPG.Source.GameObjects.Items;
using TurnBasedRPG.Source.GameObjects.Items.ItemTypes;
using TurnBasedRPG.Source.Locations.Nodes;
using TurnBasedRPG.Source.Utils;

namespace TurnBasedRPG.Source.Core.GameStates
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

            string folderPath = "savefiles";

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            saveFilesPath = Directory.GetFiles(folderPath)
                                     .Select(Path.GetFileName)
                                     .OrderBy(filePath => Path.GetFileName(filePath))
                                     .Reverse()
                                     .ToArray();
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
            string[] keybinds = ["[W/S or ^/v arrows] - Move", "[Spacebar/Enter] - Confirm", "[ESC] - Back"];
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
                            Console.SetCursorPosition(GlobalConstants.consoleRenderSizeWidth / 15 - 3, GlobalConstants.consoleSizeHeight / 5 + (1 * selectionRow) + 2);
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
                    else
                    {
                        var sortedSaveFilesNames = saveFilesPath;

                        for (int saveFileNumber = 0; saveFileNumber < saveFilesPath.Length && saveFileNumber < GlobalConstants.consoleRenderSizeHeight / 1.5; saveFileNumber++)
                        {
                            Console.SetCursorPosition(GlobalConstants.consoleRenderSizeWidth / 15, GlobalConstants.consoleSizeHeight / 5 + 2 + saveFileNumber);
                            Console.Write(sortedSaveFilesNames[saveFileNumber]);
                        }
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

        public bool NextSelection()
        {
            //selectedOption < MenuEnum.Count
            if (currentState == MenuState.MainMenu && selectedOption < menuStateLength)
                selectedOption++;
            else if (currentState == MenuState.ContinueMenu && selectedOption < saveFilesPath.Length - 1)
                selectedOption++;
            else
                return false;

            return true;
        }

        public bool PreviousSelection()
        {
            if (currentState == MenuState.MainMenu && selectedOption > 0)
                selectedOption--;
            else if (currentState == MenuState.ContinueMenu && selectedOption > 0)
                selectedOption--;
            else
                return false;

            return true;
        }

        public int SelectedOption { get => selectedOption; set => selectedOption = value; }
        public MenuState CurrentState { get => currentState; set => currentState = value; }

        public string[] SaveFilesPath { get => saveFilesPath; }
    }

    class PauseState : GameState
    {
        private int selectedOption = 0;
        private static string[] pauseMenuOptions = ["Resume", "Save", "Exit"];
        private int pauseMenuWidth = 6 + GlobalConstants.consoleRenderSizeWidth / 4;
        private int pauseMenuHeight = 2 * pauseMenuOptions.Length + 4 - 1;
        private bool gameSaved = false;

        public PauseState()
        {
            InputHandler = new PauseHandler();
        }

        public override void Render()
        {
            for (int line = 0; line < pauseMenuHeight; line++)
            {
                if (line == 0 || line == pauseMenuHeight - 1)
                {
                    Console.SetCursorPosition((GlobalConstants.consoleRenderSizeWidth / 2) - (pauseMenuWidth / 2), (GlobalConstants.consoleRenderSizeHeight / 2) - (pauseMenuHeight / 2) + line);
                    Console.Write('O' + new string('-', pauseMenuWidth - 2) + 'O');
                }
                else if (line % 2 == 1)
                {
                    Console.SetCursorPosition((GlobalConstants.consoleRenderSizeWidth / 2) - (pauseMenuWidth / 2), (GlobalConstants.consoleRenderSizeHeight / 2) - (pauseMenuHeight / 2) + line);
                    Console.Write('|' + new string(' ', pauseMenuWidth - 2) + '|');
                }
                else
                {
                    Console.SetCursorPosition((GlobalConstants.consoleRenderSizeWidth / 2) - (pauseMenuWidth / 2), (GlobalConstants.consoleRenderSizeHeight / 2) - (pauseMenuHeight / 2) + line);
                    Console.Write('|' + "    " + pauseMenuOptions[(line / 2) - 1] + new string(' ', pauseMenuWidth - (4 + pauseMenuOptions[(line / 2) - 1].Length + 2)) + '|');
                }
            }

            //clear control box
            for (int row = 0; row < 4; row++)
            {
                Console.SetCursorPosition(0, GlobalConstants.consoleSizeHeight - 4 + row);
                Console.Write(new string(' ', GlobalConstants.consoleSizeWidth));
            }

            Console.SetCursorPosition(0, GlobalConstants.consoleSizeHeight - 4);
            //Print control box
            string[] keybinds = ["[W/S or ^/v arrows] - Move", "[Spacebar/Enter] - Confirm", "[ESC] - Resume"];
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

        public override void Update()
        {
            //clear previous selection indicator
            for (int line = 0; line < pauseMenuOptions.Length; line++)
            {
                Console.SetCursorPosition((GlobalConstants.consoleRenderSizeWidth / 2) - (pauseMenuWidth / 2) + 2, (GlobalConstants.consoleRenderSizeHeight / 2) - (pauseMenuHeight / 2) + 2 + (2 * line));
                Console.Write("  ");
            }

            Console.SetCursorPosition((GlobalConstants.consoleRenderSizeWidth / 2) - (pauseMenuWidth / 2) + 2, (GlobalConstants.consoleRenderSizeHeight / 2) - (pauseMenuHeight / 2) + 2 + (2 * selectedOption));
            Console.Write(">>");

            if (gameSaved == true)
            {
                Console.SetCursorPosition((GlobalConstants.consoleRenderSizeWidth / 2) - (pauseMenuWidth / 2) + 5 + pauseMenuOptions[1].Length, (GlobalConstants.consoleRenderSizeHeight / 2) - (pauseMenuHeight / 2) + 2 + (2));
                Console.Write("d");
            }

            //move cursor back to end for better experience
            Console.SetCursorPosition(GlobalConstants.consoleSizeWidth - 1, GlobalConstants.consoleSizeHeight - 1);
        }

        public bool NextSelection()
        {
            //selectedOption < MenuEnum.Count
            if (selectedOption < pauseMenuOptions.Length - 1)
                selectedOption++;
            else
                return false;

            return true;
        }

        public bool PreviousSelection()
        {
            if (selectedOption > 0)
                selectedOption--;
            else
                return false;

            return true;
        }

        public int SelectedOption { get => selectedOption; set => selectedOption = value; }
        public bool GameSaved { set => gameSaved = value; }
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
            string[] keybinds = ["[W/S/A/D or arrows] - Move", "[I] - Inventory", "[ESC] - Pause"];
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

        public bool NextElement()
        {
            if (currentState == CombatDialogState.SpellDialog && selectedOption < Game.Instance.Player.Spells.Count - 1)
                selectedOption++;
            else if (currentState == CombatDialogState.ItemDialog && selectedOption < Game.Instance.Player.Inventory.Length - 1)
                selectedOption++;
            else
                return false;

            return true;
        }

        public bool PreviousElement()
        {
            if (currentState == CombatDialogState.SpellDialog && selectedOption > 0)
                selectedOption--;
            else if (currentState == CombatDialogState.ItemDialog && selectedOption > 0)
                selectedOption--;
            else
                return false;

            return true;
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
            string[] keybinds = ["[ESC/Spacebar/Enter] - Next dialog"];
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

            throw new NotImplementedException();
        }

        public override void Update()
        {
            //move cursor back to end for better experience
            Console.SetCursorPosition(GlobalConstants.consoleSizeWidth - 1, GlobalConstants.consoleSizeHeight - 1);

            throw new NotImplementedException();
        }
    }

    class InventoryState : GameState
    {
        public enum InventoryDialogState
        {
            SpellDialog,
            ItemDialog
        }
        private InventoryDialogState currentState = InventoryDialogState.ItemDialog;
        private static string[] statLabels = { "Name", "Level", "Health", "Mana", "Experience", "Damage", "Armor", "Speed", "Money" };
        private static string[] stickman =
            {
                 "___",
                "/   \\",
               "|     |",
               "\\___/",
                  "|",
                 "/|\\",
                "/ | \\",
               "/  |  \\",
                  "|",
                 "/ \\",
                "/   \\",
               "/     \\",
               "",
               "nnnn",
              "\\__|",
              "",
              "nnnn",
              "|__/"
            };
        private static int maxStickmanStringLength = stickman.Max(row => row.Length);
        private int selectedOption = 0;

        public InventoryState()
        {
            InputHandler = new InventoryHandler();
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
            string[] keybinds = ["[A/<] - Previous selection", "[D/>] - Next selection", "[S/v] - Switch to Spells/Inventory", "[ESC] - Resume", "[Spacebar/Enter] - Equip", "[1-6] - Unequip slot (need free Inv space)"];
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

            //Print Player info
            //Print player sprite
            Game.Instance.Player.LoadSprite();

            for (int row = 0; row < Game.Instance.Player.Sprite.Length; row++)
            {
                Console.SetCursorPosition(1, 1 + row);
                Console.Write(Game.Instance.Player.Sprite[row]);
            }

            int statsRowStart = Game.Instance.Player.Sprite.Length + 2;
            int maxLabelStringLength = statLabels.Max(label => label.Length);
            int entityBarPercent;

            //Print Player stats (Name, Lvl, HP, MP, XP, DMG, DEF, SPD, Money)
            for (int row = 0; row < statLabels.Length; row++)
            {
                switch (row)
                {
                    //Name
                    case 0:
                        int entityNameAllowedLength = 33 - (3 + Game.Instance.Player.MaxLevel.ToString().Length);
                        int entityNameLength = Game.Instance.Player.Name.Length;
                        string entityName = entityNameLength < entityNameAllowedLength ? Game.Instance.Player.Name : Game.Instance.Player.Name.Substring(0, entityNameAllowedLength - 3) + "...";
                        Console.SetCursorPosition(2 + maxLabelStringLength - statLabels[row].Length, statsRowStart + row);
                        Console.Write($"{statLabels[row]}: {entityName}");
                        break;
                    //Level
                    case 1:
                        Console.SetCursorPosition(2 + maxLabelStringLength - statLabels[row].Length, statsRowStart + row);
                        Console.Write($"{statLabels[row]}: {Game.Instance.Player.Level}");
                        break;
                    //HP
                    case 2:
                        Console.SetCursorPosition(2 + maxLabelStringLength - statLabels[row].Length, statsRowStart + row);
                        Console.Write($"{statLabels[row]}: ");
                        entityBarPercent = Game.Instance.Player.Health > 0 ? (Game.Instance.Player.Health * 30) / Game.Instance.Player.MaxHealth : 0;
                        Console.Write('<');
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(new string('=', entityBarPercent));
                        Console.ResetColor();
                        Console.Write(new string('-', 30 - entityBarPercent));
                        Console.Write('>');
                        Console.Write($" {Game.Instance.Player.Health}/{Game.Instance.Player.MaxHealth}");
                        break;
                    //MP
                    case 3:
                        Console.SetCursorPosition(2 + maxLabelStringLength - statLabels[row].Length, statsRowStart + row);
                        Console.Write($"{statLabels[row]}: ");
                        entityBarPercent = (Game.Instance.Player.Mana * 30) / Game.Instance.Player.MaxMana;
                        Console.Write('<');
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(new string('~', entityBarPercent));
                        Console.ResetColor();
                        Console.Write(new string('-', 30 - entityBarPercent));
                        Console.Write('>');
                        Console.Write($" {Game.Instance.Player.Mana}/{Game.Instance.Player.MaxMana}");
                        break;
                    //XP
                    case 4:
                        Console.SetCursorPosition(2 + maxLabelStringLength - statLabels[row].Length, statsRowStart + row);
                        Console.Write($"{statLabels[row]}: ");
                        entityBarPercent = (Game.Instance.Player.EntityXP * 30) / Game.Instance.Player.XPtoLevelUp;
                        Console.Write('|');
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(new string('=', entityBarPercent));
                        Console.ResetColor();
                        Console.Write(new string('-', 30 - entityBarPercent));
                        Console.Write('|');
                        Console.Write($" {Game.Instance.Player.EntityXP}/{Game.Instance.Player.XPtoLevelUp}");
                        break;
                    //DMG
                    case 5:
                        Console.SetCursorPosition(2 + maxLabelStringLength - statLabels[row].Length, statsRowStart + row);
                        Console.Write($"{statLabels[row]}: {Game.Instance.Player.Damage}");
                        break;
                    //DEF
                    case 6:
                        Console.SetCursorPosition(2 + maxLabelStringLength - statLabels[row].Length, statsRowStart + row);
                        Console.Write($"{statLabels[row]}: {Game.Instance.Player.Armor}");
                        break;
                    //SPD
                    case 7:
                        Console.SetCursorPosition(2 + maxLabelStringLength - statLabels[row].Length, statsRowStart + row);
                        Console.Write($"{statLabels[row]}: {Game.Instance.Player.Speed}");
                        break;
                    case 8:
                        Console.SetCursorPosition(2 + maxLabelStringLength - statLabels[row].Length, statsRowStart + row);
                        Console.Write($"{statLabels[row]}: {Game.Instance.Player.Money}");
                        break;
                }
            }

            //Print stickman for equipment
            for (int row = 0; row < stickman.Length; row++)
            {
                //Console Width - percent of console width (so it isnt sticked to border) - center of stickman - start of current stickman row
                Console.SetCursorPosition(GlobalConstants.consoleRenderSizeWidth - (GlobalConstants.consoleRenderSizeWidth / 25) - (maxStickmanStringLength / 2) - (stickman[row].Length / 2), 2 + row);
                Console.Write(stickman[row]);
            }

            //Print equipped lines
            for (int equippedItem = 0; equippedItem < Game.Instance.Player.Equipment.Length; equippedItem++)
            {
                int equippedItemLine = 0;

                switch (equippedItem)
                {
                    case 0:
                        equippedItemLine = 2;
                        break;
                    case 1:
                        equippedItemLine = 4;
                        break;
                    case 2:
                        equippedItemLine = 7;
                        break;
                    case 3:
                        equippedItemLine = 10;
                        break;
                    case 4:
                        equippedItemLine = 13;
                        break;
                    case 5:
                        equippedItemLine = 17;
                        break;
                }

                Console.SetCursorPosition(GlobalConstants.consoleRenderSizeWidth - (GlobalConstants.consoleRenderSizeWidth / 25) - maxStickmanStringLength - 4, 2 + equippedItemLine);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(new string('_', 4 + ((maxStickmanStringLength / 2) - (stickman[equippedItemLine].Length / 2)) + 1));
                Console.ResetColor();
            }

            UpdateStats();
            UpdateEquipment();
            UpdateCurrentOpenedMenuLabel();
        }

        public override void Update()
        {
            int maxItemNameLength = 20;
            int maxDialogLength = 80;
            int dialogRowStart = 1 + Game.Instance.Player.Sprite.Length + 2 + statLabels.Length + 2;

            switch (currentState)
            {
                case InventoryDialogState.ItemDialog:
                    string itemName = Game.Instance.Player.Inventory[SelectedOption] == null ? "-----" : Game.Instance.Player.Inventory[SelectedOption].Name;
                    itemName = itemName.Length < maxItemNameLength ? itemName : string.Concat(itemName.AsSpan(0, maxItemNameLength - 3), "...");
                    string itemDescription = Game.Instance.Player.Inventory[SelectedOption] == null ? "Empty space in your pocket" : Game.Instance.Player.Inventory[SelectedOption].Description;
                    itemDescription = itemDescription.Length <= maxDialogLength ? itemDescription : string.Concat(itemDescription.AsSpan(0, maxDialogLength - 3), "...");

                    Console.SetCursorPosition(2, dialogRowStart);
                    Console.Write(new string(' ', maxDialogLength));
                    Console.SetCursorPosition(2, dialogRowStart);
                    Console.Write($"<< {selectedOption + 1}/{Game.Instance.Player.Inventory.Length} {itemName} ");
                    if (Game.Instance.Player.Inventory[selectedOption] != null)
                    {
                        Console.Write('(');
                        switch (Game.Instance.Player.Inventory[selectedOption])
                        {
                            case HealingItem:
                            case ManaIncreaseItem:
                            case HybridHealingItem:
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(Game.Instance.Player.Inventory[selectedOption].Quantity);
                                Console.ResetColor();
                                break;
                            case Equippable:
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write('E');
                                Console.ResetColor();
                                break;
                            default:
                                Console.Write(Game.Instance.Player.Inventory[selectedOption].Quantity);
                                break;
                        }
                        Console.Write(')');
                    }
                    Console.Write(" >>");
                    //Desc
                    Console.SetCursorPosition(2, dialogRowStart + 1);
                    Console.Write(new string(' ', maxDialogLength));
                    Console.SetCursorPosition(2, dialogRowStart + 1);
                    Console.Write(itemDescription);
                    break;
                case InventoryDialogState.SpellDialog:
                    if (Game.Instance.Player.Spells.Count == 0)
                    {
                        Console.SetCursorPosition(2, dialogRowStart);
                        Console.Write(new string(' ', maxDialogLength));
                        Console.SetCursorPosition(2, dialogRowStart + 1);
                        Console.Write(new string(' ', maxDialogLength));
                        Console.SetCursorPosition(2, dialogRowStart);
                        Console.Write(" You dont have any spells yet.");
                    }
                    else
                    {
                        string spellName = Game.Instance.Player.Spells[selectedOption].Name.Length < maxItemNameLength ? Game.Instance.Player.Spells[selectedOption].Name : string.Concat(Game.Instance.Player.Spells[selectedOption].Name.AsSpan(0, maxItemNameLength - 3), "...");
                        string spellDescription = Game.Instance.Player.Spells[selectedOption].Description.Length + 2 <= maxDialogLength ? Game.Instance.Player.Spells[selectedOption].Description : string.Concat(Game.Instance.Player.Spells[selectedOption].Description.AsSpan(0, maxDialogLength - 3), "...");

                        Console.SetCursorPosition(2, dialogRowStart);
                        Console.Write(new string(' ', maxDialogLength));
                        Console.SetCursorPosition(2, dialogRowStart);
                        Console.Write($"<< {selectedOption + 1}/{Game.Instance.Player.Spells.Count} {spellName} ({Game.Instance.Player.Spells[selectedOption].Cost}) >>");
                        Console.SetCursorPosition(2, dialogRowStart + 1);
                        Console.Write(new string(' ', maxDialogLength));
                        Console.SetCursorPosition(2, dialogRowStart + 1);
                        Console.Write(spellDescription);
                    }
                    break;
            }

            //move cursor back to end for better experience
            Console.SetCursorPosition(GlobalConstants.consoleSizeWidth - 1, GlobalConstants.consoleSizeHeight - 1);

            //throw new NotImplementedException();
        }

        public void UpdateEquipment()
        {
            int maxItemNameLength = GlobalConstants.consoleRenderSizeWidth / 8;

            for (int equippedItem = 0; equippedItem < Game.Instance.Player.Equipment.Length; equippedItem++)
            {
                int equippedItemLine = 0;
                string itemName = Game.Instance.Player.Equipment[equippedItem] == null ? "No item" : Game.Instance.Player.Equipment[equippedItem].Name;
                itemName = itemName.Length < maxItemNameLength ? itemName : string.Concat(itemName.AsSpan(0, maxItemNameLength - 3), "...");

                switch (equippedItem)
                {
                    case 0:
                        equippedItemLine = 2;
                        break;
                    case 1:
                        equippedItemLine = 4;
                        break;
                    case 2:
                        equippedItemLine = 7;
                        break;
                    case 3:
                        equippedItemLine = 10;
                        break;
                    case 4:
                        equippedItemLine = 13;
                        break;
                    case 5:
                        equippedItemLine = 17;
                        break;
                }

                Console.SetCursorPosition(GlobalConstants.consoleRenderSizeWidth - (GlobalConstants.consoleRenderSizeWidth / 25) - maxStickmanStringLength - 4 - (maxItemNameLength + 1), 2 + equippedItemLine);
                    Console.Write(new string(' ', maxItemNameLength - itemName.Length) + itemName);
            }
        }

        public void UpdateStats()
        {
            int statsRowStart = Game.Instance.Player.Sprite.Length + 4;
            int maxLabelStringLength = statLabels.Max(label => label.Length);
            int entityBarPercent;

            //Update Player stats (HP, MP, XP, DMG, DEF, SPD)
            for (int row = 0; row < 6; row++)
            {
                switch (row)
                {
                    //HP
                    case 0:
                        Console.SetCursorPosition(2 + maxLabelStringLength + 2, statsRowStart + row);
                        entityBarPercent = Game.Instance.Player.Health > 0 ? (Game.Instance.Player.Health * 30) / Game.Instance.Player.MaxHealth : 0;
                        Console.Write('<');
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(new string('=', entityBarPercent));
                        Console.ResetColor();
                        Console.Write(new string('-', 30 - entityBarPercent));
                        Console.Write('>');
                        Console.Write($" {Game.Instance.Player.Health}/{Game.Instance.Player.MaxHealth}");
                        break;
                    //MP
                    case 1:
                        Console.SetCursorPosition(2 + maxLabelStringLength + 2, statsRowStart + row);
                        entityBarPercent = (Game.Instance.Player.Mana * 30) / Game.Instance.Player.MaxMana;
                        Console.Write('<');
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(new string('~', entityBarPercent));
                        Console.ResetColor();
                        Console.Write(new string('-', 30 - entityBarPercent));
                        Console.Write('>');
                        Console.Write($" {Game.Instance.Player.Mana}/{Game.Instance.Player.MaxMana}");
                        break;
                    //XP
                    case 2:
                        Console.SetCursorPosition(2 + maxLabelStringLength + 2, statsRowStart + row);
                        entityBarPercent = (Game.Instance.Player.EntityXP * 30) / Game.Instance.Player.XPtoLevelUp;
                        Console.Write('|');
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(new string('=', entityBarPercent));
                        Console.ResetColor();
                        Console.Write(new string('-', 30 - entityBarPercent));
                        Console.Write('|');
                        Console.Write($" {Game.Instance.Player.EntityXP}/{Game.Instance.Player.XPtoLevelUp}");
                        break;
                    //DMG
                    case 3:
                        //Clear previous value
                        Console.SetCursorPosition(2 + maxLabelStringLength + 2, statsRowStart + row);
                        Console.Write("     ");
                        //Update value
                        Console.SetCursorPosition(2 + maxLabelStringLength + 2, statsRowStart + row);
                        Console.Write(Game.Instance.Player.Damage);
                        break;
                    //DEF
                    case 4:
                        //Clear previous value
                        Console.SetCursorPosition(2 + maxLabelStringLength + 2, statsRowStart + row);
                        Console.Write("     ");
                        //Update value
                        Console.SetCursorPosition(2 + maxLabelStringLength + 2, statsRowStart + row);
                        Console.Write(Game.Instance.Player.Armor);
                        break;
                    //SPD
                    case 5:
                        //Clear previous value
                        Console.SetCursorPosition(2 + maxLabelStringLength + 2, statsRowStart + row);
                        Console.Write("     ");
                        //Update value
                        Console.SetCursorPosition(2 + maxLabelStringLength + 2, statsRowStart + row);
                        Console.Write(Game.Instance.Player.Speed);
                        break;
                    case 6:
                        Console.SetCursorPosition(2 + maxLabelStringLength + 2, statsRowStart + row);
                        Console.Write("     ");
                        //Update value
                        Console.SetCursorPosition(2 + maxLabelStringLength + 2, statsRowStart + row);
                        Console.Write($"{Game.Instance.Player.Money}");
                        break;
                }
            }
        }

        public void UpdateCurrentOpenedMenuLabel()
        {
            int dialogRowStart = Game.Instance.Player.Sprite.Length + 2 + statLabels.Length + 2;

            Console.SetCursorPosition(2, dialogRowStart);
            Console.Write(new string(' ', 10));

            Console.SetCursorPosition(2, dialogRowStart);
            if (currentState == InventoryDialogState.ItemDialog)
                Console.Write("Inventory:");
            else
                Console.Write("Spells:");
        }

        public bool NextElement()
        {
            if (currentState == InventoryDialogState.SpellDialog && selectedOption < Game.Instance.Player.Spells.Count - 1)
                selectedOption++;
            else if (currentState == InventoryDialogState.ItemDialog && selectedOption < Game.Instance.Player.Inventory.Length - 1)
                selectedOption++;
            else
                return false;

            return true;
        }

        public bool PreviousElement()
        {
            if (selectedOption > 0)
                selectedOption--;
            else
                return false;

            return true;
        }

        public int SelectedOption { get => selectedOption; set => selectedOption = value; }
        public InventoryDialogState CurrentState { get => currentState; set => currentState = value; }
    }

    class JournalState : GameState
    {
        public JournalState()
        {
            InputHandler = new JournalHandler();
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
            string[] keybinds = ["[ESC] - Resume", "[Spacebar/Enter] - Confirm"];
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

            throw new NotImplementedException();
        }

        public override void Update()
        {
            //move cursor back to end for better experience
            Console.SetCursorPosition(GlobalConstants.consoleSizeWidth - 1, GlobalConstants.consoleSizeHeight - 1);

            throw new NotImplementedException();
        }
    }

    class TownState : GameState
    {
        public enum TownNodeState
        {
            TownInfo,
            MerchantSell,
            MerchantBuy,
            QuestGiver
        }
        private TownNodeState currentState = TownNodeState.TownInfo;
        private int selectedOption = 0;

        public TownState()
        {
            InputHandler = new TownHandler();
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

            TownNode castCurrentNode = (TownNode)Game.Instance.Maps[Game.Instance.ActiveMap].Map[Game.Instance.Maps[Game.Instance.ActiveMap].PlayerX][Game.Instance.Maps[Game.Instance.ActiveMap].PlayerY];

            //Print control box
            List<string> keybinds = new List<string> { "[Q] - Tavern (heal)" };
            int tmpId = 0;

            if (castCurrentNode.TownPeople != null)
            {
                foreach (Ally ally in castCurrentNode.TownPeople)
                {
                    switch (ally)
                    {
                        case ArenaOrganisator:
                            ArenaOrganisator castEntity = (ArenaOrganisator)ally;
                            int enemyMinLvl = castEntity.Enemies[0].Level;
                            int enemyMaxLvl = castEntity.Enemies[0].MaxLevel;

                            foreach (Enemy enemy in castEntity.Enemies)
                            {
                                if (enemy.Level < enemyMinLvl)
                                    enemyMinLvl = enemy.Level;
                                if (enemy.MaxLevel > enemyMaxLvl)
                                    enemyMaxLvl = enemy.MaxLevel;
                            }

                            if (!keybinds.Contains($"[W] - Arena fight (Enemy level: {enemyMinLvl}-{enemyMaxLvl})"))
                                keybinds.Add($"[W] - Arena fight (Enemy level: {enemyMinLvl}-{enemyMaxLvl})");
                            break;
                        case Merchant:
                            if (!keybinds.Contains("[E] - Sell Items"))
                            {
                                keybinds.Add("[E] - Sell Items");
                                keybinds.Add("[R] - Buy Items");
                            }
                            break;
                        case QuestGiver:
                            if (!keybinds.Contains("[T] - Quest giver"))
                                keybinds.Add("[T] - Quest giver");
                            break;
                    }
                }
            }
            keybinds.Add("[Spacebar/Enter] - Confirm");
            keybinds.Add("[ESC] - Back/Exit Town");

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
                    else if (tmpId < keybinds.Count && (keybinds[tmpId].Length < GlobalConstants.consoleRenderSizeWidth - column))
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

            //Render Current Town State
            switch (currentState)
            {
                case TownNodeState.TownInfo:
                    RenderTownState();
                    break;
                case TownNodeState.MerchantSell:
                case TownNodeState.MerchantBuy:
                    RenderTownState();
                    break;
                case TownNodeState.QuestGiver:
                    break;
            }
        }

        public override void Update()
        {
            //TODO - implement town rendering using switch case for Merchant and quest giver (Arena Orga needs to be added to end of combat (if end of combat and current node is Town them open town, otherwise explorationState)
            switch (currentState)
            {
                case TownNodeState.TownInfo:
                    RenderTownState();
                    break;
                case TownNodeState.MerchantSell:
                    RenderTownState();
                    //Print item name and description on the middle of screen
                    int leftSideStart = GlobalConstants.consoleRenderSizeWidth / 6;
                    int topSideStart = GlobalConstants.consoleRenderSizeHeight / 2;
                    int maxNameLength = GlobalConstants.consoleRenderSizeWidth / 2;

                    //Clear items names
                    int row = 1;
                    while(row < GlobalConstants.consoleRenderSizeHeight - 1)
                    {
                        Console.SetCursorPosition(leftSideStart, row);
                        Console.Write(new string(' ', GlobalConstants.consoleRenderSizeWidth - (GlobalConstants.consoleRenderSizeWidth / 4) + 1));
                        row++;
                    }

                    //Print name
                    Console.SetCursorPosition(leftSideStart + 1, topSideStart);
                    if (Game.Instance.Player.Inventory[selectedOption] == null)
                        Console.Write("-----");
                    else
                        Console.Write(Game.Instance.Player.Inventory[selectedOption].Name.Length < maxNameLength ? Game.Instance.Player.Inventory[selectedOption].Name : Game.Instance.Player.Inventory[selectedOption].Name.Substring(0, maxNameLength - 3) + "...");
                    //Print sell price
                    if (Game.Instance.Player.Inventory[selectedOption] != null)
                        Console.Write($" | Sell for: {Game.Instance.Player.Inventory[selectedOption].SellPrice}");
                    //Print Desc
                    Console.SetCursorPosition(leftSideStart + 1, topSideStart + 2);
                    int start = 0; int end = 0;

                    //Horizontal length of text == GlobalConstants.consoleRenderSizeWidth - (GlobalConstants.consoleRenderSizeWidth / 4)

                    for (int descRow = 0; descRow < 3; descRow++)
                    {
                        Console.SetCursorPosition(leftSideStart + 1, topSideStart + 2 + descRow);

                        if (Game.Instance.Player.Inventory[selectedOption] == null)
                        {
                            Console.Write("No description");
                            break;
                        }

                        //Missing description can be written fully
                        if (Game.Instance.Player.Inventory[selectedOption].Description.Length - start < GlobalConstants.consoleRenderSizeWidth - (GlobalConstants.consoleRenderSizeWidth / 4))
                        {
                            Console.Write(Game.Instance.Player.Inventory[selectedOption].Description);
                            break;
                        }
                        else
                        {
                            end = start + GlobalConstants.consoleRenderSizeWidth - (GlobalConstants.consoleRenderSizeWidth / 4) > Game.Instance.Player.Inventory[selectedOption].Description.Length ? start + (Game.Instance.Player.Inventory[selectedOption].Description.Length - start) : start + GlobalConstants.consoleRenderSizeWidth - (GlobalConstants.consoleRenderSizeWidth / 4);
                            char tmpChar = Game.Instance.Player.Inventory[selectedOption].Description[start + end];

                            while (tmpChar != ' ')
                            {
                                tmpChar = Game.Instance.Player.Inventory[selectedOption].Description[start + end];
                            }
                        }
                    }

                    //Print item names above current selection
                    int itemRow = 1;
                    while (topSideStart - 2 - itemRow > 2 && selectedOption - itemRow >= 0)
                    {
                        Console.SetCursorPosition(leftSideStart, topSideStart - 1 - itemRow);
                        if (Game.Instance.Player.Inventory[selectedOption - itemRow] == null)
                            Console.Write("-----");
                        else
                            Console.Write(Game.Instance.Player.Inventory[selectedOption - itemRow].Name.Length < maxNameLength ? Game.Instance.Player.Inventory[selectedOption - itemRow].Name : Game.Instance.Player.Inventory[selectedOption].Name.Substring(0, maxNameLength - 3) + "...");
                        itemRow++;
                    }
                    //Repeat for items below
                    itemRow = 1;
                    while (topSideStart + 5 + itemRow < GlobalConstants.consoleRenderSizeHeight && selectedOption + itemRow < Game.Instance.Player.Inventory.Count())
                    {
                        Console.SetCursorPosition(leftSideStart, topSideStart + 4 + itemRow);
                        if (Game.Instance.Player.Inventory[selectedOption + itemRow] == null)
                            Console.Write("-----");
                        else
                            Console.Write(Game.Instance.Player.Inventory[selectedOption + itemRow].Name.Length < maxNameLength ? Game.Instance.Player.Inventory[selectedOption + itemRow].Name : Game.Instance.Player.Inventory[selectedOption].Name.Substring(0, maxNameLength - 3) + "...");
                        itemRow++;
                    }
                    break;
                case TownNodeState.MerchantBuy:
                    RenderTownState();
                    //Print item name and description on the middle of screen
                    leftSideStart = GlobalConstants.consoleRenderSizeWidth / 6;
                    topSideStart = GlobalConstants.consoleRenderSizeHeight / 2;
                    maxNameLength = GlobalConstants.consoleRenderSizeWidth / 2;

                    TownNode castCurrentNode = (TownNode)Game.Instance.Maps[Game.Instance.ActiveMap].Map[Game.Instance.Maps[Game.Instance.ActiveMap].PlayerX][Game.Instance.Maps[Game.Instance.ActiveMap].PlayerY];
                    Merchant townMerchant = null;

                    foreach (Ally NPC in castCurrentNode.TownPeople)
                        if (NPC is Merchant)
                            townMerchant = (Merchant)NPC;

                    //Clear items names
                    row = 1;
                    while (row < GlobalConstants.consoleRenderSizeHeight - 1)
                    {
                        Console.SetCursorPosition(leftSideStart, row);
                        Console.Write(new string(' ', GlobalConstants.consoleRenderSizeWidth - (GlobalConstants.consoleRenderSizeWidth / 4) + 1));
                        row++;
                    }

                    //Print name
                    Console.SetCursorPosition(leftSideStart + 1, topSideStart);
                    if (townMerchant.Wares[selectedOption] == null)
                        Console.Write("-----");
                    else
                        Console.Write(townMerchant.Wares[selectedOption].Name.Length < maxNameLength ? townMerchant.Wares[selectedOption].Name : townMerchant.Wares[selectedOption].Name.Substring(0, maxNameLength - 3) + "...");
                    //Print buy price
                    if (townMerchant.Wares[selectedOption] != null)
                        Console.Write($" | Buy for: {townMerchant.Wares[selectedOption].BuyPrice}");
                    //Print Desc
                    Console.SetCursorPosition(leftSideStart + 1, topSideStart + 2);
                    start = 0;end = 0;

                    //Horizontal length of text == GlobalConstants.consoleRenderSizeWidth - (GlobalConstants.consoleRenderSizeWidth / 4)

                    for (int descRow = 0; descRow < 3; descRow++)
                    {
                        Console.SetCursorPosition(leftSideStart + 1, topSideStart + 2 + descRow);

                        if (townMerchant.Wares[selectedOption] == null)
                        {
                            Console.Write("No description");
                            break;
                        }

                        //Missing description can be written fully
                        if (townMerchant.Wares[selectedOption].Description.Length - start < GlobalConstants.consoleRenderSizeWidth - (GlobalConstants.consoleRenderSizeWidth / 4))
                        {
                            Console.Write(townMerchant.Wares[selectedOption].Description);
                            break;
                        }
                        else
                        {
                            end = start + GlobalConstants.consoleRenderSizeWidth - (GlobalConstants.consoleRenderSizeWidth / 4) > townMerchant.Wares[selectedOption].Description.Length ? start + (townMerchant.Wares[selectedOption].Description.Length - start) : start + GlobalConstants.consoleRenderSizeWidth - (GlobalConstants.consoleRenderSizeWidth / 4);
                            char tmpChar = townMerchant.Wares[selectedOption].Description[start + end];

                            while (tmpChar != ' ')
                            {
                                tmpChar = townMerchant.Wares[selectedOption].Description[start + end];
                            }
                        }
                    }

                    //Print item names above current selection
                    itemRow = 1;
                    while (topSideStart - 2 - itemRow > 2 && selectedOption - itemRow >= 0)
                    {
                        Console.SetCursorPosition(leftSideStart, topSideStart - 1 - itemRow);
                        if (townMerchant.Wares[selectedOption - itemRow] == null)
                            Console.Write("-----");
                        else
                            Console.Write(townMerchant.Wares[selectedOption - itemRow].Name.Length < maxNameLength ? townMerchant.Wares[selectedOption - itemRow].Name : townMerchant.Wares[selectedOption].Name.Substring(0, maxNameLength - 3) + "...");
                        itemRow++;
                    }
                    //Repeat for items below
                    itemRow = 1;
                    while (topSideStart + 5 + itemRow < GlobalConstants.consoleRenderSizeHeight && selectedOption + itemRow < townMerchant.Wares.Count())
                    {
                        Console.SetCursorPosition(leftSideStart, topSideStart + 4 + itemRow);
                        if (townMerchant.Wares[selectedOption + itemRow] == null)
                            Console.Write("-----");
                        else
                            Console.Write(townMerchant.Wares[selectedOption + itemRow].Name.Length < maxNameLength ? townMerchant.Wares[selectedOption + itemRow].Name : townMerchant.Wares[selectedOption].Name.Substring(0, maxNameLength - 3) + "...");
                        itemRow++;
                    }
                    break;
                case TownNodeState.QuestGiver:
                    break;
            }

            //move cursor back to end for better experience
            Console.SetCursorPosition(GlobalConstants.consoleSizeWidth - 1, GlobalConstants.consoleSizeHeight - 1);

            //TODO - implement town rendering?
            //throw new NotImplementedException();
        }

        private void RenderTownState()
        {
            TownNode castCurrentNode = (TownNode)Game.Instance.Maps[Game.Instance.ActiveMap].Map[Game.Instance.Maps[Game.Instance.ActiveMap].PlayerX][Game.Instance.Maps[Game.Instance.ActiveMap].PlayerY];

            switch (currentState)
            {
                case TownNodeState.TownInfo:
                    //clear render screen
                    int row = 1;
                    while (row < GlobalConstants.consoleRenderSizeHeight - 1)
                    {
                        Console.SetCursorPosition(1, row);
                        Console.Write(new string(' ', GlobalConstants.consoleRenderSizeWidth));
                        row++;
                    }

                    //Print name
                    Console.SetCursorPosition(GlobalConstants.consoleSizeWidth / 2 - castCurrentNode.Name.Length / 2, GlobalConstants.consoleRenderSizeHeight - 6);
                    Console.Write(castCurrentNode.Name);

                    //Print description
                    int start = 0, end = 0;

                    //Horizontal length of text == GlobalConstants.consoleRenderSizeWidth - (2 * GlobalConstants.consoleRenderSizeWidth / 8)
                    for (row = 0; row < 3; row++)
                    {
                        Console.SetCursorPosition(GlobalConstants.consoleRenderSizeWidth / 8, GlobalConstants.consoleRenderSizeHeight - 4 + row);

                        //Missing description can be written fully
                        if (castCurrentNode.Description.Length - start < GlobalConstants.consoleRenderSizeWidth - (2 * GlobalConstants.consoleRenderSizeWidth / 8))
                        {
                            Console.Write(castCurrentNode.Description);
                            break;
                        }
                        else
                        {
                            end = start + GlobalConstants.consoleRenderSizeWidth - (2 * GlobalConstants.consoleRenderSizeWidth / 8) > castCurrentNode.Description.Length ? start + (castCurrentNode.Description.Length - start) : start + GlobalConstants.consoleRenderSizeWidth - (2 * GlobalConstants.consoleRenderSizeWidth / 8);
                            char tmpChar = castCurrentNode.Description[start + end];

                            while (tmpChar != ' ')
                            {
                                tmpChar = castCurrentNode.Description[start + end];
                            }
                        }
                    }
                    break;
                case TownNodeState.MerchantSell:
                case TownNodeState.MerchantBuy:
                    //clear render screen
                    row = 1;
                    while (row < GlobalConstants.consoleRenderSizeHeight - 1)
                    {
                        Console.SetCursorPosition(1, row);
                        Console.Write(new string(' ', GlobalConstants.consoleRenderSizeWidth));
                        row++;
                    }

                    int leftSideStart = GlobalConstants.consoleRenderSizeWidth / 6;
                    int topSideStart = GlobalConstants.consoleRenderSizeHeight / 2;

                    for (row = 0; row < 5; row++)
                    {
                        Console.SetCursorPosition(leftSideStart - 2, topSideStart - 2 + row);
                        switch (row)
                        {
                            case 0:
                            case 1:
                                Console.Write('^');
                                break;
                            case 2:
                                Console.Write('-');
                                break;
                            case 3:
                            case 4:
                                Console.Write('v');
                                break;
                        }
                    }
                    break;
                case TownNodeState.QuestGiver:
                    break;
            }
        }

        public bool NextElement()
        {
            TownNode castCurrentNode = (TownNode)Game.Instance.Maps[Game.Instance.ActiveMap].Map[Game.Instance.Maps[Game.Instance.ActiveMap].PlayerX][Game.Instance.Maps[Game.Instance.ActiveMap].PlayerY];
            Merchant townMerchant = null;
            QuestGiver townQuestGiver = null;

            foreach (Ally NPC in castCurrentNode.TownPeople)
            {
                if (NPC is Merchant)
                    townMerchant = (Merchant)NPC;
                else if (NPC is QuestGiver)
                    townQuestGiver = (QuestGiver)NPC;
            }

            if (currentState == TownNodeState.MerchantSell && selectedOption < Game.Instance.Player.Inventory.Count() - 1)
                selectedOption++;
            else if (currentState == TownNodeState.MerchantBuy && selectedOption < townMerchant.Wares.Count() - 1)
                selectedOption++;
            else if (currentState == TownNodeState.QuestGiver && selectedOption < townQuestGiver.Quests.Count() - 1)
                selectedOption++;
            else
                return false;

            return true;
        }

        public bool PreviousElement()
        {
            if (selectedOption > 0)
                selectedOption--;
            else
                return false;

            return true;
        }

        public int SelectedOption { get => selectedOption; set => selectedOption = value; }
        internal TownNodeState CurrentState { get => currentState; set => currentState = value; }
    }

    class TradingState : GameState
    {
        public TradingState()
        {
            InputHandler = new TradingHandler();
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
            string[] keybinds = ["[ESC] - Resume", "[Spacebar/Enter] - Confirm"];
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

            throw new NotImplementedException();
        }

        public override void Update()
        {
            //move cursor back to end for better experience
            Console.SetCursorPosition(GlobalConstants.consoleSizeWidth - 1, GlobalConstants.consoleSizeHeight - 1);

            throw new NotImplementedException();
        }
    }
}

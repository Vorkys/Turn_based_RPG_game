using System;
using System.Collections.Generic;
using tahova_RPG_hra.Source.Core.InputHandlers;
using tahova_RPG_hra.Source.Entities;
using tahova_RPG_hra.Source.GameObjects.Items;
using tahova_RPG_hra.Source.GameObjects.Items.ItemTypes;
using tahova_RPG_hra.Source.Locations.Nodes;
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
                    else if ((x - 1) == consoleRenderBoxHeight / 2)
                    {
                        string text = "[Paused]";
                        string line = $"{new string(' ', (consoleRenderBoxWidth / 2) - (text.Length / 2))}{text}{new string(' ', (consoleRenderBoxWidth / 2) - (text.Length / 2))}";
                        Console.Write(line);
                        y += line.Length - 1;
                    }
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

    class ExplorationState : GameState
    {
        public ExplorationState()
        {
            InputHandler = new ExplorationHandler();
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

                int renderingHeight = playerPosX - (consoleRenderBoxHeight / 2) + (x - 1);

                for (int y = 0; y < GlobalConstants.consoleSizeWidth; y++)
                {
                    int renderingWidth = playerPosY - (consoleRenderBoxWidth / 2) + (y - 1);
                    //border 'H'
                    if (y == 0 || y + 1 == GlobalConstants.consoleSizeWidth)
                        Console.Write('H');
                    //game map where player is in middle
                    //out of bound Height so fill with ' ' and skip to next line
                    else if (renderingHeight < 0 || renderingHeight >= Game.Instance.Maps[Game.Instance.ActiveMap].Map.Count)
                    {
                        int blankAmount = GlobalConstants.consoleSizeWidth - 2;
                        Console.Write(new string(' ', blankAmount));
                        y += blankAmount - 1;
                    }
                    //out of bound Left Width so write limited amount of ' '
                    else if (renderingWidth < 0)
                    {
                        int blankAmount = -renderingWidth;
                        Console.Write(new string(' ', blankAmount));
                        y += blankAmount - 1;
                    }
                    //out of bound Right Width so write limited amount of ' '
                    else if (renderingWidth >= Game.Instance.Maps[Game.Instance.ActiveMap].Map[0].Count)
                    {
                        int blankAmount = GlobalConstants.consoleSizeWidth - y - 1;
                        Console.Write(new string(' ', blankAmount));
                        y += blankAmount - 1;
                    }
                    //player node
                    else if (renderingHeight == playerPosX && renderingWidth == playerPosY)
                        Game.Instance.Maps[Game.Instance.ActiveMap].Map[renderingHeight][renderingWidth].Write(true);
                    //normal node
                    else
                        Game.Instance.Maps[Game.Instance.ActiveMap].Map[renderingHeight][renderingWidth].Write();
                }

                Console.WriteLine();
            }

            string[] keybinds = ["[ESC] - Pause", "[W/S/A/D or arrows] - Move"];
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

    class CombatState : GameState
    {
        private string combatDialog;
        private bool toConfirmAction;
        private bool showSpells;
        private bool showItems;
        private int listElementId;

        public CombatState()
        {
            InputHandler = new CombatHandler();
            CombatDialog = null;
            ToConfirmDialog = false;
            ShowSpells = false;
            ShowItems = false;
            ListElementId = 0;
        }

        public string CombatDialog { get => combatDialog; set => combatDialog = value; }
        public bool ToConfirmDialog { get => toConfirmAction; set => toConfirmAction = value; }
        public bool ShowSpells { get => showSpells; set => showSpells = value; }
        public bool ShowItems { get => showItems; set => showItems = value; }
        public int ListElementId { get => listElementId; set => listElementId = value; }

        public override void Render()
        {
            int playerPosX = Game.Instance.Maps[Game.Instance.ActiveMap].PlayerX;
            int playerPosY = Game.Instance.Maps[Game.Instance.ActiveMap].PlayerY;
            int consoleRenderBoxHeight = GlobalConstants.consoleSizeHeight - 4;
            int consoleRenderBoxWidth = GlobalConstants.consoleSizeWidth - 2;

            Game.Instance.Player.LoadSprite();
            Game.Instance.Player.Target.LoadSprite();

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

                    //if line contains only enemy render (line is above player render box and line is inside enemy render box)
                    else if ((consoleRenderBoxHeight - Game.Instance.Player.Sprite.Length) > (x - 1) && (x - 1) < Game.Instance.Player.Target.Sprite.Length)
                    {
                        //line is penultimate of enemy render box => line has name, lvl and part of sprite
                        if ((x - 1) == (Game.Instance.Player.Target.Sprite.Length - 2))
                        {
                            string line = new string(' ', consoleRenderBoxWidth - 32 - Game.Instance.Player.Target.Sprite[0].Length);
                            //if name is too long substring until Name len is 21(32 - 7 - 1) and add "..."
                            line += Game.Instance.Player.Target.Name.Length > 24 ? $"{Game.Instance.Player.Target.Name.Substring(0, 21)}..." : $"{Game.Instance.Player.Target.Name}{new string(' ', 25 - Game.Instance.Player.Target.Name.Length)}";
                            //add lvl "Lvl:XX "
                            line += Game.Instance.Player.Target.Level < 10 ? $"Lvl: {Game.Instance.Player.Target.Level} " : $"Lvl:{Game.Instance.Player.Target.Level} ";
                            //add sprite line
                            line += Game.Instance.Player.Target.Sprite[x - 1];

                            Console.Write(line);
                            y += line.Length - 1;
                        }
                        //line is last of enemy render box => line has hp(%) and part of sprite
                        else if ((x - 1) == (Game.Instance.Player.Target.Sprite.Length - 1))
                        {
                            string line = new string(' ', consoleRenderBoxWidth - 32 - Game.Instance.Player.Target.Sprite[0].Length);
                            //add life in percentage
                            int healthPercent = (Game.Instance.Player.Target.Health * 30) / Game.Instance.Player.Target.MaxHealth;
                            if (healthPercent < 0)
                                line += $"<{new string('-', 30)}>";
                            else
                                line += $"<{new string('=', healthPercent)}{new string('-', 30 - healthPercent)}>";

                            line += Game.Instance.Player.Target.Sprite[x - 1];

                            Console.Write(line);
                            y += line.Length - 1;
                        }
                        //line only has enemy sprite
                        else
                        {
                            string line = new string(' ', consoleRenderBoxWidth - Game.Instance.Player.Target.Sprite[x - 1].Length);
                            line += Game.Instance.Player.Target.Sprite[x - 1];

                            Console.Write(line);
                            y += line.Length - 1;
                        }
                    }
                    //TODO
                    //if line doesnt contains player or enemy render (line >= sprite len && line)
                    //else if ((x - 1) >= Game.Instance.Player.Target.Sprite.Length && (x - 1) <= (consoleRenderBoxHeight - Game.Instance.Player.Sprite.Length))
                    //{
                    //    string line = new string(' ', consoleRenderBoxWidth);
                    //    Console.Write(line);
                    //    y += line.Length - 1;
                    //}
                    //if line contains enemy AND players
                    //else if ((x - 1) < Game.Instance.Player.Target.Sprite.Length && (x - 1) >= (consoleRenderBoxHeight - Game.Instance.Player.Sprite.Length))
                    //{
                    //    //
                    //    if ()
                    //}
                    //if line contains only player
                    else if (x >= (consoleRenderBoxHeight - Game.Instance.Player.Sprite.Length - 1))
                    {
                        //line is pre penultimate of player render box => line has name, lvl and part of sprite
                        if (x == (consoleRenderBoxHeight - 5))
                        {
                            //add sprite line
                            string line = Game.Instance.Player.Sprite[x + 1 - (consoleRenderBoxHeight - Game.Instance.Player.Sprite.Length)];
                            //if name is too long substring until Name len is 21(32 - 7 - 3 - 1) and add "..."
                            line += Game.Instance.Player.Name.Length > 24 ? $"{Game.Instance.Player.Name.Substring(0, 21)}..." : $"{Game.Instance.Player.Name}{new string(' ', 26 - Game.Instance.Player.Name.Length)}";
                            //add lvl "Lvl:XX"
                            line += Game.Instance.Player.Level < 10 ? $"Lvl: {Game.Instance.Player.Level}" : $"Lvl:{Game.Instance.Player.Level}";
                            //add white space
                            line += new string(' ', consoleRenderBoxWidth - line.Length);

                            Console.Write(line);
                            y += line.Length - 1;
                        }
                        //line is pre pre penultimate of player render box => line has part of sprite, hp(%) and amount of hp
                        else if (x == (consoleRenderBoxHeight - 4))
                        {
                            //add sprite part
                            string line = Game.Instance.Player.Sprite[x + 1 - (consoleRenderBoxHeight - Game.Instance.Player.Sprite.Length)];
                            //add life in percentage
                            int healthPercent = (Game.Instance.Player.Health * 30) / Game.Instance.Player.MaxHealth;
                            if (healthPercent < 0)
                                line += $"<{new string('-', 30)}>";
                            else
                                line += $"<{new string('=', healthPercent)}{new string('-', 30 - healthPercent)}>";
                            //add health counter
                            line += $" HP: {Game.Instance.Player.Health}/{Game.Instance.Player.MaxHealth}";
                            //add white spaces
                            line += new string(' ', consoleRenderBoxWidth - line.Length);

                            Console.Write(line);
                            y += line.Length - 1;
                        }
                        //line is pre penultimate of player render box => line has part of sprite, mana(%) and amount of mana
                        else if (x == (consoleRenderBoxHeight - 3))
                        {
                            //add sprite part
                            string line = Game.Instance.Player.Sprite[x + 1 - (consoleRenderBoxHeight - Game.Instance.Player.Sprite.Length)];
                            //add life in percentage
                            int healthPercent = (Game.Instance.Player.Mana * 30) / Game.Instance.Player.MaxMana;
                            if (healthPercent < 0)
                                line += $"<{new string('-', 30)}>";
                            else
                                line += $"<{new string('~', healthPercent)}{new string('-', 30 - healthPercent)}>";
                            //add health counter
                            line += $" MP: {Game.Instance.Player.Mana}/{Game.Instance.Player.MaxMana}";
                            //add white spaces
                            line += new string(' ', consoleRenderBoxWidth - line.Length);

                            Console.Write(line);
                            y += line.Length - 1;
                        }
                        //line is penultimate of player render box => line has part of sprite, xp(%) and amount of xp
                        else if (x == (consoleRenderBoxHeight - 2))
                        {
                            //add sprite part
                            string line = Game.Instance.Player.Sprite[x + 1 - (consoleRenderBoxHeight - Game.Instance.Player.Sprite.Length)];
                            //add life in percentage
                            int healthPercent = (Game.Instance.Player.EntityXP * 30) / Game.Instance.Player.XPtoLevelUp;
                            line += $"|{new string('=', healthPercent)}{new string('-', 30 - healthPercent)}|";
                            //add health counter
                            line += $" XP: {Game.Instance.Player.EntityXP}/{Game.Instance.Player.XPtoLevelUp}";
                            //add white spaces
                            line += new string(' ', consoleRenderBoxWidth - line.Length);

                            Console.Write(line);
                            y += line.Length - 1;
                        }
                        //line only has player sprite
                        else
                        {
                            string line = Game.Instance.Player.Sprite[x + 1 - (consoleRenderBoxHeight - Game.Instance.Player.Sprite.Length)];
                            line += new string(' ', consoleRenderBoxWidth - Game.Instance.Player.Sprite[x + 1 - (consoleRenderBoxHeight - Game.Instance.Player.Sprite.Length)].Length);

                            Console.Write(line);
                            y += line.Length - 1;
                        }

                    }
                    //line doesnt contains player render or enemy render
                    else
                    {
                        string line = new string(' ', consoleRenderBoxWidth);
                        Console.Write(line);
                        y += line.Length - 1;
                    }
                }

                Console.WriteLine();
            }

            string[] keybinds;

            //if (CombatDialog != null)
            //    ToConfirmDialog = true;
            //else
            //    ToConfirmDialog = false;

            Player tmp = Game.Instance.Player;

            ToConfirmDialog = false;

            if (ToConfirmDialog)
                keybinds = ["[ESC/SpaceBar/Enter] - Confirm"];
            else if (ShowSpells)
            {
                keybinds = ["[A/<] - Previous spell", "[D/>] - Next spell", "[SpaceBar/Enter] - Cast", "[ESC] - back"];
                if (Game.Instance.Player.Spells.Count > 0)
                    CombatDialog = $"{ListElementId + 1}/{Game.Instance.Player.Spells.Count} {Game.Instance.Player.Spells[ListElementId].Name} ({Game.Instance.Player.Spells[ListElementId].Cost}): {Game.Instance.Player.Spells[ListElementId].Description} (P: {Game.Instance.Player.Spells[ListElementId].Power})";
                else
                    CombatDialog = "You have no spells.";
            }
            else if (ShowItems)
            {
                if (Game.Instance.Player.Inventory[ListElementId] is Consumable)
                {
                    keybinds = ["[A/<] - Previous item", "[D/>] - Next item", "[SpaceBar/Enter] - Use", "[ESC] - back"];
                    Consumable castItem = (Consumable)Game.Instance.Player.Inventory[ListElementId];
                    CombatDialog = $"{ListElementId + 1}/{6} {Game.Instance.Player.Inventory[ListElementId].Name}({Game.Instance.Player.Inventory[ListElementId].Quantity}): {Game.Instance.Player.Inventory[ListElementId].Description} (P: {castItem.Power})";
                }
                else if (Game.Instance.Player.Inventory[ListElementId] is Item)
                {
                    keybinds = ["[A/<] - Previous item", "[D/>] - Next item", "[ESC] - back"];
                    CombatDialog = $"{ListElementId + 1}/{6} {Game.Instance.Player.Inventory[ListElementId].Name}({Game.Instance.Player.Inventory[ListElementId].Quantity}): {Game.Instance.Player.Inventory[ListElementId].Description}";
                }
                else
                {
                    keybinds = ["[A/<] - Previous item", "[D/>] - Next item", "[ESC] - back"];
                    CombatDialog = $"{ListElementId + 1}/{6} Null item.";
                }
            }
            else
                keybinds = ["[Q] - Attack enemy", $"[W] - Show spells ({Game.Instance.Player.Spells.Count})", "[E] - Show items", "[ESC] - Pause", "[Spacebar/Enter] - Confirm"];

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
                    //print combat dialog
                    else if (CombatDialog != null)
                    {
                        if (CombatDialog.Length < (GlobalConstants.consoleSizeWidth - y))
                        {
                            Console.Write($" {CombatDialog} ");
                            y += CombatDialog.Length + 1;
                            CombatDialog = null;
                        }
                    }
                    //print keybinds
                    else if (tmpId < keybinds.Length)
                    {
                        if (keybinds[tmpId].Length < (GlobalConstants.consoleSizeWidth - y))
                        {
                            Console.Write($" {keybinds[tmpId]} ");
                            y += keybinds[tmpId].Length + 1;
                            tmpId++;
                        }
                        //keybind is too long
                        else
                            Console.Write(' ');
                    }
                    //empty
                    else
                        Console.Write(' ');
                }

                Console.WriteLine();
            }
        }

        public void NextElement()
        {
            if (ShowSpells && ListElementId < Game.Instance.Player.Spells.Count - 1)
            {
                ListElementId++;
            }
            else if (ShowItems && ListElementId < Game.Instance.Player.Inventory.Length - 1)
            {
                ListElementId++;
            }
        }

        public void PreviousElement()
        {
            if (ShowSpells && ListElementId > 0)
            {
                ListElementId--;
            }
            else if (ShowItems && ListElementId > 0)
            {
                ListElementId--;
            }
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
                        string line = $"{new string(' ', (consoleRenderBoxWidth / 2) - (text.Length / 2))}{text}{new string(' ', (consoleRenderBoxWidth / 2) - (text.Length / 2))}";
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

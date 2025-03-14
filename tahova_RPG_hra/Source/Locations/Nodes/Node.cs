using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Core;

namespace tahova_RPG_hra.Source.Locations.Nodes
{
    internal class Node
    {
        private char nodeChar;
        private string foregroundColor;
        private string backgroundColor;
        private string mapColor;
        private bool isMovable;

        public Node(char nodeChar, string foregroundColor, string backgroundColor, string mapColor, bool isMovable)
        {
            NodeChar = nodeChar;
            ForegroundColor = foregroundColor;
            BackgroundColor = backgroundColor;
            MapColor = mapColor;
            IsMovable = isMovable;
        }

        public char NodeChar { get => nodeChar; set => nodeChar = value; }
        public string ForegroundColor { get => foregroundColor; set => foregroundColor = value; }
        public string BackgroundColor { get => backgroundColor; set => backgroundColor = value; }
        public string MapColor { get => mapColor; set => mapColor = value; }
        public bool IsMovable { get => isMovable; set => isMovable = value; }


        //TODO possible performance upgrade (dont always store default console colors)
        /// <summary>
        /// Print node when player is exploring.
        /// </summary>
        public void Write()
        {
            //save default console colors
            ConsoleColor originalForegroundColor = Console.ForegroundColor;
            ConsoleColor originalBackgroundColor = Console.BackgroundColor;

            //validate colors
            bool validForegroundColor = Enum.TryParse(ForegroundColor, true, out ConsoleColor consoleForegroundColor);
            bool validBackgroundColor = Enum.TryParse(BackgroundColor, true, out ConsoleColor consoleBackgroundColor);

            if (validForegroundColor && validBackgroundColor)
            {
                Console.ForegroundColor = consoleForegroundColor;
                Console.BackgroundColor = consoleBackgroundColor;

                Console.Write(NodeChar);
            }
            else
                Console.WriteLine("Invalid color");

            //return original colors
            Console.ForegroundColor = originalForegroundColor;
            Console.BackgroundColor = originalBackgroundColor;
        }

        /// <summary>
        /// Print node background color. Used when showing big map in 1:4.
        /// </summary>
        public void MapWrite()
        {
            //save default console color
            ConsoleColor originalBackgroundColor = Console.BackgroundColor;

            //validate colors
            bool validBackgroundColor = Enum.TryParse(BackgroundColor, true, out ConsoleColor consoleBackgroundColor);

            if (validBackgroundColor)
            {
                Console.BackgroundColor = consoleBackgroundColor;

                Console.Write(" ");
            }
            else
                Console.WriteLine("Invalid color");

            //return original color
            Console.BackgroundColor = originalBackgroundColor;
        }

        //TODO - used for overriding only??
        public virtual void Traverse() { }
    }
}

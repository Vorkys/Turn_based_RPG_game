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
        private string backgroundColor;
        private string foregroundColor;
        private string mapColor;
        private bool isMovable;

        public Node(char nodeChar, string backgroundColor, string foregroundColor, string mapColor, bool isMovable)
        {
            this.nodeChar = nodeChar;
            this.backgroundColor = backgroundColor;
            this.foregroundColor = foregroundColor;
            this.mapColor = mapColor;
            this.isMovable = isMovable;
        }

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
            bool validForegroundColor = Enum.TryParse(foregroundColor, true, out ConsoleColor consoleForegroundColor);
            bool validBackgroundColor = Enum.TryParse(backgroundColor, true, out ConsoleColor consoleBackgroundColor);

            if (validForegroundColor && validBackgroundColor)
            {
                Console.ForegroundColor = consoleForegroundColor;
                Console.BackgroundColor = consoleBackgroundColor;

                Console.Write(nodeChar);
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
            bool validBackgroundColor = Enum.TryParse(backgroundColor, true, out ConsoleColor consoleBackgroundColor);

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

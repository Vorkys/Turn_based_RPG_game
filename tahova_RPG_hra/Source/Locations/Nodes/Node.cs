using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tahova_RPG_hra.Source.Locations.Nodes
{
    internal class Node
    {
        //private GameState type;
        private char nodeChar;
        private string foregroundColor;
        private string backgroundColor;
        private string mapColor;
        private bool isMovable;

        public Node(char nodeChar, string foregroundColor, string backgroundColor, string mapColor, bool isMovable)
        {
            this.nodeChar = nodeChar;
            this.foregroundColor = foregroundColor;
            this.backgroundColor = backgroundColor;
            this.mapColor = mapColor;
            this.isMovable = isMovable;
        }

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

        //TODO
        public virtual void MapWrite()
        {

        }

        //TODO
        public virtual void Traverse()
        { }
    }
}

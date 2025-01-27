using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tahova_RPG_hra.Locations.Nodes
{
    internal class LocationNode
    {
        //private GameState type;
        private char nodeChar;
        private string foregroundColor;
        private string backgroundColor;
        private string mapColor;
        private bool isMovable;

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
    }
}

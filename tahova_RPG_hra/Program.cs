using System;
using tahova_RPG_hra.Source.Core;
using tahova_RPG_hra.Source.Utils;

namespace tahova_RPG_hra
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(GlobalConstants.consoleSizeX, GlobalConstants.consoleSizeY);
            Console.Clear();

            Console.WriteLine($"Before continuing please make sure the console window size is: {consoleSizeX}, {GlobalConstants.consoleSizeY}.");

            for (int i = 0; i < GlobalConstants.consoleSizeX; i++)
                Console.Write("=");

            Console.WriteLine("\nIf the line above doesnt take exactly 1 line please adapt the size.\n\nWhen done press Enter...");
            Console.ReadLine();
            Console.Clear();

            //Render
            for (int x = 0; x < GlobalConstants.consoleSizeY; x++)
            {
                if (x == 0 || x + 1 == 35 || x + 1 == GlobalConstants.consoleSizeY)
                {
                    Console.Write(new string('=', GlobalConstants.consoleSizeX));
                    continue;
                }

                for (int y = 0; y < GlobalConstants.consoleSizeX; y++)
                {
                    //border
                    if (y == 0 || y + 1 == GlobalConstants.consoleSizeX)
                        Console.Write("H");
                    //player pos
                    else if (x == Game.Instance.Maps[Game.Instance.ActiveMap].PlayerX && y == Game.Instance.Maps[Game.Instance.ActiveMap].PlayerY)
                    {
                        Console.Write("P");
                    }
                    //print map node
                    else if ((Game.Instance.Maps[Game.Instance.ActiveMap].PlayerY - y) >= 0 || (Game.Instance.Maps[Game.Instance.ActiveMap].PlayerY + y) < Game.Instance.Maps[Game.Instance.ActiveMap].Map.GetLength(1))
                    {
                        Game.Instance.Maps[Game.Instance.ActiveMap].Map[x, y].Write();
                    }
                    else
                        Console.Write(" ");
                }
            }

            Console.ReadLine();

            //for (int i = 0; i < 160; i++)
            //    Console.Write(((i + 1) % 10) == 0 ? "M" : "I");
        }
    }
}

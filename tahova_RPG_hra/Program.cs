using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using tahova_RPG_hra.Source.Core;
using tahova_RPG_hra.Source.Locations.Nodes;
using tahova_RPG_hra.Source.Utils;

namespace tahova_RPG_hra
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.SetWindowSize(GlobalConstants.consoleSizeWidth + 1, GlobalConstants.consoleSizeHeight);
            Console.Clear();

            Console.WriteLine($"Before continuing please make sure the console window size is: {GlobalConstants.consoleSizeWidth}, {GlobalConstants.consoleSizeHeight}.");

            for (int i = 0; i < GlobalConstants.consoleSizeWidth; i++)
                Console.Write("=");
            //TODO - add vertical line

            Console.WriteLine("\nIf the line above doesnt take exactly 1 line please adapt the size.\n\nWhen done press Enter...");
            Console.ReadLine();
            Console.Clear();

            string _fileName = "SERIALIZED_mainMap.json";

            Game.Instance.Load(_fileName);

            while (true)
            {
                //while rendering input cant be taken. Rendering will be async
                Game.Instance.GameState.Render();

                bool validInput = false;

                do
                {
                    //TODO - make user not write into consoleD
                    validInput = Game.Instance.GameState.InputHandler.handle(Console.ReadKey(intercept: true).Key);
                } while (!validInput);
            }
        }
    }
}

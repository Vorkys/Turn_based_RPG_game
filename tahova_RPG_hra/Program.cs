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
            Console.SetWindowSize(GlobalConstants.consoleSizeWidth, GlobalConstants.consoleSizeHeight);
            Console.Clear();

            for (int i = 0; i < GlobalConstants.consoleSizeHeight; i++)
            {
                if (i == 0)
                {
                    Console.Write(new string('=', GlobalConstants.consoleSizeWidth));
                    continue;
                }
                else if (i == GlobalConstants.consoleSizeHeight - 2)
                {
                    Console.Write("H");
                    break;
                }

                for (int k = 0; k < GlobalConstants.consoleSizeWidth; k++)
                {
                    if (k == 0)
                        Console.Write('H');

                    string text;

                    switch (i)
                    {
                        case 1:
                            text = $" Before continuin please make sure the console window size has width: {GlobalConstants.consoleSizeWidth}, height: {GlobalConstants.consoleSizeHeight}";
                            Console.Write(text);
                            k += text.Length - 1;
                            break;
                        case 2:
                            text = " Use the line on top and line on left as markers.";
                            Console.Write(text);
                            k += text.Length - 1;
                            break;
                        case 4:
                            text = " When done press Enter...";
                            Console.Write(text);
                            k += text.Length - 1;
                            break;
                    }

                    break;
                }

                Console.WriteLine();
            }
            
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

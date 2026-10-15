using System;
using System.IO;
using TurnBasedRPG.Source.Core;
using TurnBasedRPG.Source.Utils;

namespace TurnBasedRPG
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.SetWindowSize(GlobalConstants.consoleSizeWidth + 1, GlobalConstants.consoleSizeHeight);
            Console.SetBufferSize(GlobalConstants.consoleSizeWidth + 1, GlobalConstants.consoleSizeHeight);
            Console.Clear();

            for (int i = 0; i < GlobalConstants.consoleSizeHeight; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine(new string('=', GlobalConstants.consoleSizeWidth));
                    continue;
                }
                else if (i == GlobalConstants.consoleSizeHeight - 1)
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
                            text = $" Before continuing make sure the console window size has width: {GlobalConstants.consoleSizeWidth + 1}, height: {GlobalConstants.consoleSizeHeight}";
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

            //TODO - remove after testing
            //Game.Instance.Player.IncreaseLvl(40);

            Game.Instance.GameState.Render();
            while (true)
            {
                //while rendering input cant be taken. Rendering will be async
                Game.Instance.GameState.Update();

                bool validInput = false;

                do
                {
                    validInput = Game.Instance.GameState.InputHandler.handle(Console.ReadKey(intercept: true).Key);
                } while (!validInput);
            }
        }
    }
}

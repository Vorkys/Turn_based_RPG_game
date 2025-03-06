using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tahova_RPG_hra.Source.Utils
{
    public static class Roll
    {
        private static Random _random = new Random();

        public static bool RollDice(int percent)
        {
            int roll = _random.Next(0, 101);

            if (roll < percent)
                return true;
            else
                return false;
        }

        public static bool RollDice(int percent, int maxRoll)
        {
            int roll = _random.Next(0, maxRoll + 1);

            if (roll < percent)
                return true;
            else
                return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Entities;

namespace tahova_RPG_hra.Source.Core
{
    internal class Game
    {
        private int activeLocation;
        private Player player;

        public Player Player
        {
            get { return Player; }
            set { Player = value; }
        }


        public void openDialog(string[] dialog)
        {
            //TODO
        }

        public void startCombat(Enemy enemy)
        {
            //TODO
        }

        public void changeLocation(int locationId)
        {
            //TODO
        }

        public void openTown(string name, string description, string[] townSprite, Ally[] townPeople)
        {
            //TODO
        }
    }
}

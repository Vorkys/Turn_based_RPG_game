using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Entities;
using tahova_RPG_hra.Source.GameObjects.Items;
using tahova_RPG_hra.Source.Locations;
using tahova_RPG_hra.Source.Locations.Nodes;
using tahova_RPG_hra.Source.Quests;

namespace tahova_RPG_hra.Source.Core
{
    internal class Game
    {
        private Location[,] Maps;
        private int activeLocation;
        private int gameState;
        private Player player;
        private Quest[] activeQuests;

        public Player Player
        {
            get { return Player; }
            set { Player = value; }
        }

        public Player Enemy
        {
            get { return Enemy; }
            set { Enemy = value; }
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

        public void openTown(TownNode town)
        {
            //TODO
        }

        public void openExploration()
        {
            //TODO
        }

        public void EndTurn()
        {
            //TODO
        }

        public void AddQuest(Quest quest)
        {
            //TODO
        }

        public void openShop(Item[] wares)
        {
            //TODO
        }
    }
}

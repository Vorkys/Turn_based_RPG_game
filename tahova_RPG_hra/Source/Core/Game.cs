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
        private List<Quest> activeQuests;

        internal Location[,] Maps1 { get => Maps; set => Maps = value; }
        public int ActiveLocation { get => activeLocation; set => activeLocation = value; }
        public int GameState { get => gameState; set => gameState = value; }
        internal Player Player { get => player; set => player = value; }
        public List<Quest> ActiveQuests { get => activeQuests; set => activeQuests = value; }

        public void openDialog(List<string> dialog)
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

        public void openShop(List<Item> wares)
        {
            //TODO
        }
    }
}

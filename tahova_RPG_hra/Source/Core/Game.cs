using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Core.GameStates;
using tahova_RPG_hra.Source.Entities;
using tahova_RPG_hra.Source.GameObjects.Items;
using tahova_RPG_hra.Source.Locations;
using tahova_RPG_hra.Source.Locations.Nodes;
using tahova_RPG_hra.Source.Quests;

namespace tahova_RPG_hra.Source.Core
{
    internal class Game
    {
        private static readonly Game _instance = new Game();
        private GameState gameState;
        private Location[,] maps;
        private int activeMap;
        private Player player;
        private List<Quest> activeQuests;

        private Game() { }

        public GameState GameState { get => gameState; set => gameState = value; }
        internal Location[,] Maps { get => maps; set => maps = value; }
        public int ActiveMap { get => activeMap; set => activeMap = value; }
        internal Player Player { get => player; set => player = value; }
        public List<Quest> ActiveQuests { get => activeQuests; set => activeQuests = value; }

        //singleton pattern to have one instance of game accessible from everywhere
        public static Game Instance
        {
            get
            {
                return _instance;
            }
        }

        public void Save()
        {
            //serialize
        }

        public void Load()
        {
            //deserialize
        }

        public bool Init()
        {
            //init all managers and return true if successful, false if fail somewhere
            return true;
        }

        public void ChangeState()
        {
            //TODO
        }

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

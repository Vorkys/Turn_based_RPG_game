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
    public enum GameStateType
    {
        Menu,
        Pause,
        Exploration,
        Combat,
        Dialog,
        Inventory
    }

    internal class Game
    {
        private static readonly Game _instance = new Game();
        private Dictionary<GameStateType, GameState> gameStateMap;
        private GameState gameState;
        private Location[] maps;
        private int activeMap;
        private Player player;
        private List<Quest> activeQuests;

        private Game()
        {
            GameStateMap = new Dictionary<GameStateType, GameState>
            {
                { GameStateType.Menu, new MenuState() },
                { GameStateType.Pause, new PauseState() },
                { GameStateType.Exploration, new ExplorationState() },
                { GameStateType.Combat, new CombatState() },
                { GameStateType.Dialog, new DialogState() },
                { GameStateType.Inventory, new InventoryState() }
            };

            //Default gameState
            GameState = gameStateMap[GameStateType.Menu];
        }

        internal Dictionary<GameStateType, GameState> GameStateMap { get => gameStateMap; set => gameStateMap = value; }
        internal GameState GameState { get => gameState; set => gameState = value; }
        internal Location[] Maps { get => maps; set => maps = value; }
        internal int ActiveMap { get => activeMap; set => activeMap = value; }
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

        public int ActiveMap1 { get => activeMap; set => activeMap = value; }

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

        public void ChangeState(GameStateType stateType)
        {
            //TODO
            if (GameStateMap.TryGetValue(stateType, out GameState newState))
            {
                GameState = newState;
                Console.WriteLine($"GameState changed to: {GameState.GetType().Name}");
            }
            else
                Console.WriteLine($"Invalid GameState");
        }

        public void Pause()
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

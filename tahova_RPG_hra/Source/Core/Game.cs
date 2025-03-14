using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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
        Inventory,
        Journal,
        Town,
        Trading
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
                { GameStateType.Combat, new CombatState(null) },
                { GameStateType.Dialog, new DialogState(new List<string> {"Default"}) },
                { GameStateType.Inventory, new InventoryState() },
                { GameStateType.Journal, new JournalState() },
                { GameStateType.Town, new TownState() },
                { GameStateType.Trading, new TradingState() }
            };

            //Default gameState
            GameState = gameStateMap[GameStateType.Menu];
        }

        internal Dictionary<GameStateType, GameState> GameStateMap { get => gameStateMap; set => gameStateMap = value; }
        internal GameState GameState { get => gameState; set => gameState = value; }
        internal Location[] Maps { get => maps; set => maps = value; }
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

        public int ActiveMap1 { get => activeMap; set => activeMap = value; }

        public void Save()
        {
            string folderPath = "savefiles";

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".json";
            string filePath = Path.Combine(folderPath, fileName);

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(this, options);
            File.WriteAllText(filePath, jsonString);
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

        public void ChangeState(GameStateType stateType, params object[] parameters)
        {
            //TODO
            GameState newState = stateType switch
            {
                GameStateType.Menu => new MenuState(),
                GameStateType.Pause => new PauseState(),
                GameStateType.Exploration => new ExplorationState(),
                GameStateType.Combat => new CombatState((Enemy)parameters[0]),
                GameStateType.Dialog => new DialogState((List<string>)parameters[0]),
                GameStateType.Inventory => new InventoryState(),
                GameStateType.Journal => new JournalState(),
                GameStateType.Town => new TownState(),
                GameStateType.Trading => new TradingState(),
                _ => null
            };

            if (newState != null)
            {
                GameState = newState;
                Console.WriteLine($"GameState changed to: {GameState.GetType().Name}");
            }
            else
                Console.WriteLine($"Invalid GameState");
        }

        public void Pause()
        {
            Instance.ChangeState(GameStateType.Pause);
        }

        public void Resume()
        {
            if (Instance.Player.Target == null)
                Instance.ChangeState(GameStateType.Combat);
            else
                Instance.ChangeState(GameStateType.Exploration);
        }

        public void MovePlayer(int destinationX, int destinationY)
        {
            if (Instance.Maps[ActiveMap].Map[destinationX, destinationY].IsMovable)
            {
                Instance.Maps[ActiveMap].PlayerX = destinationX;
                Instance.Maps[ActiveMap].PlayerY = destinationY;
                Instance.Maps[ActiveMap].Map[destinationX, destinationY].Traverse();
            }
        }

        public void MovePlayerUp()
        {
            //Handle out of bound
            if ((Instance.Maps[ActiveMap].PlayerY - 1) < 0)
                return;
            MovePlayer(Instance.Maps[ActiveMap].PlayerX, Instance.Maps[ActiveMap].PlayerY - 1);
        }

        public void MovePlayerDown()
        {
            //Handle out of bound
            if ((Instance.Maps[ActiveMap].PlayerY + 1) >= Instance.Maps[ActiveMap].Map.GetLength(0))
                return;

            MovePlayer(Instance.Maps[ActiveMap].PlayerX, Instance.Maps[ActiveMap].PlayerY + 1);
        }

        public void MovePlayerLeft()
        {
            //Handle out of bound
            if ((Instance.Maps[ActiveMap].PlayerX - 1) < 0)
                return;

            MovePlayer(Instance.Maps[ActiveMap].PlayerX - 1, Instance.Maps[ActiveMap].PlayerY);
        }

        public void MovePlayerRight()
        {
            //Handle out of bound
            if ((Instance.Maps[ActiveMap].PlayerX + 1) >= Instance.Maps[ActiveMap].Map.GetLength(1))
                return;

            MovePlayer(Instance.Maps[ActiveMap].PlayerX + 1, Instance.Maps[ActiveMap].PlayerY);
        }

        public void openDialog(List<string> dialog)
        {
            Instance.ChangeState(GameStateType.Dialog, dialog);
        }

        public void startCombat(Enemy enemy)
        {
            Instance.ChangeState(GameStateType.Combat, enemy);
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

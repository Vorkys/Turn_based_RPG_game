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
using tahova_RPG_hra.Source.Managers;
using tahova_RPG_hra.Source.Quests;
using tahova_RPG_hra.Source.Spells;

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

    public class Game
    {
        private static readonly Game _instance = new Game();
        private Dictionary<GameStateType, GameState> gameStateMap;
        private GameState gameState;
        private List<Location> maps;
        private int activeMap;
        private Player player;
        private List<Quest> activeQuests;

        private Game()
        {
            GameStateMap = new Dictionary<GameStateType, GameState>
            {
                //default values
                { GameStateType.Menu, new MenuState() },
                { GameStateType.Pause, new PauseState() },
                { GameStateType.Exploration, new ExplorationState() },
                { GameStateType.Combat, new CombatState() },
                { GameStateType.Dialog, new DialogState(new List<string> {"Default"}) },
                { GameStateType.Inventory, new InventoryState() },
                { GameStateType.Journal, new JournalState() },
                { GameStateType.Town, new TownState() },
                { GameStateType.Trading, new TradingState() }
            };
            //Default gameState
            GameState = gameStateMap[GameStateType.Exploration];

            Maps = new List<Location>();
            ActiveMap = 0;
            Player = EntityManager.Player;
            ActiveQuests = new List<Quest>();
        }

        public Dictionary<GameStateType, GameState> GameStateMap { get => gameStateMap; set => gameStateMap = value; }
        public GameState GameState { get => gameState; set => gameState = value; }
        public List<Location> Maps { get => maps; set => maps = value; }
        public int ActiveMap { get => activeMap; set => activeMap = value; }
        public Player Player { get => player; set => player = value; }
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
            string folderPath = "savefiles";

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + $"_{Player.Name}" + ".json";
            string filePath = Path.Combine(folderPath, fileName);

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(this, options);
            File.WriteAllText(filePath, jsonString);
        }

        public void LoadMap(string _fileName)
        {
            //deserialize map
            try
            {
                string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Maps");
                string fileName = Path.Combine(folderPath, _fileName);

                string json = File.ReadAllText(fileName);

                var options = new JsonSerializerOptions { WriteIndented = true };
                var deserializedList = JsonSerializer.Deserialize<List<List<Node>>>(json, options);
                Location map = new(deserializedList, 23,78, 23, 78);
                Maps.Add(map);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void Load(string _fileName)
        {
            //deserialize game
            try
            {
                string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "savefiles");
                string fileName = Path.Combine(folderPath, _fileName);

                string json = File.ReadAllText(fileName);

                var deserializedList = JsonSerializer.Deserialize<Game>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public bool Init()
        {
            //init all managers and return true if successful, false if fail somewhere
            return true;
        }

        public void ChangeState(GameStateType stateType, params object[] parameters)
        {
            //TODO - dynamic values
            GameState newState = stateType switch
            {
                GameStateType.Menu => new MenuState(),
                GameStateType.Pause => new PauseState(),
                GameStateType.Exploration => new ExplorationState(),
                GameStateType.Combat => new CombatState(),
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
            //TODO - enemy instead of NULL
            if (Instance.Player.Target != null)
                Instance.ChangeState(GameStateType.Combat, Instance.Player.Target);
            else
                Instance.ChangeState(GameStateType.Exploration);
        }

        public void MovePlayer(int destinationX, int destinationY)
        {
            if (Instance.Maps[ActiveMap].Map[destinationX][destinationY].IsMovable)
            {
                Instance.Maps[ActiveMap].PlayerX = destinationX;
                Instance.Maps[ActiveMap].PlayerY = destinationY;
                Instance.Maps[ActiveMap].Map[destinationX][destinationY].Traverse();

                //save new player coords
                Instance.Maps[ActiveMap].PlayerX = destinationX;
                Instance.Maps[ActiveMap].PlayerY = destinationY;
            }
        }

        public void MovePlayerUp()
        {
            //Handle out of bound
            if ((Instance.Maps[ActiveMap].PlayerX - 1) < 0)
                return;
            MovePlayer(Instance.Maps[ActiveMap].PlayerX - 1, Instance.Maps[ActiveMap].PlayerY);
        }

        public void MovePlayerDown()
        {
            //Handle out of bound
            if ((Instance.Maps[ActiveMap].PlayerX + 1) >= Instance.Maps[ActiveMap].Map.Count)
                return;

            MovePlayer(Instance.Maps[ActiveMap].PlayerX + 1, Instance.Maps[ActiveMap].PlayerY);
        }

        public void MovePlayerLeft()
        {
            //Handle out of bound
            if ((Instance.Maps[ActiveMap].PlayerY - 1) < 0)
                return;

            MovePlayer(Instance.Maps[ActiveMap].PlayerX, Instance.Maps[ActiveMap].PlayerY - 1);
        }

        public void MovePlayerRight()
        {
            //Handle out of bound
            if ((Instance.Maps[ActiveMap].PlayerY + 1) >= Instance.Maps[ActiveMap].Map[Instance.Maps[ActiveMap].PlayerX].Count)
                return;

            MovePlayer(Instance.Maps[ActiveMap].PlayerX, Instance.Maps[ActiveMap].PlayerY + 1);
        }

        public void openDialog(List<string> dialog)
        {
            Instance.ChangeState(GameStateType.Dialog, dialog);
        }

        public void startCombat(Enemy enemy)
        {
            //set targets
            Instance.Player.Target = enemy;
            Instance.Player.Target.Target = Instance.Player;

            //set owners and casters
            foreach (Item item in Instance.Player.Inventory)
                if (item != null)
                    item.Owner = Instance.Player;
            foreach (Spell spell in Instance.Player.Spells)
                if (spell != null)
                    spell.Caster = Instance.Player;

            if (enemy.Inventory != null)
                foreach (Item item in enemy.Inventory)
                    if (item != null)
                        item.Owner = enemy;
            if (enemy.Spells != null)
                foreach (Spell spell in enemy.Spells)
                        spell.Caster = enemy;

            Instance.ChangeState(GameStateType.Combat);
        }

        public void GameOver()
        {
            //this.openDialog([$"You were killed by a {Game.Instance.Player.Target.Name}. :("]);
            Console.Clear();
            Console.WriteLine($"You were killed by a {Game.Instance.Player.Target.Name}. :(");
            Console.WriteLine();
            Console.WriteLine($"Your name was {this.Player.Name} and your level was {this.Player.Level}.");
            Console.WriteLine($"Your enemy level was {this.Player.Target.Level} and had {this.Player.Target.Health} HP left.");

            Console.WriteLine();
            Console.WriteLine("Press any key to exit the game...");
            Console.ReadKey();
            Environment.Exit(0);
        }

        public void changeLocation(int locationId)
        {
            //TODO
        }

        public void openTown(TownNode town)
        {
            Instance.ChangeState(GameStateType.Town);
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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using TurnBasedRPG.Source.Core.GameStates;
using TurnBasedRPG.Source.Entities;
using TurnBasedRPG.Source.Entities.AllyRoles;
using TurnBasedRPG.Source.Entities.EnemyTypes;
using TurnBasedRPG.Source.GameObjects;
using TurnBasedRPG.Source.GameObjects.Items;
using TurnBasedRPG.Source.GameObjects.Items.ItemTypes;
using TurnBasedRPG.Source.Locations;
using TurnBasedRPG.Source.Locations.Nodes;
using TurnBasedRPG.Source.Managers;
using TurnBasedRPG.Source.Quests;
using TurnBasedRPG.Source.Spells;

namespace TurnBasedRPG.Source.Core
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
        private static readonly Lazy<Game> _instance = new Lazy<Game>(() => new Game());
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
                { GameStateType.Menu, new MainMenuState() },
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
            GameState = gameStateMap[GameStateType.Menu];

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
                return _instance.Value;
            }
        }

        public void Save()
        {
            string folderPath = "savefiles";

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string fileName = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + $"_{Player.Name}" + ".json";
            string filePath = Path.Combine(folderPath, fileName);
            var derivedTypesMap = new Dictionary<Type, JsonDerivedType[]>
            {
                [typeof(Node)] = [
                    new JsonDerivedType(typeof(Node), nameof(Node)),
                    new JsonDerivedType(typeof(CombatNode), nameof(CombatNode)),
                    new JsonDerivedType(typeof(BossNode), nameof(BossNode)),
                    new JsonDerivedType(typeof(DialogNode), nameof(DialogNode)),
                    new JsonDerivedType(typeof(DungeonNode), nameof(DungeonNode)),
                    new JsonDerivedType(typeof(RewardNode), nameof(RewardNode)),
                    new JsonDerivedType(typeof(TownNode), nameof(TownNode))
                ],
                [typeof(Entity)] = [
                    new JsonDerivedType(typeof(Player), nameof(Player)),
                    new JsonDerivedType(typeof(Ally), nameof(Ally)),
                    new JsonDerivedType(typeof(ArenaOrganisator), nameof(ArenaOrganisator)),
                    new JsonDerivedType(typeof(Merchant), "Merchant"),
                    new JsonDerivedType(typeof(QuestGiver), nameof(QuestGiver)),
                    new JsonDerivedType(typeof(Enemy), nameof(Enemy)),
                    new JsonDerivedType(typeof(Slime), nameof(Slime)),
                    new JsonDerivedType(typeof(Goblin), nameof(Goblin)),
                    new JsonDerivedType(typeof(Animal), nameof(Animal)),
                    new JsonDerivedType(typeof(Human), nameof(Human)),
                    new JsonDerivedType(typeof(Magical), nameof(Magical)),
                    new JsonDerivedType(typeof(Demonic), nameof(Demonic)),
                    new JsonDerivedType(typeof(Godly), nameof(Godly))
                ],
                [typeof(GameObject)] = [
                    new JsonDerivedType(typeof(Item), nameof(Item)),
                    new JsonDerivedType(typeof(Consumable), nameof(Consumable)),
                    new JsonDerivedType(typeof(Equippable), nameof(Equippable)),
                    new JsonDerivedType(typeof(HealingItem), nameof(HealingItem)),
                    new JsonDerivedType(typeof(ManaIncreaseItem), nameof(ManaIncreaseItem)),
                    new JsonDerivedType(typeof(HybridHealingItem), nameof(HybridHealingItem)),
                    new JsonDerivedType(typeof(DamageItem), nameof(DamageItem)),
                    new JsonDerivedType(typeof(ReduceMana), nameof(ReduceMana))
                ],
            };

            var options = new JsonSerializerOptions
            {
                TypeInfoResolver = new DefaultJsonTypeInfoResolver
                {
                    Modifiers =
                    {
                        typeInfo =>
                        {
                            if (derivedTypesMap.TryGetValue(
                                typeInfo.Type,
                                out var derivedTypes))
                            {
                                var polymorphismOptions = new JsonPolymorphismOptions
                                {
                                    TypeDiscriminatorPropertyName = "$type",
                                    IgnoreUnrecognizedTypeDiscriminators = true,
                                    UnknownDerivedTypeHandling =
                                        JsonUnknownDerivedTypeHandling.FailSerialization
                                };

                                foreach (var derivedType in derivedTypes)
                                {
                                    polymorphismOptions.DerivedTypes.Add(derivedType);
                                }

                                typeInfo.PolymorphismOptions = polymorphismOptions;
                            }
                        }
                    }
                },
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize<object>(this, options);
            File.WriteAllText(filePath, json);
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
                var deserializedMap = JsonSerializer.Deserialize<Location>(json, options);
                //TODO - remove comment; old map = 23, 78, 23, 78 ; new map = 4, 7, 4, 7
                //Location map = new(deserializedList, 2, 2);
                Maps.Add(deserializedMap);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void LoadMaps()
        {
            //deserialize maps
            try
            {
                string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Maps", "MainStory");

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                DirectoryInfo place = new DirectoryInfo(folderPath);
                FileInfo[] files = place.GetFiles();

                if (files.Length != 0)
                    foreach (FileInfo file in files)
                    {
                        string test = Path.GetFullPath(file.FullName);
                        string json = File.ReadAllText(test);

                        var options = new JsonSerializerOptions { WriteIndented = true };
                        var deserializedMap = JsonSerializer.Deserialize<Location>(json, options);
                        //TODO - remove comment; old map = 23, 78, 23, 78 ; new map = 4, 7, 4, 7
                        //Location map = new(deserializedList, 2, 2);
                        Maps.Add(deserializedMap);
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Environment.Exit(1);
            }
        }

        public void Load(string _mapFileName)
        {
            //deserialize game
            try
            {
                string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "savefiles");
                string fileName = Path.Combine(folderPath, _mapFileName);

                //var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                //string json = File.ReadAllText(fileName);

                //Game? deserializedGame = JsonSerializer.Deserialize<Game>(json, options);

                ////Update instance
                //if (deserializedGame != null)
                //{
                //    Instance.gameStateMap = deserializedGame.gameStateMap;
                //    Instance.gameState = deserializedGame.gameState;
                //    Instance.maps = deserializedGame.maps;
                //    Instance.activeMap = deserializedGame.activeMap;
                //    Instance.player = deserializedGame.player;
                //    Instance.activeQuests = deserializedGame.activeQuests;
                //}

                //////////////////
                // Assuming 'jsonString' is the text read from your saved file
                string jsonString = File.ReadAllText(fileName);

                // Parse the JSON into a Document
                using (JsonDocument doc = JsonDocument.Parse(jsonString))
                {
                    //Dictionary<GameStateType, GameState> loadGameStateMap = doc.RootElement
                    //                                                        .GetProperty("GameStateMap")
                    //                                                        .Deserialize<Dictionary<GameStateType, GameState>>();
                    //GameState loadGameState = doc.RootElement
                    //                          .GetProperty("GameState")
                    //                          .Deserialize<GameState>();
                    List<Location> loadMaps = doc.RootElement
                                              .GetProperty("Maps")
                                              .Deserialize<List<Location>>();
                    int loadActiveMap = doc.RootElement
                                        .GetProperty("ActiveMap")
                                        .Deserialize<int>();
                    Player loadPlayer = doc.RootElement
                                        .GetProperty("Player")
                                        .Deserialize<Player>();
                    List<Quest> loadQuests = doc.RootElement
                                             .GetProperty("ActiveQuests")
                                             .Deserialize<List<Quest>>();

                    //Instance.GameStateMap = loadGameStateMap;
                    //Instance.GameState = loadGameState;
                    Instance.Maps = loadMaps;
                    Instance.ActiveMap = loadActiveMap;
                    Instance.Player = loadPlayer;
                    Instance.activeQuests = loadQuests;
                }

                //// Not working bcs I have complex types
                //// Parse into a JsonNode instead of trying to instantiate 'Game'
                //JsonNode? jsonNode = JsonNode.Parse(json);

                //if (jsonNode != null)
                //{
                //    Console.WriteLine();
                //    if (jsonNode["GameStateMap"] != null)
                //        _instance.gameStateMap = jsonNode["GameStateMap"]!.GetValue<Dictionary<GameStateType, GameState>>();

                //    if (jsonNode["GameState"] != null)
                //        _instance.gameState = jsonNode["GameState"]!.GetValue<GameState>();

                //    if (jsonNode["Maps"] != null)
                //        _instance.maps = jsonNode["Maps"]!.GetValue<List<Location>>();

                //    if (jsonNode["ActiveMap"] != null)
                //        _instance.activeMap = jsonNode["ActiveMap"]!.GetValue<int>();

                //    if (jsonNode["Player"] != null)
                //        _instance.player = jsonNode["Player"]!.GetValue<Player>();

                //    if (jsonNode["ActiveQuests"] != null)
                //        _instance.activeQuests = jsonNode["ActiveQuests"]!.GetValue<List<Quest>>();
                //}

                Instance.ChangeState(GameStateType.Exploration);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                Environment.Exit(-1);
            }
        }

        public void NewGame(string _mapFileName = "map.json")
        {
            //check if map exist
            if (Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Maps", "MainStory")))
                Instance.LoadMaps();

            //TODO - test
            Instance.changeLocation("Campaign");

            Instance.Player = EntityManager.Player;
            Instance.Maps[ActiveMap].PlayerX = Instance.Maps[ActiveMap].EntryX;
            Instance.Maps[ActiveMap].PlayerY = Instance.Maps[ActiveMap].EntryY;

            Instance.ChangeState(GameStateType.Exploration);
        }

        public void ChangeState(GameStateType stateType, params object[] parameters)
        {
            //TODO - dynamic values
            GameState newState = stateType switch
            {
                GameStateType.Menu => new MainMenuState(),
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
                //DEBUG
                //Console.WriteLine($"GameState changed to: {GameState.GetType().Name}");
                Instance.GameState.Render();
            }
            else
                Console.WriteLine($"ERROR: Invalid GameState");
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

        public void TeleportPlayerToCoordinates(int x, int y)
        {
            if (x < Instance.Maps[ActiveMap].Map[0].Count && y < Instance.Maps[ActiveMap].Map.Count)
                MovePlayer(x, y);
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

        public void changeLocation(string mapName)
        {
            if (mapName == "" || mapName == null)
                return;

            bool mapFound = false;

            //test
            int testX = Game.Instance.Maps[Game.Instance.ActiveMap].PlayerX;
            int testY = Game.Instance.Maps[Game.Instance.ActiveMap].PlayerY;
            int TestX = Game.Instance.Maps[Game.Instance.ActiveMap].EntryX;
            int TestY = Game.Instance.Maps[Game.Instance.ActiveMap].EntryY;

            //store last player place if from Main map
            if (Instance.Maps[ActiveMap].Name == "Campaign")
            {
                Instance.Maps[ActiveMap].EntryX = Instance.Maps[ActiveMap].PlayerX;
                Instance.Maps[ActiveMap].EntryY = Instance.Maps[ActiveMap].PlayerY;
            }

            for (int map = 0; map < Instance.Maps.Count; map++)
                if (Instance.Maps[map].Name == mapName)
                {
                    Instance.ActiveMap = map;
                    mapFound = true;
                    break;
                }

            if (!mapFound)
            {
                Console.WriteLine("Map not found. Program shutting off.");
                Environment.Exit(1);
            }

            Instance.Maps[ActiveMap].PlayerX = Instance.Maps[ActiveMap].EntryX;
            Instance.Maps[ActiveMap].PlayerY = Instance.Maps[ActiveMap].EntryY;

            //test
            int _testX = Game.Instance.Maps[Game.Instance.ActiveMap].PlayerX;
            int _testY = Game.Instance.Maps[Game.Instance.ActiveMap].PlayerY;
            int _TestX = Game.Instance.Maps[Game.Instance.ActiveMap].EntryX;
            int _TestY = Game.Instance.Maps[Game.Instance.ActiveMap].EntryY;

            Instance.GameState.Render();
            Instance.GameState.Update();

            //throw new NotImplementedException();
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

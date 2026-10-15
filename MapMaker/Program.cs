using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using TurnBasedRPG.Source.Entities;
using TurnBasedRPG.Source.Entities.AllyRoles;
using TurnBasedRPG.Source.Entities.EnemyTypes;
using TurnBasedRPG.Source.GameObjects;
using TurnBasedRPG.Source.GameObjects.Items;
using TurnBasedRPG.Source.GameObjects.Items.ItemTypes;
using TurnBasedRPG.Source.Locations.Nodes;
using TurnBasedRPG.Source.Managers;
using TurnBasedRPG.Source.Utils;

namespace MapMaker
{
    class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Please provide the file name as an argument (from folder 'Assets').");
                return;
            }

            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Assets");
            string filePath = Path.Combine(folderPath, args[0]);

            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine($"Folder 'Assets' not found in root folder of program.\n{Directory.GetCurrentDirectory()}");
                return;
            }

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File '{args[0]}' not found at '{filePath}'");
                return;
            }

            List<List<Node>> map = new List<List<Node>>();

            foreach (var line in File.ReadAllLines(filePath))
            {
                List<Node> row = new List<Node>();

                foreach (char _char in line)
                {
                    switch (_char)
                    {
                        //Meadows
                        case 'a':
                            if (Roll.RollDice(20))
                                row.Add(NodeManager.GrassWithFlower);
                            else
                                row.Add(NodeManager.Grass);
                            break;
                        case 'A':
                            if (Roll.RollDice(20))
                                row.Add(NodeManager.CombatMeadowsGrassWithFlower);
                            else
                                row.Add(NodeManager.CombatMeadowsGrass);
                            break;
                        //Plains
                        case 'b':
                            if (Roll.RollDice(5))
                                row.Add(NodeManager.GrassWithStickA);
                            else if (Roll.RollDice(5))
                                row.Add(NodeManager.GrassWithStickB);
                            else if (Roll.RollDice(5))
                                row.Add(NodeManager.GrassWithPeble);
                            else
                                row.Add(NodeManager.Grass);
                            break;
                        case 'B':
                            if (Roll.RollDice(5))
                                row.Add(NodeManager.CombatGrassWithStickA);
                            else if (Roll.RollDice(5))
                                row.Add(NodeManager.CombatGrassWithStickB);
                            else if (Roll.RollDice(5))
                                row.Add(NodeManager.CombatGrassWithPeble);
                            else
                                row.Add(NodeManager.CombatGrass);
                            break;
                        //Forest
                        case 'c':
                            if (Roll.RollDice(50))
                                row.Add(NodeManager.ForestA);
                            else
                                row.Add(NodeManager.ForestB);
                            break;
                        case 'C':
                            if (Roll.RollDice(50))
                                row.Add(NodeManager.CombatForestA);
                            else
                                row.Add(NodeManager.CombatForestB);
                            break;
                        //Deep forest
                        case 'd':
                            if (Roll.RollDice(50))
                                row.Add(NodeManager.DeepForestA);
                            else
                                row.Add(NodeManager.DeepForestB);
                            break;
                        case 'D':
                            if (Roll.RollDice(50))
                                row.Add(NodeManager.CombatDeepForestA);
                            else
                                row.Add(NodeManager.CombatDeepForestB);
                            break;
                        //Desert
                        case 'e':
                            if (Roll.RollDice(4))
                                row.Add(NodeManager.SandWithCactus);
                            else if (Roll.RollDice(2))
                                row.Add(NodeManager.SandWithTumbleweed);
                            else
                                row.Add(NodeManager.Sand);
                            break;
                        case 'E':
                            if (Roll.RollDice(6))
                                row.Add(NodeManager.CombatSandWithCactus);
                            else if (Roll.RollDice(2))
                                row.Add(NodeManager.CombatSandWithTumbleweed);
                            else
                                row.Add(NodeManager.CombatSand);
                            break;
                        //Savana
                        case 'f':
                            if (Roll.RollDice(10))
                                row.Add(NodeManager.SandWithGrass);
                            else if (Roll.RollDice(10))
                                row.Add(NodeManager.SandWithTree);
                            else
                                row.Add(NodeManager.Sand);
                            break;
                        case 'F':
                            if (Roll.RollDice(10))
                                row.Add(NodeManager.CombatSandWithGrass);
                            else if (Roll.RollDice(10))
                                row.Add(NodeManager.CombatSandWithTree);
                            else
                                row.Add(NodeManager.CombatSavanaSand);
                            break;
                        //Ash land
                        case 'g':
                            if (Roll.RollDice(10))
                                row.Add(NodeManager.AshesWithLavaCrack);
                            else if (Roll.RollDice(10))
                                row.Add(NodeManager.AshesWithBurntTree);
                            else
                                row.Add(NodeManager.Ashes);
                            break;
                        case 'G':
                            if (Roll.RollDice(10))
                                row.Add(NodeManager.CombatAshesWithLavaCrack);
                            else if (Roll.RollDice(10))
                                row.Add(NodeManager.CombatAshesWithBurntTree);
                            else
                                row.Add(NodeManager.CombatAshes);
                            break;
                        //Volcano
                        case 'h':
                            if (Roll.RollDice(10))
                                row.Add(NodeManager.LavaWithRock);
                            else if (Roll.RollDice(10))
                                row.Add(NodeManager.AshesWithLavaCrack);
                            else
                                row.Add(NodeManager.Ashes);
                                break;
                        case 'H':
                            if (Roll.RollDice(5))
                                row.Add(NodeManager.CombatLavaWithRock);
                            else if (Roll.RollDice(10))
                                row.Add(NodeManager.CombatVolcanoWithLavaCrack);
                            else
                                row.Add(NodeManager.CombatVolcanoAshes);
                            break;
                        //Volcano - obstacle
                        case 'O':
                            row.Add(NodeManager.Lava);
                            break;
                        //Heaven
                        case 'i':
                            row.Add(NodeManager.CloudOverOcean);
                            break;
                        case 'I':
                            row.Add(NodeManager.CombatSolidCloud);
                            break;
                        //Ocean
                        case 'o':
                            if (Roll.RollDice(7))
                                row.Add(NodeManager.OceanD);
                            else if (Roll.RollDice(7))
                                row.Add(NodeManager.OceanC);
                            else if (Roll.RollDice(7))
                                row.Add(NodeManager.OceanB);
                            else
                                row.Add(NodeManager.OceanA);
                            break;
                        //Shallow water
                        case 'p':
                            row.Add(NodeManager.ShallowWaterA);
                            break;
                        case 'q':
                            row.Add(NodeManager.ShallowWaterB);
                            break;
                        //Structures
                        case '0':
                            row.Add(NodeManager.StartingVillage);
                            break;
                        case '1':
                            row.Add(NodeManager.PlainsTown);
                            break;
                        case '2':
                            row.Add(NodeManager.ForestTown);
                            break;
                        case '3':
                            row.Add(NodeManager.DesertTown);
                            break;
                        case '4':
                            row.Add(NodeManager.SavanaCamp);
                            break;
                        case '5':
                            row.Add(NodeManager.AshLandCamp);
                            break;
                        case '6':
                            row.Add(NodeManager.HeavenTavern);
                            break;
                        default:
                            row.Add(NodeManager.DEBUG_ERROR);
                            break;
                    }
                }

                map.Add(row);
            }

            foreach (var mapLine in map)
            {
                foreach (Node node in mapLine)
                    node.Write();

                Console.WriteLine();
            }

            string serializedFilePath = Path.Combine(folderPath, $"SERIALIZED_{Path.GetFileNameWithoutExtension(filePath)}.json");
            Serialize2DList(map, serializedFilePath);
            Console.WriteLine("Successfully serialized map above");

            //string json = File.ReadAllText(serializedFilePath);

            //var options = new JsonSerializerOptions { WriteIndented = true };
            //var deserializedList = JsonSerializer.Deserialize<List<List<Node>>>(json, options);
            //Console.WriteLine(deserializedList);
        }

        static void Serialize2DList(List<List<Node>> map, string filePath)
        {
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

            string json = JsonSerializer.Serialize<object>(map, options);
            File.WriteAllText(filePath, json);
        }
    }
}
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using tahova_RPG_hra.Source.Entities;
using tahova_RPG_hra.Source.Locations.Nodes;
using tahova_RPG_hra.Source.Managers;
using tahova_RPG_hra.Source.Utils;

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
                        case 'a':
                            if (Roll.RollDice(10))
                                row.Add(NodeManager.GrassWithPebles);
                            else if (Roll.RollDice(10))
                                row.Add(NodeManager.GrassWithBranch);
                            else
                                row.Add(NodeManager.Grass);
                            break;
                        case 'A':
                            if (Roll.RollDice(10))
                                row.Add(NodeManager.CombatGrassWithPebles);
                            else if (Roll.RollDice(10))
                                row.Add(NodeManager.CombatGrassWithBranch);
                            else
                                row.Add(NodeManager.CombatGrass);
                            break;
                        case 'b':
                            if (Roll.RollDice(50))
                                row.Add(NodeManager.ForestA);
                            else
                                row.Add(NodeManager.ForestB);
                            break;
                        case 'B':
                            if (Roll.RollDice(50))
                                row.Add(NodeManager.CombatForestA);
                            else
                                row.Add(NodeManager.CombatForestB);
                            break;
                        case 'c':
                            if (Roll.RollDice(10))
                                row.Add(NodeManager.DesertWithCactus);
                            else if (Roll.RollDice(5))
                                row.Add(NodeManager.DesertWithTumbleweed);
                            else
                                row.Add(NodeManager.Desert);
                            break;
                        case 'd':
                            if (Roll.RollDice(10))
                                row.Add(NodeManager.RockWithOtherRocks);
                            else
                                row.Add(NodeManager.RockyGround);
                            break;
                        case 'e':
                            row.Add(NodeManager.RockWithLittleSnow);
                            break;
                        case 'f':
                            row.Add(NodeManager.Snow);
                            break;
                        case 'g':
                            row.Add(NodeManager.HotRock);
                            break;
                        case 'h':
                            row.Add(NodeManager.ShallowWater);
                            break;
                        case 'i':
                            row.Add(NodeManager.Water);
                            break;
                        case 'j':
                            if (Roll.RollDice(80))
                                row.Add(NodeManager.OceanWaterA);
                            else if (Roll.RollDice(33))
                                row.Add(NodeManager.OceanWaterB);
                            else if (Roll.RollDice(33))
                                row.Add(NodeManager.OceanWaterC);
                            else
                                row.Add(NodeManager.OceanWaterD);
                            break;
                        //Obstacles (IsMovable = false)
                        case '0':
                            row.Add(NodeManager.ObstacleBigTrunk);
                            break;
                        case '1':
                            row.Add(NodeManager.ObstacleBigRock);
                            break;
                        case '2':
                            row.Add(NodeManager.ObstracleHole);
                            break;
                        case '3':
                            if (Roll.RollDice(50))
                                row.Add(NodeManager.ObstacleMagma);
                            else
                                row.Add(NodeManager.ObstacleLava);
                            break;
                        //Structures
                        case 'V':
                            row.Add(NodeManager.Village);
                            break;
                        case 'K':
                            row.Add(NodeManager.Town1);
                            break;
                        case 'L':
                            row.Add(NodeManager.Town2);
                            break;
                        case 'M':
                            row.Add(NodeManager.Town3);
                            break;
                        case 'N':
                            row.Add(NodeManager.Town4);
                            break;
                        case 'O':
                            row.Add(NodeManager.Town5);
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
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize<object>(map, options);
            File.WriteAllText(filePath, json);
        }
    }
}
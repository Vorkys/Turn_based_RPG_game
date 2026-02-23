using System.Text.Json;
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
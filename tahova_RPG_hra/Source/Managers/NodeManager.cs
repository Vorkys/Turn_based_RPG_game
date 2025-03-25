using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Entities;
using tahova_RPG_hra.Source.Locations.Nodes;

namespace tahova_RPG_hra.Source.Managers
{
    public class NodeManager
    {
        public static Node Grass = new(' ', "Green", "Green", "Green", true);
        public static Node GrassWithPebles = new('.', "Green", "Gray", "Green", true);
        public static Node GrassWithBranch = new('-', "Green", "DarkRed", "Green", true);
        public static Node ForestA = new('A', "Green", "DarkGreen", "DarkGreen", true);
        public static Node ForestB = new('T', "Green", "DarkGreen", "DarkGreen", true);
        public static Node Desert = new(' ', "Yellow", "Yellow", "Yellow", true);
        public static Node DesertWithCactus = new('t', "Yellow", "Green", "Yellow", true);
        public static Node DesertWithTumbleweed = new('o', "Yellow", "DarkRed", "Yellow", true);
        public static Node RockyGround = new(' ', "Gray", "Gray", "Gray", true);
        public static Node RockWithOtherRocks = new('.', "Gray", "DarkGray", "Gray", true);
        public static Node RockWithLittleSnow = new('x', "Gray", "White", "White", true);
        public static Node Snow = new(' ', "White", "White", "White", true);
        public static Node HotRock = new('@', "DarkRed", "DarkGray", "DarkGray", true);
        public static Node ShallowWater = new(':', "Cyan", "Blue", "Cyan", false);
        public static Node Water = new('~', "Blue", "DarkBlue", "Blue", false);
        public static Node OceanWaterA = new(' ', "DarkBlue", "White", "DarkBlue", false);
        public static Node OceanWaterB = new('.', "DarkBlue", "White", "DarkBlue", false);
        public static Node OceanWaterC = new(':', "DarkBlue", "White", "DarkBlue", false);
        public static Node OceanWaterD = new('-', "DarkBlue", "White", "DarkBlue", false);

        //Obstacles
        public static Node ObstacleBigTrunk = new('H', "Green", "DarkRed", "Green", false);
        public static Node ObstacleBigRock = new('O', "Green", "Gray", "DarkGreen", false);
        public static Node ObstracleHole = new('O', "Yellow", "Black", "Black", false);
        public static Node ObstacleMagma = new('~', "Red", "DarkRed", "DarkRed", false);
        public static Node ObstacleLava = new('~', "DarkRed", "Red", "Red", false);

        //Combat node
        public static CombatNode CombatGrass = new(' ', "Green", "Green", "Green", true, 15, 1, 3, new List<Enemy> { EntityManager.SmallGoblin });
        public static CombatNode CombatGrassWithPebles = new('.', "Green", "Gray", "Green", true, 15, 1, 3, new List<Enemy> { EntityManager.SmallGoblin });
        public static CombatNode CombatGrassWithBranch = new('-', "Green", "DarkRed", "Green", true, 15, 1, 3, new List<Enemy> { EntityManager.SmallGoblin });
        public static CombatNode CombatForestA = new('A', "Green", "DarkGreen", "DarkGreen", true, 15, 6, 12, new List<Enemy> { EntityManager.BlackWolve });
        public static CombatNode CombatForestB = new('T', "Green", "DarkGreen", "DarkGreen", true, 15, 6, 12, new List<Enemy> { EntityManager.BlackWolve });

        //Structures
        public static Node Village = new('m', "Green", "Magenta", "Magenta", true);
        public static Node Town1 = new('M', "Green", "Magenta", "Magenta", true);
        public static Node Town2 = new('M', "Green", "Magenta", "Magenta", true);
        public static Node Town3 = new('M', "Yellow", "Magenta", "Magenta", true);
        public static Node Town4 = new('m', "Gray", "Magenta", "Magenta", true);
        public static Node Town5 = new('M', "Gray", "Magenta", "Magenta", true);
    }
}

using System.Collections.Generic;
using System.Reflection.Metadata;
using tahova_RPG_hra.Source.Entities;
using tahova_RPG_hra.Source.Locations.Nodes;

namespace tahova_RPG_hra.Source.Managers
{
    public class NodeManager
    {
        #region Plains & Meadows nodes
        public static Node Grass = new(
            nodeChar: ' ',
            backgroundColor: "Green",
            foregroundColor: "Green",
            mapColor: "Green",
            isMovable: true
        );
        public static CombatNode CombatGrass = new(
            nodeChar: ' ',
            backgroundColor: "Green",
            foregroundColor: "Green",
            mapColor: "Green",
            isMovable: true,
            spawnRate: 15,
            minEnemyLvl: 3,
            maxEnemyLvl: 8,
            enemyToSpawn: new List<Enemy> { EntityManager.GoblinWarrior, EntityManager.GoblinArcher, EntityManager.Wolf, EntityManager.BigGoblin }
        );
        public static CombatNode CombatMeadowsGrass = new(
            nodeChar: ' ',
            backgroundColor: "Green",
            foregroundColor: "Green",
            mapColor: "Green",
            isMovable: true,
            spawnRate: 15,
            minEnemyLvl: 1,
            maxEnemyLvl: 3,
            enemyToSpawn: new List<Enemy> { EntityManager.CuteSlime, EntityManager.SmallGoblin }
        );

        public static Node GrassWithStickA = new(
            nodeChar: '’',
            backgroundColor: "Green",
            foregroundColor: "DarkRed",
            mapColor: "Green",
            isMovable: true
        );
        public static CombatNode CombatGrassWithStickA = new(
            nodeChar: '’',
            backgroundColor: "Green",
            foregroundColor: "DarkRed",
            mapColor: "Green",
            isMovable: true,
            spawnRate: 15,
            minEnemyLvl: 1,
            maxEnemyLvl: 3,
            enemyToSpawn: new List<Enemy> { EntityManager.CuteSlime, EntityManager.SmallGoblin, EntityManager.Wolf, EntityManager.BigGoblin }
        );

        public static Node GrassWithStickB = new(
            nodeChar: '~',
            backgroundColor: "Green",
            foregroundColor: "DarkRed",
            mapColor: "Green",
            isMovable: true
        );
        public static CombatNode CombatGrassWithStickB = new(
            nodeChar: '~',
            backgroundColor: "Green",
            foregroundColor: "DarkRed",
            mapColor: "Green",
            isMovable: true,
            spawnRate: 15,
            minEnemyLvl: 1,
            maxEnemyLvl: 3,
            enemyToSpawn: new List<Enemy> { EntityManager.CuteSlime, EntityManager.SmallGoblin, EntityManager.Wolf, EntityManager.BigGoblin }
        );

        public static Node GrassWithPeble = new(
            nodeChar: '.',
            backgroundColor: "Green",
            foregroundColor: "Grey",
            mapColor: "Green",
            isMovable: true
        );
        public static CombatNode CombatGrassWithPeble = new(
            nodeChar: '.',
            backgroundColor: "Green",
            foregroundColor: "Grey",
            mapColor: "Green",
            isMovable: true,
            spawnRate: 15,
            minEnemyLvl: 1,
            maxEnemyLvl: 3,
            enemyToSpawn: new List<Enemy> { EntityManager.CuteSlime, EntityManager.SmallGoblin, EntityManager.Wolf, EntityManager.BigGoblin }
        );

        public static Node GrassWithFlower = new(
            nodeChar: '*',
            backgroundColor: "Green",
            foregroundColor: "Magenta",
            mapColor: "Green",
            isMovable: true
        );
        public static CombatNode CombatMeadowsGrassWithFlower = new(
            nodeChar: '*',
            backgroundColor: "Green",
            foregroundColor: "Magenta",
            mapColor: "Green",
            isMovable: true,
            spawnRate: 15,
            minEnemyLvl: 1,
            maxEnemyLvl: 3,
            enemyToSpawn: new List<Enemy> { EntityManager.CuteSlime, EntityManager.SmallGoblin }
        );
        #endregion

        #region Forest and Deep forest
        public static Node ForestA = new(
            nodeChar: 'f',
            backgroundColor: "Green",
            foregroundColor: "DarkGreen",
            mapColor: "DarkGreen",
            isMovable: true
        );
        public static CombatNode CombatForestA = new(
            nodeChar: 'f',
            backgroundColor: "Green",
            foregroundColor: "DarkGreen",
            mapColor: "DarkGreen",
            isMovable: true,
            spawnRate: 15,
            minEnemyLvl: 7,
            maxEnemyLvl: 12,
            enemyToSpawn: new List<Enemy> { EntityManager.Slime, EntityManager.BanditWarrior, EntityManager.BanditArcher, EntityManager.LivingMushroom }
        );

        public static Node ForestB = new(
            nodeChar: 'p',
            backgroundColor: "Green",
            foregroundColor: "DarkGreen",
            mapColor: "DarkGreen",
            isMovable: true
        );
        public static CombatNode CombatForestB = new(
            nodeChar: 'p',
            backgroundColor: "Green",
            foregroundColor: "DarkGreen",
            mapColor: "DarkGreen",
            isMovable: true,
            spawnRate: 15,
            minEnemyLvl: 7,
            maxEnemyLvl: 12,
            enemyToSpawn: new List<Enemy> { EntityManager.Slime, EntityManager.BanditWarrior, EntityManager.BanditArcher, EntityManager.LivingMushroom }
        );

        public static Node DeepForestA = new(
            nodeChar: 'A',
            backgroundColor: "Green",
            foregroundColor: "DarkGreen",
            mapColor: "DarkGreen",
            isMovable: true
        );
        public static CombatNode CombatDeepForestA = new(
            nodeChar: 'A',
            backgroundColor: "Green",
            foregroundColor: "DarkGreen",
            mapColor: "DarkGreen",
            isMovable: true,
            spawnRate: 15,
            minEnemyLvl: 9,
            maxEnemyLvl: 15,
            enemyToSpawn: new List<Enemy> { EntityManager.LivingMushroom, EntityManager.LivingTree, EntityManager.LivingRock }
        );

        public static Node DeepForestB = new(
            nodeChar: 'T',
            backgroundColor: "Green",
            foregroundColor: "DarkGreen",
            mapColor: "DarkGreen",
            isMovable: true
        );
        public static CombatNode CombatDeepForestB = new(
            nodeChar: 'T',
            backgroundColor: "Green",
            foregroundColor: "DarkGreen",
            mapColor: "DarkGreen",
            isMovable: true,
            spawnRate: 15,
            minEnemyLvl: 9,
            maxEnemyLvl: 15,
            enemyToSpawn: new List<Enemy> { EntityManager.LivingMushroom, EntityManager.LivingTree, EntityManager.LivingRock }
        );
        #endregion

        #region Deset and Savana
        public static Node Sand = new(
            nodeChar: ' ',
            backgroundColor: "Yellow",
            foregroundColor: "Yellow",
            mapColor: "Yellow",
            isMovable: true
        );
        public static CombatNode CombatSand = new(
            nodeChar: ' ',
            backgroundColor: "Yellow",
            foregroundColor: "Yellow",
            mapColor: "Yellow",
            isMovable: true,
            spawnRate: 15,
            minEnemyLvl: 14,
            maxEnemyLvl: 18,
            enemyToSpawn: new List<Enemy> { EntityManager.Lion, EntityManager.Hyena, EntityManager.Scorpion, EntityManager.Worm }
        );
        public static CombatNode CombatSavanaSand = new(
            nodeChar: ' ',
            backgroundColor: "Yellow",
            foregroundColor: "Yellow",
            mapColor: "DarkGreen",
            isMovable: true,
            spawnRate: 15,
            minEnemyLvl: 17,
            maxEnemyLvl: 20,
            enemyToSpawn: new List<Enemy> { EntityManager.LivingTumbleweed, EntityManager.Cobra }
        );

        public static Node SandWithCactus = new(
            nodeChar: 'f',
            backgroundColor: "Yellow",
            foregroundColor: "DarkGreen",
            mapColor: "Yellow",
            isMovable: true
        );
        public static CombatNode CombatSandWithCactus = new(
            nodeChar: 'f',
            backgroundColor: "Yellow",
            foregroundColor: "DarkGreen",
            mapColor: "Yellow",
            isMovable: true,
            spawnRate: 15,
            minEnemyLvl: 14,
            maxEnemyLvl: 18,
            enemyToSpawn: new List<Enemy> { EntityManager.Lion, EntityManager.Hyena, EntityManager.Scorpion, EntityManager.Worm }
        );

        public static Node SandWithTumbleweed = new(
            nodeChar: 'o',
            backgroundColor: "Yellow",
            foregroundColor: "DarkRed",
            mapColor: "Yellow",
            isMovable: true
        );
        public static CombatNode CombatSandWithTumbleweed = new(
            nodeChar: 'o',
            backgroundColor: "Yellow",
            foregroundColor: "DarkRed",
            mapColor: "Yellow",
            isMovable: true,
            spawnRate: 15,
            minEnemyLvl: 14,
            maxEnemyLvl: 18,
            enemyToSpawn: new List<Enemy> { EntityManager.Lion, EntityManager.Hyena, EntityManager.Scorpion, EntityManager.Worm }
        );

        public static Node SandWithGrass = new(
            nodeChar: '"',
            backgroundColor: "Yellow",
            foregroundColor: "DarkGreen",
            mapColor: "Yellow",
            isMovable: true
        );
        public static CombatNode CombatSandWithGrass = new(
            nodeChar: '"',
            backgroundColor: "Yellow",
            foregroundColor: "DarkGreen",
            mapColor: "Yellow",
            isMovable: true,
            spawnRate: 15,
            minEnemyLvl: 17,
            maxEnemyLvl: 20,
            enemyToSpawn: new List<Enemy> { EntityManager.LivingTumbleweed, EntityManager.Cobra }
        );

        public static Node SandWithTree = new(
            nodeChar: 'T',
            backgroundColor: "Yellow",
            foregroundColor: "DarkGreen",
            mapColor: "Yellow",
            isMovable: true
        );
        public static CombatNode CombatSandWithTree = new(
            nodeChar: 'T',
            backgroundColor: "Yellow",
            foregroundColor: "DarkGreen",
            mapColor: "Yellow",
            isMovable: true,
            spawnRate: 15,
            minEnemyLvl: 17,
            maxEnemyLvl: 20,
            enemyToSpawn: new List<Enemy> { EntityManager.LivingTumbleweed, EntityManager.Cobra }
        );
        #endregion

        #region Volcano and Ash lands
        public static Node AshesWithLavaCrack = new(
            nodeChar: '~',
            backgroundColor: "Gray",
            foregroundColor: "Red",
            mapColor: "Gray",
            isMovable: true
        );
        public static CombatNode CombatVolcanoWithLavaCrack = new(
            nodeChar: '~',
            backgroundColor: "Gray",
            foregroundColor: "Red",
            mapColor: "Gray",
            isMovable: true,
            spawnRate: 15,
            minEnemyLvl: 22,
            maxEnemyLvl: 25,
            enemyToSpawn: new List<Enemy> { EntityManager.CorruptedHuman, EntityManager.LavaTentacle, EntityManager.MagmaWarrior, EntityManager.Mage }
        );
        public static CombatNode CombatAshesWithLavaCrack = new(
            nodeChar: '~',
            backgroundColor: "Gray",
            foregroundColor: "Red",
            mapColor: "Gray",
            isMovable: true,
            spawnRate: 15,
            minEnemyLvl: 19,
            maxEnemyLvl: 22,
            enemyToSpawn: new List<Enemy> { EntityManager.Skeleton, EntityManager.Golem }
        );

        public static Node Lava = new(
            nodeChar: ' ',
            backgroundColor: "Red",
            foregroundColor: "Red",
            mapColor: "Gray",
            isMovable: true
        );

        public static Node LavaWithRock = new(
            nodeChar: '#',
            backgroundColor: "Red",
            foregroundColor: "Black",
            mapColor: "DarkRed",
            isMovable: true
        );
        public static CombatNode CombatLavaWithRock = new(
            nodeChar: '#',
            backgroundColor: "Red",
            foregroundColor: "Black",
            mapColor: "DarkRed",
            isMovable: true,
            spawnRate: 15,
            minEnemyLvl: 22,
            maxEnemyLvl: 25,
            enemyToSpawn: new List<Enemy> { EntityManager.CorruptedHuman, EntityManager.LavaTentacle, EntityManager.MagmaWarrior, EntityManager.Mage }
        );

        public static Node Ashes = new(
            nodeChar: ' ',
            backgroundColor: "Gray",
            foregroundColor: "Gray",
            mapColor: "Gray",
            isMovable: true
        );
        public static CombatNode CombatAshes = new(
            nodeChar: ' ',
            backgroundColor: "Gray",
            foregroundColor: "Gray",
            mapColor: "Gray",
            isMovable: true,
            spawnRate: 15,
            minEnemyLvl: 19,
            maxEnemyLvl: 22,
            enemyToSpawn: new List<Enemy> { EntityManager.Skeleton, EntityManager.Golem }
        );

        public static Node AshesWithBurntTree = new(
            nodeChar: 'f',
            backgroundColor: "Gray",
            foregroundColor: "Black",
            mapColor: "Gray",
            isMovable: true
        );
        public static CombatNode CombatAshesWithBurntTree = new(
            nodeChar: 'f',
            backgroundColor: "Gray",
            foregroundColor: "Black",
            mapColor: "Gray",
            isMovable: true,
            spawnRate: 15,
            minEnemyLvl: 19,
            maxEnemyLvl: 22,
            enemyToSpawn: new List<Enemy> { EntityManager.Skeleton, EntityManager.Golem }
        );
        #endregion

        #region Heaven
        public static Node CloudOverOcean = new(
            nodeChar: '@',
            backgroundColor: "DarkBlue",
            foregroundColor: "White",
            mapColor: "White",
            isMovable: true
        );

        public static CombatNode CombatSolidCloud = new(
            nodeChar: '#',
            backgroundColor: "White",
            foregroundColor: "Gray",
            mapColor: "White",
            isMovable: true,
            spawnRate: 15,
            minEnemyLvl: 25,
            maxEnemyLvl: 30,
            enemyToSpawn: new List<Enemy> { EntityManager.RelievedSoul, EntityManager.LivingArmor, EntityManager.Valkyrie, EntityManager.Angel }
        );
        #endregion

        #region Environment
        public static Node ShallowWaterA = new(
            nodeChar: ' ',
            backgroundColor: "Cyan",
            foregroundColor: "Blue",
            mapColor: "Cyan",
            isMovable: true
        );

        public static Node ShallowWaterB = new(
            nodeChar: ':',
            backgroundColor: "Cyan",
            foregroundColor: "Blue",
            mapColor: "Cyan",
            isMovable: true
        );

        public static Node OceanA = new(
            nodeChar: ' ',
            backgroundColor: "DarkBlue",
            foregroundColor: "White",
            mapColor: "DarkBlue",
            isMovable: true
        );

        public static Node OceanB = new(
            nodeChar: '.',
            backgroundColor: "DarkBlue",
            foregroundColor: "White",
            mapColor: "DarkBlue",
            isMovable: true
        );

        public static Node OceanC = new(
            nodeChar: ':',
            backgroundColor: "DarkBlue",
            foregroundColor: "White",
            mapColor: "DarkBlue",
            isMovable: true
        );

        public static Node OceanD = new(
            nodeChar: '~',
            backgroundColor: "DarkBlue",
            foregroundColor: "White",
            mapColor: "DarkBlue",
            isMovable: true
        );
        #endregion

        //Obstacles
        //public static Node ObstacleBigTrunk = new('H', "Green", "DarkRed", "Green", false);
        //public static Node ObstacleBigRock = new('O', "Green", "Gray", "DarkGreen", false);
        //public static Node ObstracleHole = new('O', "Yellow", "Black", "Black", false);
        //public static Node ObstacleMagma = new('~', "Red", "DarkRed", "DarkRed", false);
        //public static Node ObstacleLava = new('~', "DarkRed", "Red", "Red", false);

        //Structures
        public static TownNode Village = new('m', "Green", "Magenta", "Magenta", true, "Hometown", "The village I was born and grew up in.", "hometown.txt", null);
        //public static Node Town1 = new('M', "Green", "Magenta", "Magenta", true);
        public static TownNode Town1 = new('M', "Green", "Magenta", "Magenta", true, "Organa", "A medium sized town. Rest here and prepare for the forest (lvl 10 is recomended).", "organa.txt", null);
        public static TownNode Town2 = new('M', "Green", "Magenta", "Magenta", true, "Foresta", "A nice city hidden in the forest.", "foresta.txt", null);
        public static TownNode Town3 = new('M', "Yellow", "Magenta", "Magenta", true, "Deserta", "An old sand village with strange citizens. The game ends here.", "deserta.txt", null);
        public static Node Town4 = new('m', "Gray", "Magenta", "Magenta", true);
        public static TownNode Town5 = new('M', "Gray", "Magenta", "Magenta", true, "Volcana", "A rocky town partly destroyed by magma.", "volcana.txt", null);
    }
}

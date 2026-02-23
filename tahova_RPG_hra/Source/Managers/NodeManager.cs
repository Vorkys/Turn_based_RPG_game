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
            enemyToSpawn: new List<Enemy> { EntityManager.GoblinWarrior, EntityManager.GoblinArcher, EntityManager.Wolf, EntityManager.BigGoblin }
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
            enemyToSpawn: new List<Enemy> { EntityManager.CuteSlime, EntityManager.GoblinWarrior, EntityManager.GoblinArcher, EntityManager.Wolf, EntityManager.BigGoblin }
        );

        public static Node GrassWithPeble = new(
            nodeChar: '.',
            backgroundColor: "Green",
            foregroundColor: "Gray",
            mapColor: "Green",
            isMovable: true
        );
        public static CombatNode CombatGrassWithPeble = new(
            nodeChar: '.',
            backgroundColor: "Green",
            foregroundColor: "Gray",
            mapColor: "Green",
            isMovable: true,
            spawnRate: 15,
            minEnemyLvl: 1,
            maxEnemyLvl: 3,
            enemyToSpawn: new List<Enemy> { EntityManager.GoblinWarrior, EntityManager.GoblinArcher, EntityManager.Wolf, EntityManager.BigGoblin }
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
        //obstacle
        public static Node Lava = new(
            nodeChar: ' ',
            backgroundColor: "Red",
            foregroundColor: "Red",
            mapColor: "Gray",
            isMovable: false
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
        public static CombatNode CombatVolcanoAshes = new(
            nodeChar: ' ',
            backgroundColor: "Gray",
            foregroundColor: "Gray",
            mapColor: "Gray",
            isMovable: true,
            spawnRate: 15,
            minEnemyLvl: 19,
            maxEnemyLvl: 22,
            enemyToSpawn: new List<Enemy> { EntityManager.CorruptedHuman, EntityManager.LavaTentacle, EntityManager.MagmaWarrior, EntityManager.Mage }
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
            isMovable: false
        );

        public static Node ShallowWaterB = new(
            nodeChar: ':',
            backgroundColor: "Cyan",
            foregroundColor: "Blue",
            mapColor: "Cyan",
            isMovable: false
        );

        public static Node OceanA = new(
            nodeChar: ' ',
            backgroundColor: "DarkBlue",
            foregroundColor: "White",
            mapColor: "DarkBlue",
            isMovable: false
        );

        public static Node OceanB = new(
            nodeChar: '.',
            backgroundColor: "DarkBlue",
            foregroundColor: "White",
            mapColor: "DarkBlue",
            isMovable: false
        );

        public static Node OceanC = new(
            nodeChar: ':',
            backgroundColor: "DarkBlue",
            foregroundColor: "White",
            mapColor: "DarkBlue",
            isMovable: false
        );

        public static Node OceanD = new(
            nodeChar: '~',
            backgroundColor: "DarkBlue",
            foregroundColor: "White",
            mapColor: "DarkBlue",
            isMovable: false
        );
        #endregion

        #region Structures
        //Meadows village
        public static TownNode StartingVillage = new(
            nodeChar: 'm',
            backgroundColor: "Green",
            foregroundColor: "Magenta",
            mapColor: "Magenta",
            isMovable: true,
            name: "Veneta",
            description: "This is my village where I grew up in. Area level: 1-3",
            //townSprite not implemented
            townSprite: "hometown.txt",
            townPeople: null
        );
        //Plains town
        public static TownNode PlainsTown = new(
            nodeChar: 'M',
            backgroundColor: "Green",
            foregroundColor: "Magenta",
            mapColor: "Magenta",
            isMovable: true,
            name: "Fanges",
            description: "Big town in the middle of the plains. A lot of merchants are here. Area level: 3-8",
            //townSprite not implemented
            townSprite: "hometown.txt",
            townPeople: null
        );
        //Forest town
        public static TownNode ForestTown = new(
            nodeChar: 'M',
            backgroundColor: "Green",
            foregroundColor: "Magenta",
            mapColor: "Magenta",
            isMovable: true,
            name: "Enpolis",
            description: "Hidden town in the middle of the forest. Near the border to the deep forest. Area level: 7-15",
            //townSprite not implemented
            townSprite: "hometown.txt",
            townPeople: null
        );
        //Desert town
        public static TownNode DesertTown = new(
            nodeChar: 'M',
            backgroundColor: "Yellow",
            foregroundColor: "Magenta",
            mapColor: "Magenta",
            isMovable: true,
            name: "Arrowing",
            description: "Description. Area level: 14-18",
            //townSprite not implemented
            townSprite: "hometown.txt",
            townPeople: null
        );
        //Savana camp
        public static TownNode SavanaCamp = new(
            nodeChar: 'm',
            backgroundColor: "Yellow",
            foregroundColor: "Magenta",
            mapColor: "Magenta",
            isMovable: true,
            name: "Savana camp",
            description: "Small camp used for studying the environment. Area level: 17-20",
            //townSprite not implemented
            townSprite: "hometown.txt",
            townPeople: null
        );
        //Ash land camp
        public static TownNode AshLandCamp = new(
            nodeChar: 'm',
            backgroundColor: "Gray",
            foregroundColor: "Magenta",
            mapColor: "Magenta",
            isMovable: true,
            name: "Ash lands camp",
            description: "Advanced camp in the Ash lands to defend the main continent. Area level: 19-25",
            //townSprite not implemented
            townSprite: "hometown.txt",
            townPeople: null
        );
        //Heaven tavern
        public static TownNode HeavenTavern = new(
            nodeChar: 'm',
            backgroundColor: "White",
            foregroundColor: "Magenta",
            mapColor: "Magenta",
            isMovable: true,
            name: "Heavenly tavern",
            description: "A tavern in the heavens where you can rest. Area level: 25-30",
            //townSprite not implemented
            townSprite: "hometown.txt",
            townPeople: null
        );
        #endregion
    }
}

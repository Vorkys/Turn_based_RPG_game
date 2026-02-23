using System.Collections.Generic;
using tahova_RPG_hra.Source.Entities;
using tahova_RPG_hra.Source.Entities.AllyRoles;
using tahova_RPG_hra.Source.Entities.EnemyTypes;
using static tahova_RPG_hra.Source.Entities.Enemy;

namespace tahova_RPG_hra.Source.Managers
{
    //factory pattern
    class EntityManager
    {
        //Player
        public static Player Player = new(
            name: "Player",
            spritePath: "player.txt",
            inventory: null,
            equipment: null,
            level: 1,
            xPtoLevelUp: 70,
            maxHealth: 14,
            maxMana: 7,
            spells: null,
            damage: 6,
            criticalHitChance: 4,
            missChance: 2,
            armor: 2,
            speed: 14,
            money: 0
            );

        #region Enemies

        # region T1 enemies
        public static Slime CuteSlime = new(
            name: "Cute slime",
            spritePath: "cute_slime.txt",
            level: 1,
            maxLevel: 2,
            maxHealth: 7,
            maxMana: 6,
            spells: null,
            damage: 1,
            criticalHitChance: 4,
            missChance: 2,
            armor: 0,
            speed: 1,
            itemDrops: new List<Drop>()
            {
                new Drop(ItemManager.SmallHealthPotion, 15)
            },
            goldDrop: 2,
            escapeChance: 80,
            xpDrop: 10
        );

        public static Goblin SmallGoblin = new(
            name: "Small goblin",
            spritePath: "small_goblin.txt",
            level: 1,
            maxLevel: 3,
            maxHealth: 10,
            maxMana: 3,
            spells: null,
            damage: 3,
            criticalHitChance: 4,
            missChance: 2,
            armor: 0,
            speed: 5,
            itemDrops: new List<Drop>()
            {
                new Drop(ItemManager.SmallHealthPotion, 30),
                new Drop(ItemManager.SmallManaPotion, 10)
            },
            goldDrop: 5,
            escapeChance: 70,
            xpDrop: 15
        );

        public static Goblin GoblinWarrior = new(
            name: "Goblin warrior",
            spritePath: "goblin_warrior.txt",
            level: 3,
            maxLevel: 5,
            maxHealth: 15,
            maxMana: 4,
            spells: null,
            damage: 5,
            criticalHitChance: 4,
            missChance: 2,
            armor: 1,
            speed: 5,
            itemDrops: new List<Drop>()
            {
                new Drop(ItemManager.SmallHealthPotion, 30),
                new Drop(ItemManager.SmallManaPotion, 10)
            },
            goldDrop: 7,
            escapeChance: 60,
            xpDrop: 40
        );

        public static Goblin GoblinArcher = new(
            name: "Goblin archer",
            spritePath: "goblin_archer.txt",
            level: 3,
            maxLevel: 5,
            maxHealth: 12,
            maxMana: 4,
            spells: null,
            damage: 6,
            criticalHitChance: 4,
            missChance: 2,
            armor: 1,
            speed: 6,
            itemDrops: new List<Drop>()
            {
                new Drop(ItemManager.SmallHealthPotion, 30),
                new Drop(ItemManager.SmallManaPotion, 10)
            },
            goldDrop: 7,
            escapeChance: 60,
            xpDrop: 40
        );

        public static Goblin BigGoblin = new(
            name: "Big goblin",
            spritePath: "big_goblin.txt",
            level: 5,
            maxLevel: 8,
            maxHealth: 21,
            maxMana: 5,
            spells: null,
            damage: 7,
            criticalHitChance: 4,
            missChance: 2,
            armor: 2,
            speed: 4,
            itemDrops: new List<Drop>()
            {
                new Drop(ItemManager.SmallHealthPotion, 30),
                new Drop(ItemManager.SmallManaPotion, 10)
            },
            goldDrop: 10,
            escapeChance: 70,
            xpDrop: 55
        );

        public static Animal Wolf = new(
            name: "Wolf",
            spritePath: "wolf.txt",
            level: 4,
            maxLevel: 6,
            maxHealth: 15,
            maxMana: 1,
            spells: null,
            damage: 6,
            criticalHitChance: 4,
            missChance: 2,
            armor: 1,
            speed: 7,
            itemDrops: new List<Drop>()
            {
                new Drop(ItemManager.SmallHealthPotion, 30),
                new Drop(ItemManager.SmallManaPotion, 10)
            },
            goldDrop: 4,
            escapeChance: 60,
            xpDrop: 45
        );
        #endregion

        #region T2 enemies
        public static Slime Slime = new(
            name: "Slime",
            spritePath: "slime.txt",
            level: 7,
            maxLevel: 9,
            maxHealth: 19,
            maxMana: 15,
            spells: null,
            damage: 7,
            criticalHitChance: 4,
            missChance: 2,
            armor: 2,
            speed: 4,
            itemDrops: new List<Drop>()
            {
                new Drop(ItemManager.SmallHealthPotion, 30),
                new Drop(ItemManager.SmallManaPotion, 10)
            },
            goldDrop: 8,
            escapeChance: 60,
            xpDrop: 70
        );

        public static Human BanditWarrior = new(
            name: "Bandit warrior",
            spritePath: "bandit_warrior.txt",
            level: 8,
            maxLevel: 10,
            maxHealth: 22,
            maxMana: 10,
            spells: null,
            damage: 7,
            criticalHitChance: 4,
            missChance: 2,
            armor: 3,
            speed: 10,
            itemDrops: new List<Drop>()
            {
                new Drop(ItemManager.SmallHealthPotion, 30),
                new Drop(ItemManager.SmallManaPotion, 10)
            },
            goldDrop: 20,
            escapeChance: 60,
            xpDrop: 85
        );

        public static Human BanditArcher = new(
            name: "Bandit archer",
            spritePath: "bandit_archer.txt",
            level: 8,
            maxLevel: 10,
            maxHealth: 20,
            maxMana: 10,
            spells: null,
            damage: 8,
            criticalHitChance: 4,
            missChance: 2,
            armor: 2,
            speed: 11,
            itemDrops: new List<Drop>()
            {
                new Drop(ItemManager.SmallHealthPotion, 30),
                new Drop(ItemManager.SmallManaPotion, 10)
            },
            goldDrop: 20,
            escapeChance: 60,
            xpDrop: 85
        );

        public static Magical LivingMushroom = new(
            name: "Living mushroom",
            spritePath: "living_mushroom.txt",
            level: 9,
            maxLevel: 12,
            maxHealth: 24,
            maxMana: 14,
            spells: null,
            damage: 9,
            criticalHitChance: 4,
            missChance: 2,
            armor: 2,
            speed: 10,
            itemDrops: new List<Drop>()
            {
                new Drop(ItemManager.SmallHealthPotion, 30),
                new Drop(ItemManager.SmallManaPotion, 10)
            },
            goldDrop: 25,
            escapeChance: 60,
            xpDrop: 95
        );

        public static Magical LivingTree = new(
            name: "Living tree",
            spritePath: "living_tree.txt",
            level: 12,
            maxLevel: 15,
            maxHealth: 35,
            maxMana: 20,
            spells: null,
            damage: 11,
            criticalHitChance: 4,
            missChance: 2,
            armor: 3,
            speed: 13,
            itemDrops: new List<Drop>()
            {
                new Drop(ItemManager.SmallHealthPotion, 30),
                new Drop(ItemManager.SmallManaPotion, 10)
            },
            goldDrop: 35,
            escapeChance: 70,
            xpDrop: 115
        );

        public static Magical LivingRock = new(
            name: "Living rock",
            spritePath: "living_rock.txt",
            level: 13,
            maxLevel: 15,
            maxHealth: 38,
            maxMana: 22,
            spells: null,
            damage: 9,
            criticalHitChance: 4,
            missChance: 2,
            armor: 4,
            speed: 10,
            itemDrops: new List<Drop>()
            {
                new Drop(ItemManager.SmallHealthPotion, 30),
                new Drop(ItemManager.SmallManaPotion, 10)
            },
            goldDrop: 35,
            escapeChance: 60,
            xpDrop: 120
        );
        #endregion

        #region T3 enemies
        public static Animal Lion = new(
            name: "Lion",
            spritePath: "lion.txt",
            level: 14,
            maxLevel: 16,
            maxHealth: 40,
            maxMana: 15,
            spells: null,
            damage: 12,
            criticalHitChance: 4,
            missChance: 2,
            armor: 3,
            speed: 15,
            itemDrops: new List<Drop>()
            {
                new Drop(ItemManager.SmallHealthPotion, 30),
                new Drop(ItemManager.SmallManaPotion, 10)
            },
            goldDrop: 60,
            escapeChance: 60,
            xpDrop: 180
        );

        public static Animal Hyena = new(
            name: "Hyena",
            spritePath: "hyena.txt",
            level: 15,
            maxLevel: 16,
            maxHealth: 43,
            maxMana: 15,
            spells: null,
            damage: 13,
            criticalHitChance: 4,
            missChance: 2,
            armor: 3,
            speed: 15,
            itemDrops: new List<Drop>()
            {
                new Drop(ItemManager.SmallHealthPotion, 30),
                new Drop(ItemManager.SmallManaPotion, 10)
            },
            goldDrop: 65,
            escapeChance: 60,
            xpDrop: 200
        );

        public static Animal Scorpion = new(
            name: "Scorpion",
            spritePath: "scorpion.txt",
            level: 16,
            maxLevel: 17,
            maxHealth: 48,
            maxMana: 16,
            spells: null,
            damage: 13,
            criticalHitChance: 5,
            missChance: 2,
            armor: 3,
            speed: 18,
            itemDrops: new List<Drop>()
            {
                new Drop(ItemManager.SmallHealthPotion, 30),
                new Drop(ItemManager.SmallManaPotion, 10)
            },
            goldDrop: 75,
            escapeChance: 60,
            xpDrop: 220
        );

        public static Animal Worm = new(
            name: "Worm",
            spritePath: "worm.txt",
            level: 16,
            maxLevel: 18,
            maxHealth: 49,
            maxMana: 16,
            spells: null,
            damage: 11,
            criticalHitChance: 4,
            missChance: 2,
            armor: 4,
            speed: 17,
            itemDrops: new List<Drop>()
            {
                new Drop(ItemManager.SmallHealthPotion, 30),
                new Drop(ItemManager.SmallManaPotion, 10)
            },
            goldDrop: 85,
            escapeChance: 60,
            xpDrop: 230
        );

        public static Animal LivingTumbleweed = new(
            name: "Living tumbleweed",
            spritePath: "living_tumbleweed.txt",
            level: 17,
            maxLevel: 19,
            maxHealth: 52,
            maxMana: 30,
            spells: null,
            damage: 15,
            criticalHitChance: 4,
            missChance: 2,
            armor: 4,
            speed: 16,
            itemDrops: new List<Drop>()
            {
                new Drop(ItemManager.SmallHealthPotion, 30),
                new Drop(ItemManager.SmallManaPotion, 10)
            },
            goldDrop: 95,
            escapeChance: 60,
            xpDrop: 250
        );

        public static Animal Cobra = new(
            name: "Cobra",
            spritePath: "cobra.txt",
            level: 17,
            maxLevel: 20,
            maxHealth: 53,
            maxMana: 18,
            spells: null,
            damage: 17,
            criticalHitChance: 4,
            missChance: 2,
            armor: 3,
            speed: 20,
            itemDrops: new List<Drop>()
            {
                new Drop(ItemManager.SmallHealthPotion, 30),
                new Drop(ItemManager.SmallManaPotion, 10)
            },
            goldDrop: 95,
            escapeChance: 60,
            xpDrop: 270
        );
        #endregion

        #region T4 enemies
        public static Demonic Skeleton = new(
            name: "Skeleton",
            spritePath: "skeleton.txt",
            level: 19,
            maxLevel: 22,
            maxHealth: 58,
            maxMana: 30,
            spells: null,
            damage: 20,
            criticalHitChance: 4,
            missChance: 2,
            armor: 4,
            speed: 23,
            itemDrops: new List<Drop>()
            {
                new Drop(ItemManager.SmallHealthPotion, 30),
                new Drop(ItemManager.SmallManaPotion, 10)
            },
            goldDrop: 120,
            escapeChance: 60,
            xpDrop: 310
        );

        public static Magical Golem = new(
            name: "Golem",
            spritePath: "golem.txt",
            level: 20,
            maxLevel: 22,
            maxHealth: 65,
            maxMana: 33,
            spells: null,
            damage: 19,
            criticalHitChance: 4,
            missChance: 2,
            armor: 5,
            speed: 21,
            itemDrops: new List<Drop>()
            {
                new Drop(ItemManager.SmallHealthPotion, 30),
                new Drop(ItemManager.SmallManaPotion, 10)
            },
            goldDrop: 135,
            escapeChance: 70,
            xpDrop: 330
        );

        public static Demonic CorruptedHuman = new(
            name: "Corrupted human",
            spritePath: "corrupted_human.txt",
            level: 22,
            maxLevel: 24,
            maxHealth: 72,
            maxMana: 35,
            spells: null,
            damage: 23,
            criticalHitChance: 4,
            missChance: 2,
            armor: 4,
            speed: 26,
            itemDrops: new List<Drop>()
            {
                new Drop(ItemManager.SmallHealthPotion, 30),
                new Drop(ItemManager.SmallManaPotion, 10)
            },
            goldDrop: 170,
            escapeChance: 60,
            xpDrop: 370
        );

        public static Demonic LavaTentacle = new(
            name: "Lava tentacle",
            spritePath: "lava_tentacle.txt",
            level: 23,
            maxLevel: 25,
            maxHealth: 74,
            maxMana: 38,
            spells: null,
            damage: 23,
            criticalHitChance: 4,
            missChance: 2,
            armor: 4,
            speed: 27,
            itemDrops: new List<Drop>()
            {
                new Drop(ItemManager.SmallHealthPotion, 30),
                new Drop(ItemManager.SmallManaPotion, 10)
            },
            goldDrop: 175,
            escapeChance: 60,
            xpDrop: 380
        );

        public static Demonic MagmaWarrior = new(
            name: "Magma warrior",
            spritePath: "magma_warrior.txt",
            level: 22,
            maxLevel: 25,
            maxHealth: 75,
            maxMana: 30,
            spells: null,
            damage: 22,
            criticalHitChance: 4,
            missChance: 2,
            armor: 5,
            speed: 27,
            itemDrops: new List<Drop>()
            {
                new Drop(ItemManager.SmallHealthPotion, 30),
                new Drop(ItemManager.SmallManaPotion, 10)
            },
            goldDrop: 180,
            escapeChance: 60,
            xpDrop: 390
        );

        public static Human Mage = new(
            name: "Mage",
            spritePath: "mage.txt",
            level: 23,
            maxLevel: 25,
            maxHealth: 65,
            maxMana: 60,
            spells: null,
            damage: 17,
            criticalHitChance: 4,
            missChance: 2,
            armor: 4,
            speed: 29,
            itemDrops: new List<Drop>()
            {
                new Drop(ItemManager.SmallHealthPotion, 30),
                new Drop(ItemManager.SmallManaPotion, 10)
            },
            goldDrop: 210,
            escapeChance: 60,
            xpDrop: 420
        );
        #endregion

        #region T5 enemies
        public static Godly RelievedSoul = new(
            name: "Relieved soul",
            spritePath: "relieved_soul.txt",
            level: 25,
            maxLevel: 27,
            maxHealth: 85,
            maxMana: 85,
            spells: null,
            damage: 26,
            criticalHitChance: 4,
            missChance: 2,
            armor: 5,
            speed: 32,
            itemDrops: new List<Drop>()
            {
                new Drop(ItemManager.SmallHealthPotion, 30),
                new Drop(ItemManager.SmallManaPotion, 10)
            },
            goldDrop: 250,
            escapeChance: 60,
            xpDrop: 460
        );

        public static Godly LivingArmor = new(
            name: "Living armor",
            spritePath: "living_armor.txt",
            level: 26,
            maxLevel: 28,
            maxHealth: 90,
            maxMana: 90,
            spells: null,
            damage: 24,
            criticalHitChance: 4,
            missChance: 2,
            armor: 6,
            speed: 30,
            itemDrops: new List<Drop>()
            {
                new Drop(ItemManager.SmallHealthPotion, 30),
                new Drop(ItemManager.SmallManaPotion, 10)
            },
            goldDrop: 270,
            escapeChance: 70,
            xpDrop: 500
        );

        public static Godly Valkyrie = new(
            name: "Valkyrie",
            spritePath: "valkyrie.txt",
            level: 28,
            maxLevel: 30,
            maxHealth: 95,
            maxMana: 95,
            spells: null,
            damage: 27,
            criticalHitChance: 5,
            missChance: 1,
            armor: 7,
            speed: 32,
            itemDrops: new List<Drop>()
            {
                new Drop(ItemManager.SmallHealthPotion, 30),
                new Drop(ItemManager.SmallManaPotion, 10)
            },
            goldDrop: 300,
            escapeChance: 60,
            xpDrop: 550
        );

        public static Godly Angel = new(
            name: "Angel",
            spritePath: "angel.txt",
            level: 29,
            maxLevel: 30,
            maxHealth: 100,
            maxMana: 100,
            spells: null,
            damage: 29,
            criticalHitChance: 5,
            missChance: 1,
            armor: 7,
            speed: 35,
            itemDrops: new List<Drop>()
            {
                new Drop(ItemManager.SmallHealthPotion, 30),
                new Drop(ItemManager.SmallManaPotion, 10)
            },
            goldDrop: 330,
            escapeChance: 60,
            xpDrop: 580
        );
        #endregion

        #endregion

        public static ArenaOrganisator Organisator = new(
            name: "Town arena organisator",
            spritePath: "human.txt",
            inventory: null,
            equipment: null,
            level: 1,
            xPtoLevelUp: 70,
            maxHealth: 14,
            maxMana: 7,
            spells: null,
            damage: 6,
            criticalHitChance: 4,
            missChance: 2,
            armor: 2,
            speed: 14,
            money: 0,
            quests: null,
            enemies: new List<Enemy> { SmallGoblin }
            );
    }
}

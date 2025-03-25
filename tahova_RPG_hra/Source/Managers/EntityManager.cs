using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Core;
using tahova_RPG_hra.Source.Entities;
using tahova_RPG_hra.Source.Entities.EnemyTypes;
using tahova_RPG_hra.Source.Spells;
using static tahova_RPG_hra.Source.Entities.Enemy;

namespace tahova_RPG_hra.Source.Managers
{
    //factory pattern
    class EntityManager
    {
        public static Player Player = new(
            name: "Player",
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
            money: 0
            );

        public static Goblin SmallGoblin = new(
            name: "Small goblin",
            spritePath: "small_goblin.txt",
            level: 1,
            maxHealth: 10,
            maxMana: 3,
            spells: null,
            damage: 4,
            criticalHitChance: 4,
            missChance: 2,
            armor: 0,
            speed: 5,
            itemDrops: new List<Drop>()
            {
                new Drop(ItemManager.SmallHealthPotion, 50),
                new Drop(ItemManager.SmallManaPotion, 50),
                new Drop(ItemManager.WoodenSword, 10)
            },
            goldDrop: 5,
            escapeChance: 60,
            xpDrop: 15
        );

        public static Goblin Goblin = new(
            name: "Goblin",
            spritePath: "small_goblin.txt",
            level: 5,
            maxHealth: 15,
            maxMana: 5,
            spells: null,
            damage: 6,
            criticalHitChance: 4,
            missChance: 2,
            armor: 1,
            speed: 5,
            itemDrops: new List<Drop>()
            {
                new Drop(ItemManager.SmallHealthPotion, 50),
                new Drop(ItemManager.SmallManaPotion, 50),
                new Drop(ItemManager.WoodenSword, 10)
            },
            goldDrop: 5,
            escapeChance: 60,
            xpDrop: 35
        );

        public static Goblin BigGoblin = new(
            name: "Big goblin",
            spritePath: "big_goblin.txt",
            level: 12,
            maxHealth: 28,
            maxMana: 7,
            spells: null,
            damage: 6,
            criticalHitChance: 4,
            missChance: 2,
            armor: 2,
            speed: 14,
            itemDrops: new List<Drop>()
            {
                new Drop(ItemManager.SmallHealthPotion, 50),
                new Drop(ItemManager.SmallManaPotion, 50),
                new Drop(ItemManager.WoodenSword, 10)
            },
            goldDrop: 5,
            escapeChance: 60,
            xpDrop: 15
        );

        public static Human Bandit = new(
            name: "Bandit",
            spritePath: "human.txt",
            level: 9,
            maxHealth: 24,
            maxMana: 6,
            spells: null,
            damage: 5,
            criticalHitChance: 4,
            missChance: 2,
            armor: 2,
            speed: 11,
            itemDrops: new List<Drop>()
            {
                new Drop(ItemManager.SmallHealthPotion, 50),
                new Drop(ItemManager.SmallManaPotion, 50),
                new Drop(ItemManager.WoodenSword, 10)
            },
            goldDrop: 5,
            escapeChance: 60,
            xpDrop: 15
        );

        public static Wolve BlackWolve = new(
            name: "Black Wolve",
            spritePath: "wolf.txt",
            level: 8,
            maxHealth: 20,
            maxMana: 10,
            spells: null,
            damage: 7,
            criticalHitChance: 4,
            missChance: 2,
            armor: 2,
            speed: 11,
            itemDrops: new List<Drop>()
            {
                new Drop(ItemManager.SmallHealthPotion, 50),
                new Drop(ItemManager.SmallManaPotion, 50),
                new Drop(ItemManager.SmallPinkPotion, 50),
                new Drop(ItemManager.WoodenSword, 20),
                new Drop(ItemManager.WoodenBody, 20)
            },
            goldDrop: 9,
            escapeChance: 40,
            xpDrop: 35
        );
    }
}

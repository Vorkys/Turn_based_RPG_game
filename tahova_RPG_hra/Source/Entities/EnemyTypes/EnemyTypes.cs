using System.Collections.Generic;
using tahova_RPG_hra.Source.Spells;

namespace tahova_RPG_hra.Source.Entities.EnemyTypes
{
    class Slime : Enemy
    {
        public Slime(string name, string spritePath, int level, int maxLevel, int maxHealth, int maxMana, List<Spell> spells, int damage, int criticalHitChance, int missChance, int armor, int speed, List<Drop> itemDrops, int goldDrop, int escapeChance, int xpDrop) : base(name, spritePath, level, maxLevel, maxHealth, maxMana, spells, damage, criticalHitChance, missChance, armor, speed, itemDrops, goldDrop, escapeChance, xpDrop)
        {
            this.MaxLevel = maxLevel;
            this.ItemDrops = itemDrops;
            this.GoldDrop = goldDrop;
            //TODO
            this.SpritePath = spritePath;
        }

        //if different leveling needed change this
        //public override void IncreaseLvl(int numberOfLvls) { }

        //if different leveling needed change this
        //public override void ReduceLvl(int numberOfLvls) { }
    }

    class Goblin : Enemy
    {
        public Goblin(string name, string spritePath, int level, int maxLevel, int maxHealth, int maxMana, List<Spell> spells, int damage, int criticalHitChance, int missChance, int armor, int speed, List<Drop> itemDrops, int goldDrop, int escapeChance, int xpDrop) : base(name, spritePath, level, maxLevel, maxHealth, maxMana, spells, damage, criticalHitChance, missChance, armor, speed, itemDrops, goldDrop, escapeChance, xpDrop)
        {
            this.MaxLevel = maxLevel;
            this.ItemDrops = itemDrops;
            this.GoldDrop = goldDrop;
            //TODO
            this.SpritePath = spritePath;
        }

        //if different leveling needed change this
        //public override void IncreaseLvl(int numberOfLvls) { }

        //if different leveling needed change this
        //public override void ReduceLvl(int numberOfLvls) { }
    }

    class Animal : Enemy
    {
        public Animal(string name, string spritePath, int level, int maxLevel, int maxHealth, int maxMana, List<Spell> spells, int damage, int criticalHitChance, int missChance, int armor, int speed, List<Drop> itemDrops, int goldDrop, int escapeChance, int xpDrop) : base(name, spritePath, level, maxLevel, maxHealth, maxMana, spells, damage, criticalHitChance, missChance, armor, speed, itemDrops, goldDrop, escapeChance, xpDrop)
        {
            this.MaxLevel = maxLevel;
            this.ItemDrops = itemDrops;
            this.GoldDrop = goldDrop;
            this.SpritePath = spritePath;
        }

        //if different leveling needed change this
        //public override void IncreaseLvl(int numberOfLvls) { }

        //if different leveling needed change this
        //public override void ReduceLvl(int numberOfLvls) { }
    }

    class Human : Enemy
    {
        public Human(string name, string spritePath, int level, int maxLevel, int maxHealth, int maxMana, List<Spell> spells, int damage, int criticalHitChance, int missChance, int armor, int speed, List<Drop> itemDrops, int goldDrop, int escapeChance, int xpDrop) : base(name, spritePath, level, maxLevel, maxHealth, maxMana, spells, damage, criticalHitChance, missChance, armor, speed, itemDrops, goldDrop, escapeChance, xpDrop)
        {
            this.MaxLevel = maxLevel;
            this.ItemDrops = itemDrops;
            this.GoldDrop = goldDrop;
            this.SpritePath = spritePath;
        }

        //if different leveling needed change this
        //public override void IncreaseLvl(int numberOfLvls) { }

        //if different leveling needed change this
        //public override void ReduceLvl(int numberOfLvls) { }
    }

    class Magical : Enemy
    {
        public Magical(string name, string spritePath, int level, int maxLevel, int maxHealth, int maxMana, List<Spell> spells, int damage, int criticalHitChance, int missChance, int armor, int speed, List<Drop> itemDrops, int goldDrop, int escapeChance, int xpDrop) : base(name, spritePath, level, maxLevel, maxHealth, maxMana, spells, damage, criticalHitChance, missChance, armor, speed, itemDrops, goldDrop, escapeChance, xpDrop)
        {
            this.MaxLevel = maxLevel;
            this.ItemDrops = itemDrops;
            this.GoldDrop = goldDrop;
            this.SpritePath = spritePath;
        }

        //if different leveling needed change this
        //public override void IncreaseLvl(int numberOfLvls) { }

        //if different leveling needed change this
        //public override void ReduceLvl(int numberOfLvls) { }
    }

    class Demonic : Enemy
    {
        public Demonic(string name, string spritePath, int level, int maxLevel, int maxHealth, int maxMana, List<Spell> spells, int damage, int criticalHitChance, int missChance, int armor, int speed, List<Drop> itemDrops, int goldDrop, int escapeChance, int xpDrop) : base(name, spritePath, level, maxLevel, maxHealth, maxMana, spells, damage, criticalHitChance, missChance, armor, speed, itemDrops, goldDrop, escapeChance, xpDrop)
        {
            this.MaxLevel = maxLevel;
            this.ItemDrops = itemDrops;
            this.GoldDrop = goldDrop;
            this.SpritePath = spritePath;
        }

        //if different leveling needed change this
        //public override void IncreaseLvl(int numberOfLvls) { }

        //if different leveling needed change this
        //public override void ReduceLvl(int numberOfLvls) { }
    }

    class Godly : Enemy
    {
        public Godly(string name, string spritePath, int level, int maxLevel, int maxHealth, int maxMana, List<Spell> spells, int damage, int criticalHitChance, int missChance, int armor, int speed, List<Drop> itemDrops, int goldDrop, int escapeChance, int xpDrop) : base(name, spritePath, level, maxLevel, maxHealth, maxMana, spells, damage, criticalHitChance, missChance, armor, speed, itemDrops, goldDrop, escapeChance, xpDrop)
        {
            this.MaxLevel = maxLevel;
            this.ItemDrops = itemDrops;
            this.GoldDrop = goldDrop;
            this.SpritePath = spritePath;
        }

        //if different leveling needed change this
        //public override void IncreaseLvl(int numberOfLvls) { }

        //if different leveling needed change this
        //public override void ReduceLvl(int numberOfLvls) { }
    }
}

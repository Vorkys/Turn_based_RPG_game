using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Core;
using tahova_RPG_hra.Source.GameObjects.Items;
using tahova_RPG_hra.Source.GameObjects.Items.ItemTypes;
using tahova_RPG_hra.Source.Spells;
using tahova_RPG_hra.Source.Statuses;

namespace tahova_RPG_hra.Source.Entities
{
    public class Entity
    {
        private string name;
        private string[] sprite;
        private string spritePath;
        private Item[] inventory;
        private Equippable[] equipment;
        private Entity target;
        private int level;
        private int maxLevel = 40;
        private int entityXP;
        private int xPtoLevelUp;
        private int health;
        private int maxHealth;
        private int mana;
        private int maxMana;
        private List<Spell> spells;
        private int damage;
        private int criticalHitChance;
        private int missChance;
        private int armor;
        private int speed;
        //private Status[] statuses;
        private int money;

        //Player ct
        public Entity(string name, string spritePath, Item[] inventory, Equippable[] equipment, int level, int xPtoLevelUp, int maxHealth, int maxMana, List<Spell> spells, int damage, int criticalHitChance, int missChance, int armor, int speed, int money)
        {
            this.Name = name;
            this.SpritePath = spritePath;
            this.Inventory = inventory;
            this.Equipment = equipment;
            this.Target = null;
            this.Level = level;
            this.EntityXP = 0;
            this.XPtoLevelUp = xPtoLevelUp;
            this.Health = maxHealth;
            this.MaxHealth = maxHealth;
            this.Mana = maxMana;
            this.MaxMana = maxMana;
            this.Spells = spells;
            this.Damage = damage;
            this.CriticalHitChance = criticalHitChance;
            this.MissChance = missChance;
            this.Armor = armor;
            this.Speed = speed;
            this.Money = money;
        }

        //Ally ct
        public Entity(string name, string spritePath, Item[] inventory, Equippable[] equipment, Entity target, int level, int entityXP, int xPtoLevelUp, int health, int maxHealth, int mana, int maxMana, List<Spell> spells, int damage, int criticalHitChance, int missChance, int armor, int speed, int money)
        {
            this.Name = name;
            this.SpritePath = spritePath;
            this.Inventory = inventory;
            this.Equipment = equipment;
            this.Target = target;
            this.Level = level;
            this.EntityXP = entityXP;
            this.XPtoLevelUp = xPtoLevelUp;
            this.Health = health;
            this.MaxHealth = maxHealth;
            this.Mana = mana;
            this.MaxMana = maxMana;
            this.Spells = spells;
            this.Damage = damage;
            this.CriticalHitChance = criticalHitChance;
            this.MissChance = missChance;
            this.Armor = armor;
            this.Speed = speed;
            this.Money = money;
        }

        //Enemy ct
        public Entity(string name, string spritePath, int level, int maxHealth, int maxMana, List<Spell> spells, int damage, int criticalHitChance, int missChance, int armor, int speed)
        {
            this.Name = name;
            this.SpritePath = spritePath;
            this.Inventory = null;
            this.Equipment = null;
            this.Target = null;
            this.Level = level;
            this.EntityXP = 0;
            this.XPtoLevelUp = 100;
            this.Health = maxHealth;
            this.MaxHealth = maxHealth;
            this.Mana = maxMana;
            this.MaxMana = maxMana;
            this.Spells = spells;
            this.Damage = damage;
            this.CriticalHitChance = criticalHitChance;
            this.MissChance = missChance;
            this.Armor = armor;
            this.Speed = speed;
            this.Money = 0;
        }

        public string Name { get => name; set => name = value; }
        public string[] Sprite { get => sprite; set => sprite = value; }
        public string SpritePath { get => spritePath; set => spritePath = value; }
        public Item[] Inventory { get => inventory; set => inventory = value; }
        public Equippable[] Equipment { get => equipment; set => equipment = value; }
        public Entity Target { get => target; set => target = value; }
        public int Level { get => level; set => level = value; }
        public int MaxLevel { get => maxLevel; set => maxLevel = value; }
        public int EntityXP { get => entityXP; set => entityXP = value; }
        public int XPtoLevelUp { get => xPtoLevelUp; set => xPtoLevelUp = value; }
        public int Health { get => health; set => health = value; }
        public int MaxHealth { get => maxHealth; set => maxHealth = value; }
        public int Mana { get => mana; set => mana = value; }
        public int MaxMana { get => maxMana; set => maxMana = value; }
        public List<Spell> Spells { get => spells; set => spells = value; }
        public int Damage { get => damage; set => damage = value; }
        public int CriticalHitChance { get => criticalHitChance; set => criticalHitChance = value; }
        public int MissChance { get => missChance; set => missChance = value; }
        public int Armor { get => armor; set => armor = value; }
        public int Speed { get => speed; set => speed = value; }
        public int Money { get => money; set => money = value; }

        public void LoadSprite()
        {
            //TODO cache?
            if (Sprite != null)
                return;

            string spriteFolder = Path.Combine(Directory.GetCurrentDirectory(), "Assets", "Sprites");

            //check if dir exist, if not create and fill default sprite
            if (!Directory.Exists(spriteFolder))
                CreateDefaultSpriteFolder(spriteFolder);

            //if spritePath is null or if given spritePath isnt valid => set to default
            if (SpritePath == null || !File.Exists(Path.Combine(spriteFolder, SpritePath)))
            {
                SpritePath = "default.txt";

                //check if default sprite file exists, if not the create
                if (!File.Exists(Path.Combine(spriteFolder, SpritePath)))
                    CreateDefaultSpriteFile(spriteFolder);
            }

            //set sprite (default if spritePath was given null)
            Sprite = File.ReadAllLines(Path.Combine(spriteFolder, SpritePath));
        }

        private void CreateDefaultSpriteFolder(string path)
        {
            Directory.CreateDirectory(path);
            CreateDefaultSpriteFile(path);
        }

        private void CreateDefaultSpriteFile(string path)
        {
            string defaultSpritePath = Path.Combine(path, "default.txt");
            string[] defaultSprite = {
                "     ____     ",
                "    /    \\    ",
                "    |    |    ",
                "         |    ",
                "        /     ",
                "       /      ",
                "      |       ",
                "              ",
                "      *       ",
                "              "
            };

            using (StreamWriter writer = new StreamWriter(defaultSpritePath))
            {
                for (int i = 0; i < defaultSprite.Length; i++)
                {
                    if (i != defaultSprite.Length - 1)
                        writer.WriteLine(defaultSprite[i]);
                    else
                        writer.Write(defaultSprite[i]);

                }
            }
        }

        public bool ReduceHealth(int damage)
        {
            Health -= damage;

            //true = entity died, false = entity survived
            return Health <= 0 ? true : false;
        }

        public bool IncreaseHealth(int heal)
        {
            int tmpHealth = Health;

            //overheal
            if (Health + heal > MaxHealth)
                Health = MaxHealth;
            else Health += heal;

            // true = heal was successfull, false = heal wasnt successfull
            return Health != tmpHealth ? true : false;
        }

        public bool ReduceMana(int amount)
        {
            if (Mana < amount)
                return false;
            else
                Mana -= amount;

            return true;
        }

        public bool IncreaseMana(int amount)
        {
            Mana += amount;

            if (Mana > MaxMana)
                Mana = MaxMana;

            return true;
        }

        public bool RemoveItem(Item item, int amount = 1)
        {
            int tmpamount = amount;

            for (int i = 0; i < Inventory.Length; i++)
            {
                if (Inventory[i].Name == item.Name)
                {
                    Inventory[i].Quantity -= amount;
                    amount = 0;

                    if (Inventory[i].Quantity < 0)
                    {
                        amount = -Inventory[i].Quantity;
                        Inventory[i] = null;
                    }
                }

                if (amount == 0)
                    break;
            }

            // true = success, false = failed
            return amount == 0 ? true : false;
        }

        public bool AddItem(Item item, int amount = 1)
        {
            int tmpamount = amount;

            for (int i = 0; i < Inventory.Length; i++)
            {
                if (Inventory[i].Name == item.Name || Inventory[i] == null)
                {
                    Inventory[i].Quantity += amount;
                    amount = 0;

                    if (Inventory[i].Quantity > Inventory[i].MaxQuantity)
                    {
                        amount = Inventory[i].Quantity - Inventory[i].MaxQuantity;
                        Inventory[i].Quantity -= amount;
                    }
                }

                if (amount == 0)
                    break;
            }

            //true = amount has changed (some item looted), false = amount hasnt changed (nothing looted)
            return tmpamount != amount ? true : false;
        }

        public void Equip(Equippable item)
        {
            Equippable tmpItem = this.Equipment[(int)item.Slot];
            this.Equipment[(int)item.Slot] = item;
            this.RemoveItem(item);
            this.AddItem(tmpItem);
        }
    }
}

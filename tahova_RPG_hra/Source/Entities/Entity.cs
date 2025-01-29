using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.GameObjects;
using tahova_RPG_hra.Source.Spells;
using tahova_RPG_hra.Source.Statuses;

namespace tahova_RPG_hra.Source.Entities
{
    internal class Entity
    {
        private string name;
        private string[] sprite;
        private Item[] inventory;
        private Item[] equipment;
        private int level;
        private int entityXP;
        private int XPtoLevelUp;
        private int health;
        private int maxHealth;
        private int mana;
        private int maxMana;
        private Spell[] spells;
        private int damage;
        private int armor;
        private int speed;
        private Status[] statuses;
        private string[] entryDialog;
        private string[] leaveDialog;
        private int? money;

        public Entity(string name, string[] sprite, Item[] inventory, Item[] equipment, int level, int entityXP, int xPtoLevelUp, int health, int maxHealth, int mana, int maxMana, Spell[] spells, int damage, int armor, int speed, Status[] statuses, string[] entryDialog, string[] leaveDialog, int? money)
        {
            this.name = name;
            this.sprite = sprite;
            this.inventory = inventory;
            this.equipment = equipment;
            this.level = level;
            this.entityXP = entityXP;
            this.XPtoLevelUp = xPtoLevelUp;
            this.health = health;
            this.maxHealth = maxHealth;
            this.mana = mana;
            this.maxMana = maxMana;
            this.spells = spells;
            this.damage = damage;
            this.armor = armor;
            this.speed = speed;
            this.statuses = statuses;
            this.entryDialog = entryDialog;
            this.leaveDialog = leaveDialog;
            this.money = money;
        }

        public bool TakeDamage(int damage)
        {
            health -= damage;

            //true = entity died, false = entity survived
            return health <= 0 ? true : false;
        }

        public bool Heal(int heal)
        {
            int tmpHealth = health;

            //overheal
            if (health + heal > maxHealth)
                health = maxHealth;
            else health += heal;

            // true = heal was successfull, false = heal wasnt successfull
            return health != tmpHealth ? true : false;
        }

        public void AttackEnemy(Entity enemy) { }

        public void AttackEnemy(Entity enemy, Spell spell) { }

        public bool RemoveItem(Item item, int amount = 1)
        {
            int tmpamount = amount;

            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i].Name == item.Name)
                {
                    inventory[i].Quantity -= amount;
                    amount = 0;

                    if (inventory[i].Quantity < 0)
                    {
                        amount = -inventory[i].Quantity;
                        inventory[i] = null;
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

            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i].Name == item.Name || inventory[i] == null)
                {
                    inventory[i].Quantity += amount;
                    amount = 0;

                    if (inventory[i].Quantity > inventory[i].MaxQuantity)
                    {
                        amount = inventory[i].Quantity - inventory[i].MaxQuantity;
                        inventory[i].Quantity -= amount;
                    }
                }

                if (amount == 0)
                    break;
            }

            //true = amount has changed (some item looted), false = amount hasnt changed (nothing looted)
            return tmpamount != amount ? true : false;
        }

        public bool UseItem()
        {
            return true;
        }

        public bool TalkEntry()
        {
            return true;
        }

        public bool TalkEnd()
        {
            return true;
        }
    }
}

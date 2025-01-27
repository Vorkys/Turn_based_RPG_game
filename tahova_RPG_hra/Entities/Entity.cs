using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.GameObjects;
using tahova_RPG_hra.Spells;
using tahova_RPG_hra.Statuses;

namespace tahova_RPG_hra.Entities
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
            if ((health + heal) > maxHealth) 
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

            for (int i = 0;i < inventory.Length;i++)
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

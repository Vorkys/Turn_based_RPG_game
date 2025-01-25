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

        public void AttackEnemy(Entity enemy, int damage) { }

        public bool RemoveItem(Item item, int amout = 1)
        {
            int tmpAmout = amout;

            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i].Name == item.Name)
                {
                    inventory[i].Quantity -= amout;

                    if (inventory[i].Quantity < 0)
                    {
                        amout = -inventory[i].Quantity;
                        inventory[i] = null;
                    }
                }

                if (amout == 0)
                    break;
            }

            // true = success, false = failed
            return amout == 0 ? true : false;
        }

        public bool AddItem(Item item, int amout = 1)
        {
            int tmpAmout = amout;

            for (int i = 0;i < inventory.Length;i++)
            {
                if (inventory[i].Name == item.Name)
                {
                    inventory[i].Quantity += amout;

                    if (inventory[i].Quantity > inventory[i].MaxQuantity)
                    {
                        amout = inventory[i].Quantity - inventory[i].MaxQuantity;
                        inventory[i].Quantity -= amout;
                    }
                }

                if (amout == 0)
                    break;
            }

            //foreach (Item _item in inventory)
            //{
            //    //searched item is found and has free quantity
            //    if (_item.Name == item.Name && _item.Quantity < _item.MaxQuantity)
            //    {
            //        _item.Quantity += amout;
            //        amout = 0;

            //        //if max quantity is exceeded given amout is restored and is searching for other free space
            //        if (_item.Quantity > _item.MaxQuantity)
            //        {
            //            amout = _item.Quantity - _item.MaxQuantity;
            //            _item.Quantity -= amout;
            //        }
            //    }
            //    //empty inventory slot
            //    else if (_item == null)
            //    {
            //        _item.Quantity += amout;
            //        amout = 0;

            //        //if max quantity is exceeded given amout is restored and is searching for other free space
            //        if (_item.Quantity > _item.MaxQuantity)
            //        {
            //            amout = _item.Quantity - _item.MaxQuantity;
            //            _item.Quantity -= amout;
            //        }
            //    }

            //    if (amout == 0)
            //        break;
            //}

            //true = amout has changed (some item looted), false = amout hasnt changed (nothing looted)
            return tmpAmout != amout ? true : false;
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

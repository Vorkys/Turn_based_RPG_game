using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Core;
using tahova_RPG_hra.Source.GameObjects.Items;
using tahova_RPG_hra.Source.GameObjects.Items.ItemTypes;
using tahova_RPG_hra.Source.Spells;
using tahova_RPG_hra.Source.Statuses;

namespace tahova_RPG_hra.Source.Entities
{
    internal class Enemy : Entity
    {
        private Item[] drops;
        private int escapeChance;
        private int xpDrop;

        public Enemy(string name, string sprite, Item[] inventory, Equippable[] equipment, Entity target, int level, int entityXP, int xPtoLevelUp, int health, int maxHealth, int mana, int maxMana, List<Spell> spells, int damage, int criticalHitChance, int missChance, int armor, int speed, int? money, Item[] drops, int escapeChance, int xpDrop) : base(name, sprite, inventory, equipment, target, level, entityXP, xPtoLevelUp, health, maxHealth, mana, maxMana, spells, damage, criticalHitChance, missChance, armor, speed, money)
        {
            this.drops = drops;
            this.escapeChance = escapeChance;
            this.xpDrop = xpDrop;
        }

        public bool ChooseMove()
        {
            int healthPercentage = (this.Health * 100) / this.MaxHealth;

            if (healthPercentage < 25)
                //search inventory for health potion
                for (int id = 0; id < Inventory.Length; id++)
                    if (Inventory[id].Name.ToLower().Contains("potion"))
                    {
                        Inventory[id].Use();
                        this.RemoveItem(Inventory[id]);
                        return true;
                    }

            int cantCastSpell = 0;
            int leastManaNeeded = -1;

            foreach (Spell spell in Spells)
                if (leastManaNeeded == -1 || spell.Cost < leastManaNeeded)
                    leastManaNeeded = spell.Cost;

            //check if can cast spell
            if (this.Mana < leastManaNeeded || leastManaNeeded == -1)
                cantCastSpell = 1;

            Random rand = new Random();
            int random = rand.Next(0, 2 - cantCastSpell);

            //attack
            if (random == 0)
            {
                this.Target.ReduceHealth(this.Damage);
                return true;
            }
            else if (random == 1)
                while (true) {
                    random = rand.Next(0, Spells.Count);

                    if (Spells[random].Cost <= this.Mana)
                    {
                        Spells[random].Cast();
                        return true;
                    }

                }

            return false;
        }

        public void Defeated()
        {
            Game.Instance.Player.EntityXP += this.xpDrop;

            foreach (Item item in drops)
                Game.Instance.Player.AddItem(item, item.Quantity);

            //TODO this or change gameState?
            Game.Instance.openExploration();
        }
    }
}

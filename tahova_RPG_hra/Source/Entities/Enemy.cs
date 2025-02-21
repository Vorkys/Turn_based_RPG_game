using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.GameObjects;
using tahova_RPG_hra.Source.Spells;
using tahova_RPG_hra.Source.Statuses;

namespace tahova_RPG_hra.Source.Entities
{
    internal class Enemy : Entity
    {
        private Item[] drops;
        private int escapeChance;

        public Enemy(string name, string[] sprite, Item[] inventory, Item[] equipment, int level, int entityXP, int xPtoLevelUp, int health, int maxHealth, int mana, int maxMana, Spell[] spells, int damage, int criticalHitChance, int missChance, int armor, int speed, Status[] statuses, string[] entryDialog, string[] leaveDialog, int? money, Item[] drops, int escapeChance) : base(name, sprite, inventory, equipment, level, entityXP, xPtoLevelUp, health, maxHealth, mana, maxMana, spells, damage, criticalHitChance, missChance, armor, speed, statuses, entryDialog,leaveDialog, money)
        {
            this.drops = drops;
            this.escapeChance = escapeChance;
        }

        public void setLvlTo(int lvl)
        {
            this.Level = lvl;
        }
    }
}

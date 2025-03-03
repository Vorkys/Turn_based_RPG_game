using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Core;
using tahova_RPG_hra.Source.GameObjects.Items;
using tahova_RPG_hra.Source.GameObjects.Items.ItemTypes;
using tahova_RPG_hra.Source.Quests;
using tahova_RPG_hra.Source.Spells;
using tahova_RPG_hra.Source.Statuses;

namespace tahova_RPG_hra.Source.Entities
{
    internal class Ally : Entity
    {
        private string role;
        private string[] entryDialog;

        public Ally(string name, string[] sprite, Item[] inventory, Equippable[] equipment, Entity target, int level, int entityXP, int xPtoLevelUp, int health, int maxHealth, int mana, int maxMana, Spell[] spells, int damage, int criticalHitChance, int missChance, int armor, int speed, int? money) : base(name, sprite, inventory, equipment, target, level, entityXP, xPtoLevelUp, health, maxHealth, mana, maxMana, spells, damage, criticalHitChance, missChance, armor, speed, money)
        {
        }

        public string Role { get => role; set => role = value; }
        public string[] EntryDialog { get => entryDialog; set => entryDialog = value; }

        public virtual void Talk(Game game) { }
    }
}
